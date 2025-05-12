using UnityEngine;


public class DificultyLogic : MonoBehaviour
{
    private int difficultyLevel = 1; // Default difficulty level

    public void Start()
    {
        // Set the difficulty level based on the player's choice
        int difficultyLevel = PlayerPrefs.GetInt("DifficultyLevel", 1); // Default to 1 if not set
    }

    public void SetDifficultyLevel(int level)
    {
        difficultyLevel = level;
        PlayerPrefs.SetInt("DifficultyLevel", level); // Save the difficulty level
        PlayerPrefs.Save(); // Ensure the data is saved
        Debug.Log(PlayerPrefs.GetInt("DifficultyLevel"));
    }
}
