using UnityEngine;

using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;
    void Start()
    {
        quiz = FindFirstObjectByType<Quiz>();
        endScreen = FindFirstObjectByType<EndScreen>();
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }
    void Update()
    {
        if (quiz.slider.value == quiz.totalQuestions)
        {
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.displayFinalText();
        }
    }
    
    public void OnReplayLevel()
    {
        Debug.Log("Replay button clicked!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
