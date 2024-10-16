using UnityEngine;

public class Remover : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _radius;

    RaycastHit2D[] _hits;

    public void Activate()
    {
        _hits = Physics2D.CircleCastAll(transform.position, _radius, Vector2.up, 0, _mask);

        foreach (RaycastHit2D hit in _hits)
            if (hit.collider.TryGetComponent(out IRemovable removable))
                removable.Remove();
    }
}