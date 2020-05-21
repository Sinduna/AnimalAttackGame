using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public AudioClip foodSound;
    private AudioSource playerAudio;
    

    public GameObject projectilePreFab;
    
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z); //keeps player inbounds from the left
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z); //keep player inbounds from the right
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed); //move the player left or right
        
        if (Input.GetKeyDown(KeyCode.Space)) //launch a projectile from the player
        {
            Instantiate(projectilePreFab, transform.position, projectilePreFab.transform.rotation); //make copies of the food
            playerAudio.PlayOneShot(foodSound, 1.0f);
        }
    }
}
