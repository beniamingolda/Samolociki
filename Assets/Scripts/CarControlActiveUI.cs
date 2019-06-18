using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlActiveUI : MonoBehaviour
{
    public GameObject CarObj;
    // Start is called before the first frame update
    void Start()
    {
        CarObj.GetComponent<CarUI>().enabled = true;
    }
}
