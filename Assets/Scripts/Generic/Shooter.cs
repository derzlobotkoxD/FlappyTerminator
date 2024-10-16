using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _startPointProjectile;
    [SerializeField] private SpawnerBullet _spawner;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _startDelay = 0f;

    public bool CanShoot { get; private set; } = false;

    public void Delay() =>
        StartCoroutine(Cooldown(_startDelay));

    public void Shoot()
    {
        _spawner.GetInstance(_startPointProjectile.position, _startPointProjectile.rotation);
        CanShoot = false;
        StartCoroutine(Cooldown(_cooldown));
    }

    public void SetSpawnerBullet(SpawnerBullet spawner) =>
        _spawner = spawner;

    private IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        CanShoot = true;
    }
}