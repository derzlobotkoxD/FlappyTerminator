using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;

    private ObjectPool<T> _pool;
    private int _defaultCapacitPool = 5;
    private int _maxSizePool = 5;
    private Vector2 _spawnPoint;

    protected Quaternion Rotation { get; private set; }
    protected float CountActive => _pool.CountActive;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => CreateInstance(),
            actionOnGet: (obj) => ActivateInstance(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _defaultCapacitPool,
            maxSize: _maxSizePool);
    }

    public void GetInstance(Vector2 position, Quaternion rotation)
    {
        _spawnPoint = position;
        Rotation = rotation;
        _pool.Get();
    }

    protected virtual T CreateInstance() =>
        Instantiate(_prefab);

    protected virtual void ReleaseInstance(T instance) =>
        _pool.Release(instance);

    protected virtual void ActivateInstance(T instance)
    {
        instance.transform.position = _spawnPoint;
        instance.gameObject.SetActive(true);
    }
}