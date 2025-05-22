using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Scriptable Objects/QuestionsSO")]
public class QuestionsSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter your question here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnsIndex;

    public string getQuestion()
    {
        return question;
    }
    public int getCorrectAnsIndex()
    {
        return correctAnsIndex;
    }
    public string getAnswer(int index)
    {
        return answers[index];
    }
}
