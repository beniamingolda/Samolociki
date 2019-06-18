using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public GameObject thisTrigger;
    public GameObject nextTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CarPlayer")
        {
            nextTrigger.SetActive(true);
            thisTrigger.SetActive(false);
        }   
    }
}
