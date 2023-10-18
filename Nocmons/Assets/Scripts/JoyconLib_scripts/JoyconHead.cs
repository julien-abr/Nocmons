using System.Collections;
using System.Collections.Generic;
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
	[SerializeField] private float LeftRotMin;
	[SerializeField] private float LeftRotMax;
	[SerializeField] private float MiddleRotMin;
	[SerializeField] private float MiddleRotMax;
	[SerializeField] private float RightRotMin;
	[SerializeField] private float RightRotMax;

	[SerializeField] private RotationState currentRot;
	
	void Start()
	{
		currentRot = RotationState.Middle;
		_gyro = new Vector3(0, 0, 0);
		_accel = new Vector3(0, 0, 0);
		// get the public Joycon array attached to the JoyconManager in scene
		joycons = JoyconManager.Instance.j;
		if (joycons.Count < jc_ind + 1)
		{
			Destroy(gameObject);
		}
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
		Vector3 quatEuler = quat.eulerAngles;
		float clampedRotY = Mathf.Clamp(quat.y, LeftRotMax, RightRotMax);
		gameObject.transform.rotation = new Quaternion(0, clampedRotY, 0, quat.w);
	}
	enum RotationState
	{
		Left,
		Middle,
		Right,
	}
}
