using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of the pipe movement
    private float deadZone = -17f; // X position where the pipe is destroyed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
