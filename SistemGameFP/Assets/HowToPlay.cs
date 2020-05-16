using UnityEngine.SceneManagement;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
