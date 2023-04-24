using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCounter;
    private int _score = 0;
    private void OnEnable() => ItemManipulator.MatchThree += AddScore;
    private void OnDisable() => ItemManipulator.MatchThree -= AddScore;

    private void Start()
    {
        _textCounter.text = ($"Score {_score}");
    }

    private void AddScore()
    {
        _score++;
        _textCounter.text = ($"Score {_score}");
    }
}
