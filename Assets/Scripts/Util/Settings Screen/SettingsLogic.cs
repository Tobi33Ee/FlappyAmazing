using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsLogic : MonoBehaviour
{
    public void loadTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
