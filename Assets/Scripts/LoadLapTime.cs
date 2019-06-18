using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadLapTime : MonoBehaviour
{
    public int MinCount;
    public int SecCount;
    public float MilliCount;
    public GameObject MinDisplay;
    public GameObject SecDisplay;
    public GameObject MilliDisplay;

    void Start()
    {
        MinCount = PlayerPrefs.GetInt("MinSave");
        SecCount = PlayerPrefs.GetInt("SecSave");
        MilliCount = PlayerPrefs.GetFloat("MilliSave");
        if (MinCount < 10)
        {
            MinDisplay.GetComponent<Text>().text = "0" + MinCount + ":";

        }
        else
        {
            MinDisplay.GetComponent<Text>().text = "" + MinCount + ":";

        }
        if (SecCount < 10)
        {
            SecDisplay.GetComponent<Text>().text = "0" + SecCount + ".";
        }
        else
        {
            SecDisplay.GetComponent<Text>().text = "" + SecCount + ".";

        }
        MilliDisplay.GetComponent<Text>().text = "" + MilliCount;
    }
}
