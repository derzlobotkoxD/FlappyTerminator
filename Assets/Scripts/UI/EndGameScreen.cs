using UnityEngine.Events;

public class EndGameScreen : Window
{
    public event UnityAction RestartButtonClicked;

    protected override void OnButtonClick() =>
        RestartButtonClicked?.Invoke();
}