using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public float BulletSpeed;

    public float damage;

    private void Start()
    {
        transform.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;
    }

    private void Update()
    {
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            collision.transform.GetComponent<Asteroid_Controller>().stats.currentHealth -= damage;
            Destroy(gameObject);
        }
    }
}
