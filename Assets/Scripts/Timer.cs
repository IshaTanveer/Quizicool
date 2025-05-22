using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswerQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;
    float timerValue;
    public float fillAmount;
    void Update()
    {
        updateTimer();
    }
    public void cancelTimer()
    {
        timerValue = 0;
    }
    void updateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillAmount = timerValue / timeToAnswerQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillAmount = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                loadNextQuestion = true;
                timerValue = timeToAnswerQuestion;
            }
        }
        Debug.Log(isAnsweringQuestion + ":" + timerValue + ":" + fillAmount);
    }
}
