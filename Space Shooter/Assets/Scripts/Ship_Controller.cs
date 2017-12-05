using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Controller : MonoBehaviour
{
    Rigidbody rb;

    public GameObject bullet;
    public Transform[] firePoints = new Transform[2];
    public float fireRate;
    private float nextFire;

    public float moveSpeed;
    public float tiltAngle;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();

        nextFire = 1 / fireRate;
    }
    
    private void FixedUpdate()
    {
        float moveLR = Input.GetAxis("Horizontal");
        float moveFB = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        rb.velocity = movement * moveSpeed;

        rb.rotation = Quaternion.Euler(Vector3.forward * moveLR * -tiltAngle);

        bool fireButton = Input.GetButton("Fire1");

        Collider[] shipColliders = transform.GetComponentsInChildren<Collider>();

        if (fireButton)
        {
            nextFire -= Time.deltaTime;
            if (nextFire <= 0)
            {
                for(int i = 0; i < 2; i++)
                {
                    GameObject bulletClone = Instantiate(bullet, firePoints[i].position, Quaternion.Euler(0, 0, 0));

                    for(int x = 0; x < shipColliders.Length; x++)
                    {
                        Physics.IgnoreCollision(bulletClone.transform.GetComponent<Collider>(), shipColliders[x]);
                    }
                }
                nextFire = 1 / fireRate;
            }
        }
    }
}
