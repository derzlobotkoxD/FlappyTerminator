using UnityEngine.Events;

public class StartScreen : Window
{
    public event UnityAction PlayButtonClicked;

    protected override void OnButtonClick() =>
        PlayButtonClicked?.Invoke();
}