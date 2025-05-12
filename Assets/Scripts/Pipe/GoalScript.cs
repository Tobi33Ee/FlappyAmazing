using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public LogicScript logic;
    [SerializeField] private float speed = 7.5f; // Speed of the Goal Element

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + (Vector3.left * speed * Time.fixedDeltaTime);
        if (transform.position.x < -17f)
        {
            Destroy(gameObject); // Destroy the pipe when it goes out of bounds
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            logic.addScore(1);
            Debug.Log("Goal Triggered!");
        }
    }
}
