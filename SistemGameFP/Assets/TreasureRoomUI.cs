using UnityEngine.SceneManagement;
using UnityEngine;

public class TreasureRoomUI : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("level1");
    }
}
