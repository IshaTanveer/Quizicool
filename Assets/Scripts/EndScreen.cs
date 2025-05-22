using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    int finalScore;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        finalScore = scoreKeeper.getFinalScore();
    }
    public void displayFinalText()
    {
        finalScoreText.text = "Congratulations Isha\n You scored " + finalScore;
    }
}
