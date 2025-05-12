using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    private bool isAlive = true;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioSource scoreSound;
    [SerializeField] private AudioSource collisionSound;
    [SerializeField] private AudioSource oobSound;
    public void addScore(int scoreToAdd)
    {
        if (isAlive)
        {
            playerScore += scoreToAdd;
            scoreSound.Play();
            scoreText.text = playerScore.ToString();
        }
    }
    public void restart()
    {
        isAlive = true;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }
    public void gotoTitle()
    {
        isAlive = true;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene("TitleScreen");
    }
    public void gameOver(string deathType)
    {
        if(isAlive)
        {
            if(deathType == "pipe")
            {
                isAlive = false;
                collisionSound.Play();
                gameOverScreen.SetActive(true);
            }else if(deathType == "out_of_bounds")
            {
                isAlive = false;
                oobSound.Play();
                gameOverScreen.SetActive(true);
            }
        }
    }
}
