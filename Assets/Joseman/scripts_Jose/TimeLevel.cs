using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLevel : MonoBehaviour
{
    public Text timeTrack;
    public Text levelTrack;
    public double timePassed = 0.00;
    public int levelOn = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
        string timeStr = timePassed.ToString();
        PlayerPrefs.SetString("timePlayed", timeStr);
        PlayerPrefs.SetFloat("highLevel", levelOn);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
