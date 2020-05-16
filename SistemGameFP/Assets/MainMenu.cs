using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("level1");
    }
   
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
