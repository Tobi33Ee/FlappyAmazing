using UnityEngine;

public class SwordLogic : MonoBehaviour
{
    [SerializeField] private GameObject swords;
    private int difficultyLevel; // Default difficulty level
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("DifficultyLevel"))
        {
            if(difficultyLevel != PlayerPrefs.GetInt("DifficultyLevel"))
            {
                if (PlayerPrefs.GetInt("DifficultyLevel") == 1)
                {
                    Vector3 spawn = new Vector3(0.25f, transform.position.y, transform.position.z);
                    transform.position = spawn;
                    difficultyLevel = PlayerPrefs.GetInt("DifficultyLevel");
                }
                else if (PlayerPrefs.GetInt("DifficultyLevel") == 2)
                {
                    Vector3 spawn = new Vector3(3.5f, transform.position.y, transform.position.z);
                    transform.position = spawn;
                    difficultyLevel = PlayerPrefs.GetInt("DifficultyLevel");
                }
                else if (PlayerPrefs.GetInt("DifficultyLevel") == 3)
                {
                    Vector3 spawn = new Vector3(6.5f, transform.position.y, transform.position.z);
                    transform.position = spawn;
                    difficultyLevel = PlayerPrefs.GetInt("DifficultyLevel");
                }
            }
        }
    }
}
