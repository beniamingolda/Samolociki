using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarControl : MonoBehaviour {

    public float force = 200f;
    public float upForce = 10f;
    public float turnAngle = 1.5f;
    public GameObject terrain;
    public Text speedMeter;
    private Rigidbody rb;
    private Transform tf;
    
    private Vector3 m_EulerAngleVelocity;



	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        //m_EulerAngleVelocity = new Vector3(0, 5, 0);
   
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") == 1)
        {
            
        }
        if (Input.GetAxis("Horizontal") == -1)
        {

        }
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
        
        speedMeter.text =z.ToString();
            
    }
   
}
