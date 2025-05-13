using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of the pipe movement
    private float deadZone = -17f; // X position where the pipe is destroyed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("DifficultyLevel"))
        {
            if (PlayerPrefs.GetInt("DifficultyLevel") == 1) //Easy
            {
                speed = 7f;
            } else if (PlayerPrefs.GetInt("DifficultyLevel") == 2) //Medium
            {
                speed = 10f;
            } else if (PlayerPrefs.GetInt("DifficultyLevel") == 3) //Hard
            {
                speed = 12.345f;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + (Vector3.left * speed * Time.fixedDeltaTime);
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject); // Destroy the pipe when it goes out of bounds
        }
    }
}
