using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Control : MonoBehaviour
{
    [Header("Set in Inspector")] 
    public GameObject[] boards;
    public GameObject ball;
    public GameObject ballSpawn; 

    [Header("Set Dynamically")]
    public int level = 0;
    public GameObject board; 
    // Start is called before the first frame update
    void Start()
    {
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(Spawner.ball);
            Destroy(board);
            StartLevel();
        }

        if(Goal.correctH == true)
        {
            NextLevel();
            Goal.correctH = false; 
        }
    }

    public void StartLevel()
    {
        if (level < boards.Length)
        {
            board = Instantiate<GameObject>(boards[level]);
            
        }
        //else;
            //go to end screen.
            
    }

    public void NextLevel()
    {
        level++;
        Destroy(Spawner.ball);
        Destroy(board); 
        StartLevel(); 
    }
}
