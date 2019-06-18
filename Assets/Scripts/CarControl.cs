using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarControl : MonoBehaviour {

    public GameObject Test;
    public float force = 1000f;
    public float upForce = 10f;
    public float turnAngle = 1.5f;
    public GameObject terrain;
    private Rigidbody rb;
    private Transform tf;
    public Text speedMeter;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();    
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0.0f, Input.GetAxis("Horizontal")*turnAngle, 0.0f);
    }
    void FixedUpdate()
    {
        if(tf.transform.position.y < 0.7+Terrain.activeTerrain.SampleHeight(tf.transform.position))
        {
            rb.AddForce(0, upForce, 0);
        }
        if (Input.GetAxis("Vertical")==1)
        {
            //rb.Add
            rb.AddRelativeForce(0, 0, force * Time.deltaTime);
           
        }
        if (Input.GetAxis("Vertical") == -1)
        {
            rb.AddRelativeForce(0, 0, -force * Time.deltaTime);
        }
        int z = (int)(rb.velocity.magnitude * 10);
        speedMeter.text=z.ToString();           
    } 
}
