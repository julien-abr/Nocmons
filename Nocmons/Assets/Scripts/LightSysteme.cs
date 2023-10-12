using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Serialization;

public class LightSysteme : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin; // Le point de départ du raycast
    [SerializeField] private float raycastDistance = 10f; // La distance du raycast
    [SerializeField] private LayerMask hitLayer; // Les couches à prendre en compte pour le raycast
    
    
    PlayerControls _controls;

    [SerializeField] private int numberOfBattery;
    [SerializeField] private int currentBattery;
    [SerializeField] private float timeToReloadLightBullet;


    [FormerlySerializedAs("_Light")] [SerializeField] private GameObject _light;
    [SerializeField] private float _lightDuration = 2f;
    private bool usingLight;
    
    private int _batteryToRecharge;

    private bool isRecharging;
    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Gameplay.handButton.performed += ctx => HandButtonPressed();
    }

    private void Start()
    {
        currentBattery = numberOfBattery;
    }
    void HandButtonPressed()
    {
        ShootRaycast();
    }

    void ShootRaycast()
    {
        if (currentBattery > 0 && !usingLight)
        {
            currentBattery--;
            _batteryToRecharge++;
            Ray ray = new Ray(raycastOrigin.position, raycastOrigin.forward);
            RaycastHit hit;
            StartCoroutine(LightDuration());
            // Effectue le raycast
            if (Physics.Raycast(ray, out hit, raycastDistance, hitLayer))
            {
                Destroy(hit.collider.gameObject);
            }
            Debug.Log("je tire un raycast");
            if (!isRecharging)
            {
                Recharge();
            }
            else
            {
                StopAllCoroutines();
                Recharge();
            }


        }
    }
    void Recharge()
    {
        if (_batteryToRecharge > 0)
        {
            isRecharging = true;

            StartCoroutine(RechargeBattery());
            
            IEnumerator RechargeBattery()
            {
                yield return new WaitForSeconds(timeToReloadLightBullet);
                currentBattery++;
                _batteryToRecharge--;
                isRecharging = false;
                Recharge();
            }
        }

    }

    private IEnumerator LightDuration()
    {
        usingLight = true;
        _light.SetActive(true);
        yield return new WaitForSeconds(_lightDuration);
        Debug.Log("je passe en false les cops");
        _light.SetActive(false);
        usingLight = false;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(raycastOrigin.position, raycastOrigin.forward * raycastDistance);
    }

    private void OnEnable()
    {
        _controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        _controls.Gameplay.Disable();
    }
}
