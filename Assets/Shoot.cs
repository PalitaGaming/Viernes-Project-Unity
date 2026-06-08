using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireRate = 0.2f;

    private float nextFireTime;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.LookRotation(playerCamera.transform.forward)
        );
    }
}