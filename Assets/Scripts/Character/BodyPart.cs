using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private Transform _maxPoint;
    [SerializeField] private Transform _midUpperPoint;
    [SerializeField] private Transform _midLowerPoint;
    [SerializeField] private Transform _minPoint;

    [SerializeField] private Transform _target;
    [SerializeField] private float _speedRatation;

    private float _maxRotation = 1;
    private float _minRotation = 0;

    private float _startRotation = 0.5f;
    private float _currentRotation;

    private void Start() =>
        Restart();

    private void Update() =>
        _target.position = Bezier.GetPoint(_maxPoint, _midUpperPoint, _midLowerPoint, _minPoint, _currentRotation);

    public void RotateDown()
    {
        if (_currentRotation > _minRotation)
            _currentRotation -= _speedRatation * Time.deltaTime;
    }

    public void RotateUp() =>
        _currentRotation = _maxRotation;

    public void Restart() =>
        _currentRotation = _startRotation;
}
