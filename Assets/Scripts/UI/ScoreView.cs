using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _score;

    private void OnEnable() =>
        _scoreCounter.ScoreChanged += Change;

    private void OnDisable() =>
        _scoreCounter.ScoreChanged -= Change;

    private void Change(int value) =>
        _score.text = value.ToString();
}