using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour, IRemovable
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _timeOfLife = 3f;
    [SerializeField] private LayerMask _ignoredLayerMask;

    private Coroutine _coroutine;

    public event UnityAction<Bullet> Removed;

    private void OnEnable() =>
        _coroutine = StartCoroutine(DestroyAfterTime(_timeOfLife));

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Update() =>
        transform.position += transform.right * _speed * Time.deltaTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) != _ignoredLayerMask)
        {
            Remove();

            if (collision.TryGetComponent(out IDieable dieable))
                dieable.Die();
        }
    }

    public void Remove() =>
        Removed?.Invoke(this);

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Remove();
    }
}