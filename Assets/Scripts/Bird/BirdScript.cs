using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class BirdScript : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float torqueRevertDelay = 0.1f; // Delay before reverting torque/rotation
    [SerializeField] private float jumpCooldownTime = 0.4f; // Cooldown time for jumping (400ms)
    [SerializeField] private AudioSource flapSound;
    private Rigidbody2D rb;
    private bool canJump = true;
    private bool jumpSwing = true;
    private bool isAlive = true;
    public LogicScript logic;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed && canJump && isAlive)
        {
            // Upwards force for the jump
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            float torqueForce = jumpForce * 0.07f; // Decrease jump force for the torque
            flapSound.Play();

            // To phase between + & - torque
            if (jumpSwing) {
                rb.AddTorque(-torqueForce, ForceMode2D.Impulse);
                jumpSwing = false; 
            } else {
                rb.AddTorque(torqueForce, ForceMode2D.Impulse);
                jumpSwing = true;
            }

            Debug.Log("Jump Phase = " + jumpSwing);

            StartCoroutine(JumpCooldown(jumpCooldownTime));
            StartCoroutine(RevertTorqueAfterDelay(torqueRevertDelay));
        }
    }

    private IEnumerator JumpCooldown(float seconds)
    {
        canJump = false;
        yield return new WaitForSeconds(seconds);
        canJump = true;
    }
    private IEnumerator RevertTorqueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // rb.AddTorque(-jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // Keine kontinuierliche Bewegung mehr nötig
        if (rb.position.y > 6.4f || rb.position.y < -6.4f)
        {
            logic.gameOver("out_of_bounds");
            isAlive = false;
        }
        if(!isAlive)
        {
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb.AddForce(Vector2.left * 6f, ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) // Layer 6 is the pipe layer
        {
            logic.gameOver("pipe");
            isAlive = false;
            Debug.Log("Game Over!");
        }
    }
}
