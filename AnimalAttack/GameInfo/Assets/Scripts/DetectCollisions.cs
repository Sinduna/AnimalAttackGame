using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private SpawnManager spawnManager;
   
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Destroys food and animal
    private void OnTriggerEnter(Collider other)
    { 
        //only update score if game is active
        if (spawnManager.isGameActive) 
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            spawnManager.UpdateScore(2);
        }
       
    }
}
