using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _forcePush;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _startPosition;

    public float VerticalVelocity => _rigidbody.velocity.y;

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move() =>
        _rigidbody.velocity = new Vector2(_speed, _forcePush);

    public void Restart()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
    }
}