using UnityEngine;
using UnityEngine.Events;

public class Explosion : MonoBehaviour, IRemovable
{
    public event UnityAction<Explosion> Removed;

    public string FunctionNameDelete => nameof(Remove);

    public void Remove() =>
        Removed?.Invoke(this);
}