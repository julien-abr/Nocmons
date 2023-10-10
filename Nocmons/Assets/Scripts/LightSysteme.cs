using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class LightSysteme : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin; // Le point de départ du raycast
    [SerializeField] private float raycastDistance = 10f; // La distance du raycast
    [SerializeField] private LayerMask hitLayer; // Les couches à prendre en compte pour le raycast
    PlayerControls _controls;

    [SerializeField] private int nbLightBullet;
    [SerializeField] private int bulletAlreadyUsed;
    [SerializeField] private float timeToReloadLightBullet;


    private bool canReload = false;

    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Gameplay.handButton.performed += ctx => HandButtonPressed();
    }

    private void Start()
    {
        bulletAlreadyUsed = 0;
    }
    void HandButtonPressed()
    {
        ShootRaycast();
    }

    void ShootRaycast()
    {
        if (bulletAlreadyUsed < nbLightBullet)
        {
            bulletAlreadyUsed++;

            Ray ray = new Ray(raycastOrigin.position, raycastOrigin.forward);

            RaycastHit hit;

            // Effectue le raycast
            if (Physics.Raycast(ray, out hit, raycastDistance, hitLayer))
            {
                Destroy(hit.collider.gameObject);
            }
            Debug.Log("je tire un raycast");
            StartCoroutine(ReloadLight());


        }
    }
    IEnumerator ReloadLight()
    {

        yield return new WaitForSeconds(timeToReloadLightBullet);
        bulletAlreadyUsed--;
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
