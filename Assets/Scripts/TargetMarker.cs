using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMarker : MonoBehaviour
{

    public GameObject TheMarker;
    public List<GameObject> points;
    int count = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarAI")
        {
            count = count + 1;
            if (count >= points.Count)
            {
                count = 0;
            }
            TheMarker.transform.localPosition = points[count].transform.position;
            TheMarker.transform.localRotation = points[count].transform.rotation;
            Debug.Log("triger");
        }
    }
}
