using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipping : MonoBehaviour
{
    public float jumpForce = 10f;
    public float rotationSpeed = 200f;
    private bool isGrounded;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1; // Ensure the game starts running
    }

    void Update()
    {
        // Jump when Space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // Rotate with A and D keys
        if (!isGrounded)
        {
            float rotationInput = 0;
            if (Input.GetKey(KeyCode.Space)) rotationInput = -1;

            transform.Rotate(0, 0, rotationInput * rotationSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            // Check if landed upright
            float angle = Mathf.Abs(transform.eulerAngles.z);
            if (angle < 10 || angle > 350)
            {
                //PelisceneLogiikka.instance.PeliPaattyi(true);

                Debug.Log("Landed Upright! Good Job!");
            }
            else
            {
                PelisceneLogiikka.instance.PeliPaattyi(false);

                Debug.Log("Game Over! You crashed.");
                //Time.timeScale = 0; // Stops the game
                //Debug.Log("Press R to Restart.");
            }
        }
    }

    void LateUpdate()
    {
        // Restart the game when "R" is pressed
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}