using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(ShootingRoutine());
    }

    private IEnumerator ShootingRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_shootingDelay);

        while (enabled)
        {
            Shoot();

            yield return wait;
        }
    }

    private void Shoot()
    {
        Vector3 direction = (_target.position - transform.position).normalized;

        Rigidbody newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

        newBullet.transform.up = direction;
        newBullet.velocity = direction * _bulletSpeed;
    }
}
