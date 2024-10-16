using UnityEngine;

public class ExplosionClip : MonoBehaviour 
{
    [SerializeField] private AnimationClip _clip;
    [SerializeField] private Explosion _explosion;

    private AnimationEvent _event = new AnimationEvent();

    private void Awake()
    {
        _event.functionName = _explosion.FunctionNameDelete;
        _event.time = _clip.length;
        _clip.AddEvent(_event);
    }
}