using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Controller : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed;
    public float tiltAngle;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveLR = Input.GetAxis("Horizontal");
        float moveFB = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        rb.velocity = movement * moveSpeed;

        rb.rotation = Quaternion.Euler(Vector3.forward * moveLR * -tiltAngle);
    }
}
