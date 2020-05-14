using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public Question[] questions;
    public GameObject correctPanel;
    public GameObject wrongPanel;

    private static List<Question> unasweredQuestions;
    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestions = 2f;

    void Start()
    {
        if(unasweredQuestions == null || unasweredQuestions.Count == 0)
        {
            unasweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unasweredQuestions.Count);
        currentQuestion = unasweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.question;
    }

    IEnumerator TransitionToNextQuestion()
    {
        unasweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectTrue()
    {
        if (currentQuestion.isTrue)
        {
            Debug.Log("CORRECT!");
            correctPanel.SetActive(true);
        }
        else
        {
            Debug.Log("WRONG!");
            wrongPanel.SetActive(true);
        }
        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFalse()
    {
        if (!currentQuestion.isTrue)
        {
            Debug.Log("CORRECT!");
            correctPanel.SetActive(true);
        }
        else
        {
            Debug.Log("WRONG!");
            wrongPanel.SetActive(true);
        }
        StartCoroutine(TransitionToNextQuestion());
    }
}
