using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getVelocity : MonoBehaviour {

    public Text text;
    public Rigidbody carRb;
    
	// Use this for initialization
	void Start () {
        //text.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
       
        text.text = carRb.velocity.magnitude.ToString();

    }

    void FixedUpdate()
    {
        
    }
}
