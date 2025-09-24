using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private GameObject _bulletPrefab;
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

        GameObject newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);
        Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();

        rigidbody.transform.up = direction;
        rigidbody.velocity = direction * _bulletSpeed;
    }
}
