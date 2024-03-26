using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrenghtBat : MonoBehaviour
{
    public int health;

    private void Update()
    {  
        if (health <= 0)
        {
            Destroy(gameObject);
        }      
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}