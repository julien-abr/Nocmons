using System.Collections;
using System.Collections.Generic;
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

            // Crée un rayon depuis le point de départ dans la direction du transform forward (z-axis)
            Ray ray = new Ray(raycastOrigin.position, raycastOrigin.forward);

            // Déclare un RaycastHit pour stocker les informations sur ce que le rayon a touché
            RaycastHit hit;

            // Effectue le raycast
            if (Physics.Raycast(ray, out hit, raycastDistance, hitLayer))
            {
                // Si le raycast touche un objet sur la couche spécifiée, détruit cet objet
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
