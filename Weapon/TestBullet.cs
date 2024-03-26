using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject blockPosBat;

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<PlayerStats>().TakeDamage(damage);
            }
            else
            {
                if (hitInfo.collider.CompareTag("BlockedBat"))
                {   
                    hitInfo.collider.GetComponent<StrenghtBat>().TakeDamage(damage);
                    Destroy(gameObject);
                }
            }
            Destroy(gameObject);
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
        lifetime -= 0.01f;

        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
