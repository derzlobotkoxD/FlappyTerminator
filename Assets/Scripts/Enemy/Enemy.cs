using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMover), typeof(Shooter), typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IDieable, IRemovable
{
    private EnemyMover _mover;
    private Rigidbody2D _rigidbody;
    private Shooter _shooter;

    public event UnityAction<Enemy> Removed;

    public bool IsDead { get; private set; } = false;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _shooter = GetComponent<Shooter>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnEnable()
    {
        IsDead = false;
        _shooter.Delay();
        _mover.StartMove();
    }

    private void OnDisable() =>
        _mover.StopMove();

    private void Update()
    {
        _mover.Move();

        if(_shooter.CanShoot)
            _shooter.Shoot();
    }

    public void SetSpawnerBullet(SpawnerBullet spawner) =>
        _shooter.SetSpawnerBullet(spawner);

    public void Die()
    {
        IsDead = true;
        Remove();
    }

    public void Remove() =>
        Removed?.Invoke(this);
}