using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenLogic : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void loadSettingScene()
    {
        SceneManager.LoadScene("SettingsScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
