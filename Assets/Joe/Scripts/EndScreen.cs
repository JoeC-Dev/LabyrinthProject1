using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [Header("Set In Inspector")]
    public Text hL;
    public Text L;
    public Text hT;
    public Text T;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("FinalLevel") == 5)
            hL.text = "Level:" + (PlayerPrefs.GetInt("FinalLevel")).ToString();
        else 
            hL.text = "Level:" + (PlayerPrefs.GetInt("FinalLevel") + 1).ToString();

        if(PlayerPrefs.GetInt("FinalTimeFsec") < 10)
            hT.text = "Time:" + PlayerPrefs.GetInt("FinalTime.Fmin").ToString() + ":0" + PlayerPrefs.GetInt("FinalTime.Fsec");
        else
            hT.text = "Time:" + PlayerPrefs.GetInt("FinalTime.Fmin").ToString() + ":" + PlayerPrefs.GetInt("FinalTime.Fsec");

        if(Control.fLevel == 5)
            L.text = "Level:" + (Control.fLevel).ToString();
        else
            L.text = "Level:" +(Control.fLevel + 1).ToString();

        if(Control.Fsec < 10)
            T.text = "Time:" + Control.Fmin.ToString() + ":0" + Control.Fsec.ToString();
        else 
            T.text = "Time:" + Control.Fmin.ToString() + ":" + Control.Fsec.ToString();
    }

}
