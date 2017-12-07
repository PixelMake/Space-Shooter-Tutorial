using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Asteroid_Stats
{
    public float maxHealth;
    public float currentHealth;
}

public class Asteroid_Controller : MonoBehaviour
{
    public Asteroid_Stats stats;

    private Quaternion randomRotation;

    private void Start()
    {
        stats.currentHealth = stats.maxHealth;

        randomRotation = Random.rotation;
    }

    private void Update()
    {
        transform.Rotate(randomRotation.eulerAngles * 0.1f * Time.deltaTime);

        if (stats.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
