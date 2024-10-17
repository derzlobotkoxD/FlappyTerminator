using UnityEngine;

public class Remover : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _radius;

    public void Activate()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _radius, Vector2.up, 0, _mask);

        foreach (RaycastHit2D hit in hits)
            if (hit.collider.TryGetComponent(out IRemovable removable))
                removable.Remove();
    }
}