using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlActive : MonoBehaviour
{
    public GameObject CarObj;
    // Start is called before the first frame update
    void Start()
    {
        CarObj.GetComponent<CarControl>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
