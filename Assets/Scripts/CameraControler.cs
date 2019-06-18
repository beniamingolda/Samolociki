using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform Car;
    public float distance;
    public float height;
    public float rotationDamping;
    public float heightDamping;
    public float zoomRatio;
    public float defaultFOV;
    private float rotation_vector;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        Vector3 local_velocity = Car.InverseTransformDirection(Car.GetComponent<Rigidbody>().velocity);
        if (local_velocity.z < -0.5f)
        {
            rotation_vector = Car.eulerAngles.y + 100;
        }
        else
        {
            rotation_vector = Car.eulerAngles.y;
        }
        float acceleration = Car.GetComponent<Rigidbody>().velocity.magnitude;
        Camera.main.fieldOfView = defaultFOV + acceleration + zoomRatio + Time.deltaTime;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        float wantedAngle = rotation_vector;
        float wantedHeight = Car.position.y + height;
        float myAngle = transform.eulerAngles.y;
        float myHeight = transform.position.y;
        myAngle = Mathf.LerpAngle(myAngle, wantedAngle, rotationDamping * Time.deltaTime);
        myHeight = Mathf.LerpAngle(myHeight, wantedHeight, rotationDamping * Time.deltaTime);
        Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);
        transform.position = Car.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        Vector3 temp = transform.position;
        temp.y = myHeight;
        transform.position = temp;
        transform.LookAt(Car);
    }
}
