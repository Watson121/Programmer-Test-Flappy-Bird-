using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is the main controller for the player. 
/// </summary>

public class CharacterController : MonoBehaviour
{

    [Header("Managers")]
    public GameDirector gameDirector;
    public SoundManager soundManager;

    // Jump Speed
    [Header("Player Settings")]
    public float speed = 3.0f;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale != 0.0f)
        {

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("Screen Touched");
                    rigidbody.velocity = Vector3.up * speed;
                    soundManager.PlayPlayerJump();
                }
            }

            // DEBUGGING
        /*    if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.velocity = Vector3.up * speed;
                soundManager.PlayPlayerJump();
            }*/
        }
  

        // DEBUGGING
    /*    if (Input.GetKeyDown(KeyCode.R))
        {
            gameDirector.ResetGame();
        }*/
    }

    // If the player passes through a pipe, then they gain a point
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Point")
        {
            gameDirector.Score++;
            soundManager.PlayPlayerPointUp();
        }
    }

    // If the player collides with something then end the game
    private void OnCollisionEnter(Collision collision)
    {
        soundManager.PlayPlayerCrash();
        gameDirector.EndGame();
    }

    // Reseting the player position
    public void ResetPlayer()
    {
        transform.position = Vector3.zero + new Vector3(0, 0, -1.8f);   
    }

}
