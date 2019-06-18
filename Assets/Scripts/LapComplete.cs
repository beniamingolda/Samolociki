using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MilliDisplay;
    public GameObject LapTimeBox;
    public GameObject LapCounter;
    public int Laps;
    public float RawTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CarPlayer")
        {
            RawTime = PlayerPrefs.GetFloat("RawTime");

            if (LapTimeMenager.RawTime <= RawTime)
            {
                //LapCounter.GetComponent<Text>().text = "" + Laps;
                if (LapTimeMenager.SecondCount <= 9)
                {
                    SecondDisplay.GetComponent<Text>().text = "0" + LapTimeMenager.SecondCount + ".";
                }
                else
                {
                    SecondDisplay.GetComponent<Text>().text = "" + LapTimeMenager.SecondCount + ".";
                }

                if (LapTimeMenager.MinuteCount <= 9)
                {
                    MinuteDisplay.GetComponent<Text>().text = "0" + LapTimeMenager.MinuteCount + ".";
                }
                else
                {
                    MinuteDisplay.GetComponent<Text>().text = "" + LapTimeMenager.MinuteCount + ".";
                }

                MilliDisplay.GetComponent<Text>().text = "" + LapTimeMenager.MiliCount.ToString("F0");
            }
            PlayerPrefs.SetInt("MinSave", LapTimeMenager.MinuteCount);
            PlayerPrefs.SetInt("SecSave", LapTimeMenager.SecondCount);
            PlayerPrefs.SetFloat("MiliSave", LapTimeMenager.MiliCount);
            Laps += 1;
            LapCounter.GetComponent<Text>().text = Laps.ToString();
            PlayerPrefs.SetFloat("RawTime", LapTimeMenager.RawTime);
            LapTimeMenager.MinuteCount = 0;
            LapTimeMenager.SecondCount = 0;
            LapTimeMenager.MiliCount = 0;
            LapTimeMenager.RawTime = 0;

        }        
    }
}
