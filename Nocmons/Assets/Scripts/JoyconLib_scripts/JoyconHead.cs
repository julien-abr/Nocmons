using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JoyconHead : MonoBehaviour
{
	private List<Joycon> joycons;

	// Values made available via Unity
	public float[] _stick;
	public Vector3 _gyro;
	public Vector3 _accel;
	public int jc_ind = 0;
	public Quaternion _orientation;
	[SerializeField] Quaternion _orientationJoycon;
	[SerializeField] Quaternion _orientationReset;
	private cameraMovement _camMovement;


	[SerializeField] private BearReference _bearReference;
	private BearState _bearState;
	void Start()
	{
		_bearState = _bearReference.Instance.GetComponent<BearState>();
		 _bearState.ChangeRotationState(RotationState.Middle);
		_gyro = new Vector3(0, 0, 0);
		_accel = new Vector3(0, 0, 0);
		// get the public Joycon array attached to the JoyconManager in scene
		joycons = JoyconManager.Instance.j;
		if (joycons.Count < jc_ind + 1)
		{
			return;
		}
		_camMovement = GetComponentInParent<cameraMovement>();
	}

	// Update is called once per frame
	void Update()
	{
		// make sure the Joycon only gets checked if attached
		if (joycons.Count > 0)
		{
			Joycon _j = joycons[jc_ind];
			

			_stick = _j.GetStick();

			// Gyro values: x, y, z axis values (in radians per second)
			_gyro = _j.GetGyro();

			// Accel values:  x, y, z axis values (in Gs)
			_accel = _j.GetAccel();

			// Here we just need x
			_orientation = _j.GetVector();
			if (_j.GetButton(Joycon.Button.PLUS))
			{
				//reset
				Debug.Log("Reset Orientation");
				_orientationReset = new Quaternion(0, 0, 0, 0);
			}
			_orientationJoycon = _orientation;//Quaternion.Inverse(_orientationReset);
			ClampRot(_orientation);
		}


	}
	private void ClampRot(Quaternion quat)
	{
		
		float clampedAngleY = Mathf.Clamp(quat.y, -0.3f, 0.3f);
		float InverseLerp = Mathf.InverseLerp(-0.3f, 0.3f, clampedAngleY);
		if(InverseLerp == 0 || InverseLerp == 1) {return;}

		switch (InverseLerp)
		{
			case <= 0.33f:
				OnDirectionChanged(RotationState.Left);
				break;
			case >= 0.66f:
				OnDirectionChanged(RotationState.Right);
				break;
			default:
				OnDirectionChanged(RotationState.Middle);
				break;
		}
		/*float angle = Mathf.Lerp(-60, 60, InverseLerp);
		Debug.Log("inv : " + InverseLerp + " angle : " + angle);
		gameObject.transform.eulerAngles = new Vector3(0, angle, 0);*/
	}

	private void OnDirectionChanged(RotationState newRot)
	{
		if (newRot == _bearState.CurrentRot) return;
		
		_bearState.ChangeRotationState(newRot);
		
		switch (newRot)
		{
			case RotationState.Left:
				_camMovement.RotateCameLeft();
				break;
			case RotationState.Middle:
				_camMovement.RotateCameMiddle();
				break;
			case RotationState.Right:
				_camMovement.RotateCameRight();
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(newRot), newRot, null);
		}
	}


}
public enum RotationState
{
	Left,
	Middle,
	Right,
}