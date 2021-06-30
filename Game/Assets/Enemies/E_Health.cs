using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Health : MonoBehaviour
{
    public int Health = 100;

    public void TakeDamage (int damage) 
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    void Die() 
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (Health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
