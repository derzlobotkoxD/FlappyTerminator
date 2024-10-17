using System.Collections;
using UnityEngine;

public class SpawnerEnemy : Spawner<Enemy>
{
    [SerializeField] private SpawnerBullet _spawnerBullet;
    [SerializeField] private SpawnerExplosion _spawnerExplosion;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private int _maxCountEnemy = 3;
    [SerializeField] private float _delay = 3;
    [SerializeField] private Vector2 _spawnPointViewport = new Vector2(1.1f, 1.1f);
    [SerializeField] private Vector2 _spawnPointWorld;

    private void Start()
    {
        _spawnPointWorld = Camera.main.ViewportToWorldPoint(_spawnPointViewport);
        StartCoroutine(SpawnWithDelay(_delay));
    }

    protected override Enemy CreateInstance()
    {
        Enemy enemy = base.CreateInstance();
        enemy.SetSpawnerBullet(_spawnerBullet);
        return enemy;
    }

    protected override void ActivateInstance(Enemy enemy)
    {
        enemy.Removed += ReleaseInstance;
        base.ActivateInstance(enemy);
    }

    protected override void ReleaseInstance(Enemy enemy)
    {
        if (enemy.IsDead)
        {
            _scoreCounter.Add();
            _spawnerExplosion.GetInstance(enemy.transform.position, Quaternion.identity);
        }

        enemy.Removed -= ReleaseInstance;
        base.ReleaseInstance(enemy);
    }

    private void Spawn() =>
        GetInstance(_spawnPointWorld, Quaternion.identity);

    private IEnumerator SpawnWithDelay(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return wait;

            if (CountActive < _maxCountEnemy)
                Spawn();
        }
    }
}