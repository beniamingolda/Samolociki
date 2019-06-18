using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public GameObject CountDownT;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public GameObject LapTimer;
    public GameObject CarControls;
    public GameObject AIControls;

    void Start()
    {
        StartCoroutine(CountStart());
    }


    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        CountDownT.GetComponent<Text>().text = "3";
        GetReady.Play();
        CountDownT.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDownT.SetActive(false);
        CountDownT.GetComponent<Text>().text = "2";
        GetReady.Play();
        CountDownT.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDownT.SetActive(false);
        CountDownT.GetComponent<Text>().text = "1";
        GetReady.Play();
        CountDownT.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDownT.SetActive(false);
        GoAudio.Play();
        LapTimer.SetActive(true);
        CarControls.SetActive(true);
        AIControls.SetActive(true);
    }
}
