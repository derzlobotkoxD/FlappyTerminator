using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class GroundHandler : MonoBehaviour
{
    public event UnityAction CollisionDetected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
            CollisionDetected?.Invoke();
    }
}