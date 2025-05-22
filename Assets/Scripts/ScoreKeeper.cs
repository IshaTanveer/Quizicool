using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    Quiz quiz;
    int score;
    [SerializeField] TextMeshProUGUI Score;
    void Start()
    {
        quiz = FindFirstObjectByType<Quiz>();
    }
    void Update()
    {
        score = quiz.getScore();
        Score.text = score.ToString();
    }
    public int getFinalScore()
    {
        return score;
    }
}
