using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private SpawnManager spawnManager;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>(); //find in the heirarchy
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        //to know which button was clicked
        Debug.Log(button.gameObject.name + "was clicked");
        spawnManager.StartGame(difficulty);
    }
}
