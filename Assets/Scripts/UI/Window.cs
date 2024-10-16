using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _actionButton;

    private void OnEnable() =>
        _actionButton.onClick.AddListener(OnButtonClick);

    private void OnDisable() =>
        _actionButton.onClick.RemoveListener(OnButtonClick);

    public virtual void Open()
    {
        _windowGroup.alpha = 1f;
        _windowGroup.interactable = true;
        _windowGroup.blocksRaycasts = true;
    }

    public virtual void Close()
    {
        _windowGroup.alpha = 0f;
        _windowGroup.interactable = false;
        _windowGroup.blocksRaycasts = false;
    }

    protected abstract void OnButtonClick();
}