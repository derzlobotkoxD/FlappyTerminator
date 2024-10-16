using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterMover), typeof(InputReader), typeof(GroundHandler))]
[RequireComponent(typeof(BodyPart), typeof(Jetpack), typeof(Shooter))]
public class Character : MonoBehaviour, IDieable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _deadClip;

    private CharacterMover _mover;
    private Shooter _shooter;
    private BodyPart _bodyPart;
    private Jetpack _jetpack;
    private InputReader _inputReader;
    private GroundHandler _groundHandler;

    private bool _isDead = false;
    private AnimationEvent _animationEvent = new AnimationEvent();

    public event UnityAction Died;

    private void Awake()
    {
        _mover = GetComponent<CharacterMover>();
        _shooter = GetComponent<Shooter>();
        _bodyPart = GetComponent<BodyPart>();
        _jetpack = GetComponent<Jetpack>();
        _inputReader = GetComponent<InputReader>();
        _groundHandler = GetComponent<GroundHandler>();

        AddEventToDeadClip();
    }

    private void OnEnable() =>
        _groundHandler.CollisionDetected += FallDown;

    private void OnDisable() =>
        _groundHandler.CollisionDetected -= FallDown;

    private void FixedUpdate()
    {
        if (_isDead)
            return;

        if (_inputReader.GetIsJump())
        {
            _mover.Move();
            _bodyPart.RotateUp();
        }

        if (_inputReader.GetIsAttack() && _shooter.CanShoot)
        {
            _animator.SetTrigger(Constants.Animation.Attack);
            _shooter.Shoot();
        }

        if (_mover.VerticalVelocity < 0)
            _bodyPart.RotateDown();

        _jetpack.SetActive(_mover.VerticalVelocity > 0);
    }

    public void Die()
    {
        _isDead = true;
        _animator.SetBool(Constants.Animation.FlyDead, true);
    }

    public void Restart()
    {
        _mover.Restart();
        _shooter.Delay();
        _bodyPart.Restart();
        _animator.SetTrigger(Constants.Animation.Restart);
        _isDead = false;
    }

    private void FallDown()
    {
        _isDead = true;
        _animator.SetBool(Constants.Animation.FlyDead, false);
        _animator.SetTrigger(Constants.Animation.Dead);
    }

    private void GameOver() =>
        Died?.Invoke();

    private void AddEventToDeadClip()
    {
        _animationEvent.time = _deadClip.length;
        _animationEvent.functionName = nameof(GameOver);
        _deadClip.AddEvent(_animationEvent);
    }
}