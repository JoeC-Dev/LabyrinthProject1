using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Control : MonoBehaviour
{
    [Header("Set in Inspector")] 
    public GameObject[] boards;

    [Header("Set Dynamically")]
    public int level = 0;
    public GameObject board;
    public int lives = 10;

    // Starts game when scene is initialized 
    void Start()
    {
        StartLevel();
    }

    //initialize variables for keeping time
    public float timer = 0.0f;
    public int sec,min;

    void Update()
    {
        timer += Time.deltaTime; //seconds of game as a gloat
        sec = (int)(timer); //convert the timer to seconds

        //turns 60 seconds into minutes 
        if(sec == 60)
        {
            min++;
            sec = 0;
        }

        //resets game on escape 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //destroys the ball and the board objects to be respawned
            Destroy(Spawner.ball);
            Destroy(board);

            //adds 20 seconds to the overall time when game is reset
            for(int i = 0; i < 20; i++)
            {
                sec++;
                //makes sure time doesnt go over 60 seconds
                if(sec == 60)
                {
                    min++;
                    sec = 0; 
                }
            }
            //minus a life and restart the level 
            lives--; 
            StartLevel();
        }

        //if the goal is hit this will restart the game
        if(Goal.correctH == true)
        {
            NextLevel();
            Goal.correctH = false; 
        }

        //end games if lives = 0 
        if (lives == 0)
            GameOver();
    }

    //start level will be called and will start current level 
    public void StartLevel()
    {
        if (level < boards.Length)
        {
            board = Instantiate<GameObject>(boards[level]);

        }
        else
            GameOver();
    }

    //next level incriments level and destroys ball and board prefabs from prev. level
    public void NextLevel()
    {
        level++;
        Destroy(Spawner.ball);
        Destroy(board); 
        StartLevel(); 
    }

    //initialize final time variables to be used
    public static int Fmin, Fsec; 
    public void reportTime()
    {
        Fmin = min;
        Fsec = sec; 
    }

    //game over script reports final times and changes scene to end scene
    public void GameOver()
    {
        reportTime();
        //initialize end scene
    }
}
