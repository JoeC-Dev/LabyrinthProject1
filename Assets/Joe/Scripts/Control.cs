using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    [Header("Set in Inspector")] 
    //public Vector3 castlePos;
    public GameObject[] boards;

    [Header("Set Dynamically")]
    public int level = 1;
    public int levelMax;
    public int shotsTaken;
    public GameObject board;
    //public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            StartLevel(); 
    }

    void StartLevel()
    {
        board = Instantiate<GameObject>(boards[level]); 
    }

}
