using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generator that is responsible for generating the pipes that the player must avoid
/// </summary>

public class PipeGenerator : MonoBehaviour
{

    [Header("GameDirector")]
    public GameDirector gameDirector;

    [Header("Pipe Settings")]
    public float maxTime = 1.0f;
    private float timer = 0;
    public GameObject pipe;
    public float height = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        GameObject newPipe = Instantiate(pipe);
        newPipe.transform.position = Vector3.zero + new Vector3(5, 0.0f, -1.8f);
    }

    // Update is called once per frame
    void Update()
    {

  

            if (timer > maxTime)
            {
                GameObject newPipe = Instantiate(pipe);
                newPipe.transform.position = Vector3.zero + new Vector3(5, Random.Range(-height, height), -1.8f);
                Destroy(newPipe, 5);
                timer = 0;
            }

            timer += Time.deltaTime;

    
  
    }

    public void ResetPipes()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Point");

        foreach(GameObject pipe in pipes)
        {
            Destroy(pipe);
        }

        timer = 0;

        StartGame();
    }
    

}
