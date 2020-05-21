using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public TextMeshProUGUI scoreText;
    private int score;
    public bool isGameActive;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    private float spawnRangeX = 10;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
       
    }
    void SpawnRandomAnimal()
    {
        if (isGameActive == true)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length); //to spawn random animals
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); //spawn animals within the bounds

            Instantiate(animalPrefabs[animalIndex], spawnPos,
                animalPrefabs[animalIndex].transform.rotation); //Creates the animal
        }

    }  
    
   public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
        
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        //use scene manager to load a scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;

        spawnInterval = spawnInterval / difficulty; //decide the level

        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval); //time it starts at and repeats 
        UpdateScore(0);

        //disable title screen when game starts
        titleScreen.gameObject.SetActive(false);
    }
    
  
}
