using UnityEngine;

public class Jetpack : MonoBehaviour
{
    [SerializeField] private Renderer _burnerLeft;
    [SerializeField] private Renderer _burnerRight;

    public void SetActive(bool value)
    {
        _burnerLeft.enabled = value;
        _burnerRight.enabled = value;
    }
}