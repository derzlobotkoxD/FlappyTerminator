using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Range(0.1f, 0.9f)]
    [SerializeField] private float _positionX = 0.9f;
    [SerializeField] private float _startPositionX = 1.1f;
    [SerializeField] private float _speed = 2f;

    private float _currentPositionX;
    private float _hight;
    private float _maxHight = 0.9f;
    private float _minHight = 0.1f;
    private Coroutine _coroutine;

    public void Move()
    {
        Vector3 position = Camera.main.ViewportToWorldPoint(new Vector2(_currentPositionX, _hight));
        position.z = 0;
        transform.position = position;
    }

    public void StartMove()
    {
        _hight = Random.Range(_minHight, _maxHight);
        _currentPositionX = _startPositionX;
        Move();
        _coroutine = StartCoroutine(ComeUp());
    }

    public void StopMove()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator ComeUp()
    {
        while (_currentPositionX != _positionX)
        {
            _currentPositionX = Mathf.MoveTowards(_currentPositionX, _positionX, _speed * Time.deltaTime);
            yield return null;
        }
    }
}