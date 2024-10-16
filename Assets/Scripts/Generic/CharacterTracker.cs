using UnityEngine;

public class CharacterTracker : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float _offsetX;

    private void LateUpdate()
    {
        Vector3 position = transform.position;
        position.x = _character.transform.position.x + _offsetX;
        transform.position = position;
    }
}