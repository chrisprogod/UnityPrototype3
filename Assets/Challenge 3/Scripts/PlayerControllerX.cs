using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    private bool spacePressed = false;
    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
       // Define a flag to track whether space bar was pressed in this frame

void Update()
{
    // Check if space bar is pressed down this frame
    if (Input.GetKeyDown(KeyCode.Space) && gameOver == false && transform.position.y < 13 && !spacePressed)
    {
        // Set the flag to true to prevent multiple presses in the same frame
        spacePressed = true;

        // Apply upward force to the player
        playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
    }

    // Reset the flag when space bar is released
    if (Input.GetKeyUp(KeyCode.Space))
    {
        spacePressed = false;
    }

    // Ensure the player does not go above y = 15
    if (transform.position.y >= 13)
    {
        transform.position = new Vector3(transform.position.x, 13, transform.position.z);
    }
}




    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }

         else if (other.gameObject.CompareTag("Ground"))
        {
            playerAudio.PlayOneShot(bounceSound, 1.0f);
            playerRb.AddForce(Vector3.up * 550, ForceMode.Impulse);
        }

    }

}
