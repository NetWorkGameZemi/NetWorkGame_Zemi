using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float PU_power;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        var body = other.gameObject.GetComponent<Rigidbody>();
        if(body != null)
        {
            Vector3 UP = transform.up * PU_power;
            body.AddForce(UP, ForceMode.Acceleration);
        }
    }
}