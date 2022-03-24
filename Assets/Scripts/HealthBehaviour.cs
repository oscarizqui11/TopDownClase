using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBehaviour : MonoBehaviour
{
    public int maxHp;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (health - damage > 0)
        {
            health = health - damage;
        }
        else
        {
            health = 0;
            Destroy(gameObject);
        }

    }
}
