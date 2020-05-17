using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public Enemy enemyscript;

    public Question[] questions;
    public GameObject correctPanel;
    public GameObject wrongPanel;
    public GameObject Lose;
    public GameObject QuizCanvas;

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

    IEnumerator CorrectAns()
    {
        //////////////////////////////////////////////////////// need change if add level

        yield return new WaitForSeconds(1f);
        correctPanel.SetActive(false);
        QuizCanvas.SetActive(false);
        
    }

    IEnumerator WrongAns()
    {


        yield return new WaitForSeconds(1f);
        QuizCanvas.SetActive(false);
        wrongPanel.SetActive(false);
        enemyscript.iscollidetarget1 = true;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        Lose.SetActive(true);
 

    }

        public void UserSelectTrue()
    {
        if (currentQuestion.isTrue)
        {
            Debug.Log("CORRECT!");
            correctPanel.SetActive(true);
            StartCoroutine(CorrectAns());
        }
        else
        {
            Debug.Log("WRONG!");
            wrongPanel.SetActive(true);
            StartCoroutine(WrongAns());
        }
       
    }

    public void UserSelectFalse()
    {
        if (!currentQuestion.isTrue)
        {
            Debug.Log("CORRECT!");
            correctPanel.SetActive(true);
            StartCoroutine(CorrectAns());

        }
        else
        {
            Debug.Log("WRONG!");
            wrongPanel.SetActive(true);
            StartCoroutine(WrongAns());
        }
       
    }
}
