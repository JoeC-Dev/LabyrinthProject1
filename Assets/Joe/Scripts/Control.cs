using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class Control : MonoBehaviour
{
    [Header("Set in Inspector")] 
    public GameObject[] boards;
    public Text timePassed;
    public Text Level; 

    [Header("Set Dynamically")]
    public int level = 0;
    public GameObject board;
    public int lives = 10;

    // Starts game when scene is initialized 
    void Start()
    {
        StartLevel(); 
        Level.text = "Level: "+(level+1).ToString();
    }

    //initialize variables for keeping time
    public float timer = 0.0f;
    public int sec,min;

    void Update()
    {
        timer += Time.deltaTime; //seconds of game as a gloat
        //sec = (int)(timer); //convert the timer to seconds

        //resets game on escape 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //destroys the ball and the board objects to be respawned
            Destroy(Spawner.ball);
            Destroy(board);
            timer+=20;

            //minus a life and restart the level 
            lives--; 
            StartLevel();
        }

        //updates timer after all time manipulation is done
        TimeUpdater();


        //turns 60 seconds into minutes 
        if (sec == 60)
        {
            min += 1;
            sec = 0;
        }

        //if the goal is hit this will restart the game
        if (Goal.correctH == true)
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
        Level.text = "Level: "+(level+1).ToString();
    }

    //initialize final time variables to be used
    public static int Fmin, Fsec, Ftimer; 
    public void reportTime()
    {
        Ftimer = (int)timer; 
        Fmin = min;
        Fsec = sec;
        if (PlayerPrefs.HasKey("FinalLevel"))
        {
            if(level > PlayerPrefs.GetInt("FinalLevel"))
            {
                PlayerPrefs.SetInt("FinalLevel", level);
            }
        }
        else
        {
            PlayerPrefs.SetInt("FinalLevel", level);
        }
        if (PlayerPrefs.HasKey("FinalTime.Fmin") && level >= PlayerPrefs.GetInt("FinalLevel"))
        {
            if(Fmin < PlayerPrefs.GetInt("FinalTime.Fmin"))
            {
                PlayerPrefs.SetInt("FinalTime.Fmin", Fmin);
                PlayerPrefs.SetInt("FinalTime.Fsec", Fsec);
            }
            else
            {
                if(Fmin == PlayerPrefs.GetInt("FinalTime.Fmin") && Fsec < PlayerPrefs.GetInt("FinalTime.Fsec"))
                {
                    PlayerPrefs.SetInt("FinalTime.Fsec", Fsec);
                }
            }
        }
        else
        {
            if (!PlayerPrefs.HasKey("FinalTime.Fmin") && level >= PlayerPrefs.GetInt("FinalLevel"))
            {
                PlayerPrefs.SetInt("FinalTime.Fmin", Fmin);
                PlayerPrefs.SetInt("FinalTime.Fsec", Fsec);
            }
        }
    }

    //game over script reports final times and changes scene to end scene
    public void GameOver()
    {
        reportTime();
        print("game over");
        SceneManager.LoadScene("_EndScreen");
        //initialize end scene
    }

    //updates the time gui 
    public void TimeUpdater()
    {
        min = (int)timer / 60;
        sec = (int)timer % 60; 
        if(sec < 10)
            timePassed.text = "Time: "+min.ToString() +":0" +sec.ToString();
        else
            timePassed.text = "Time: "+min.ToString() + ":" + sec.ToString();
    }
}
