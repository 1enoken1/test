using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy1 : MonoBehaviour
{
    public int health;

    int expAmount = 200;

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void Die()
    {
        ExperienceManager.Instance.AddExperience(expAmount);
        Destroy(gameObject);
    }
}
