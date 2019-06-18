using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsColision : MonoBehaviour
{
    public ParticleSystem sparks;
    // Start is called before the first frame update
    void Start()
    {
        sparks.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        sparks.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        sparks.Stop();
    }
}
