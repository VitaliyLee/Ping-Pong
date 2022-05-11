using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private int baseScore;

    [SerializeField] private float ratio;
    [SerializeField] private TextMeshProUGUI scoreText;

    [HideInInspector] public UnityEvent levelComplite;

    public int score => _score;

    public void AddScore()
    {
        _score += Mathf.RoundToInt(baseScore * ratio);
        scoreText.text = _score.ToString();
        levelComplite.Invoke();
    }
}
