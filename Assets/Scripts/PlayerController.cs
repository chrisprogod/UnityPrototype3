using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PointManager pointManager;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;
     private Animator playerAnim;
     public TextMeshProUGUI gameOverText;
     private bool gameIsOver = false;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticles.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        //restart game  when r is pressed
        if (gameIsOver && Input.GetKeyDown(KeyCode.R)) 
        {
            RestartGame();
        }

    }

    //restart game function
    void RestartGame()
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    void GameOver()
{
    gameIsOver = true;
    gameOverText.gameObject.SetActive(true);
    pointManager.ShowFinalText();

    // Start a coroutine to delay the game pause
    StartCoroutine(DelayedPause());
}

IEnumerator DelayedPause()
{
    // Wait for 1 second
    yield return new WaitForSeconds(3f);
    Time.timeScale = 0f;
}
    private void OnCollisionEnter(Collision collision) 
    {
        isOnGround = true;


        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        } else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticles.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            GameOver();
        }
    }
}
