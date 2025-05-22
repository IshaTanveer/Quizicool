using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    public Slider slider;
    int score = 0;
    bool correctAnswerScore = false;
    [SerializeField] List<QuestionsSO> ListOfQuestions = new List<QuestionsSO>();
    [SerializeField] QuestionsSO Question;
    [Header("Answers")]
    [SerializeField] GameObject[] answers;
    int correctIndex;
    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timers")]
    [SerializeField] UnityEngine.UI.Image timerImage;
    Timer timer;
    public int totalQuestions;
    void Start()
    {
        slider.value = 0;
        slider.maxValue = ListOfQuestions.Count;
        totalQuestions = ListOfQuestions.Count;
        timer = FindFirstObjectByType<Timer>();
    }
    private void Update()
    {
        timerImage.fillAmount = timer.fillAmount;
        if (timer.loadNextQuestion)
        {
            setNextQuestion();
            timer.loadNextQuestion = false;
        }
        answerNotSelected();
    }
    public int getScore()
    {
        int scorePercentage = (score * 100) / totalQuestions;
        return scorePercentage;
    }

    public bool CorrectQuestionOrNot()
    {
        return correctAnswerScore;
    }

    private void answerNotSelected()
    {
        UnityEngine.UI.Image buttonImage = answers[Question.getCorrectAnsIndex()].GetComponent<UnityEngine.UI.Image>();
        if (timer.isAnsweringQuestion == false)
        {
            if (buttonImage.sprite == defaultAnswerSprite)
            {
                correctAnswerScore = false;
                setButtonState(false);
                buttonImage.sprite = correctAnswerSprite;
                string correctAnswer = Question.getAnswer(Question.getCorrectAnsIndex());
                questionText.text = "Sorry! The correct answer is " + correctAnswer;
            }
        }
    }

    public void onAnswerSelected(int index)
    {
        UnityEngine.UI.Image buttonImage;
        if (index == Question.getCorrectAnsIndex())
        {
            score++;
            //Score.text = scorePercentage.ToString() + "%";
            //Score.text = "blahhh";
            correctAnswerScore = true;
            questionText.text = "correct";
            buttonImage = answers[index].GetComponent<UnityEngine.UI.Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else if (index != Question.getCorrectAnsIndex())
        {
            correctAnswerScore = false;
            int correctIndex = Question.getCorrectAnsIndex();
            string correctAnswer = Question.getAnswer(correctIndex);
            questionText.text = "False! The correct answer is " + correctAnswer;
            buttonImage = answers[correctIndex].GetComponent<UnityEngine.UI.Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        setButtonState(false);
        timer.cancelTimer();
    }
    void DisplayQusetionAndAnswers()
    {
        questionText.text = Question.getQuestion();
        for (int i = 0; i < answers.Length; i++)
        {
            TextMeshProUGUI answertext = answers[i].GetComponentInChildren<TextMeshProUGUI>();
            answertext.text = Question.getAnswer(i);
        }
    }
    void setButtonState(bool state)
    {
        for (int i = 0; i < answers.Length; i++)
        {
            Button button = answers[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    void setNextQuestion()
    {
        if (ListOfQuestions.Count > 0)
        {
            if (ListOfQuestions.Count == slider.maxValue)
            {
                slider.value = 0;
            }
            else
            {
                slider.value++;
            }
            //slider.value = totalQuestions - (ListOfQuestions.Count + 1);
            setButtonState(true);
            setDefaultButtonSprite();
            selectRandomQuestion();
            DisplayQusetionAndAnswers();
        }
        else if (ListOfQuestions.Count == 0)
        {
            if (slider.value < slider.maxValue)
            {
                slider.value++;
            }
        }
    }

    private void selectRandomQuestion()
    {
        int randomIndex = UnityEngine.Random.Range(0, ListOfQuestions.Count-1);
        Question = ListOfQuestions[randomIndex];
        if (ListOfQuestions.Contains(Question))
        {
            ListOfQuestions.Remove(Question);   
        }
    }

    void setDefaultButtonSprite()
    {
        UnityEngine.UI.Image buttonImage = answers[Question.getCorrectAnsIndex()].GetComponent<UnityEngine.UI.Image>();
        buttonImage.sprite = defaultAnswerSprite;
    }
}
