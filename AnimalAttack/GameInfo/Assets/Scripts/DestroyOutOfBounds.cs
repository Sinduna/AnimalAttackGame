using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    private SpawnManager spawnManager;

    
   
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update() //destroys food and animals that are out of bounds
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z  < lowerBound)
        {         
            
            Debug.Log("Game Over!");
            Destroy(gameObject);
            spawnManager.GameOver();
     
        }
        
    }
}
