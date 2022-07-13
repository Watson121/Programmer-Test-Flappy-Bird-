using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moving the pipe from one end of the screen to another
/// </summary>

public class PipeMovement : MonoBehaviour
{
    private GameDirector gameDirector;

    [Header("Pipe Properties")]
    public float speed = 3.0f;

    private void Awake()
    {
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
  
         transform.position += Vector3.left * speed * Time.deltaTime;
      
    }
}
