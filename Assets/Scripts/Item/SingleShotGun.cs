using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotGun : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float damage;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        ray.origin = cam.transform.position; 
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
        }
    }
}
