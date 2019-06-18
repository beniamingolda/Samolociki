using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUI : MonoBehaviour
{
    public GameObject Marker;
    public GameObject Test;
    public float force = 1000f;
    public float upForce = 10f;
    public float turnAngle = 1.5f;
    public float M = 100;
    public GameObject terrain;
    private Rigidbody rb;
    private Transform tf;
    Quaternion targetRotation;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 direction = Marker.transform.position - tf.position;
        float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        targetRotation = Quaternion.Euler(0, rotationAngle, 0);
        tf.rotation = Quaternion.Lerp(tf.rotation,targetRotation,turnAngle*Time.deltaTime);
        Debug.Log(tf.rotation);
    }
    void FixedUpdate()
    {       
        if (tf.transform.position.y < 0.7 + Terrain.activeTerrain.SampleHeight(tf.transform.position))
        {
            rb.AddForce(0, upForce, 0);
        }
        rb.AddRelativeForce(0, 0, (force-tf.rotation.y*M) * Time.deltaTime);
    }
}
