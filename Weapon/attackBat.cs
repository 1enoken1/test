using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackBat : MonoBehaviour
{
   public Transform attackPosBat;
   public LayerMask enemy;
   public float attackRange;
   public int damage;
   public LayerMask whatIsSolid;
   public Animator anim;
   private float timeBat;
   public float startTimeBat;

  void Update()
  {  
     // startTimeBat -= Time.deltaTime;
      if (startTimeBat <= 0f)
      {
          //startTimeBat = 0;
          if (Input.GetMouseButton(0))
          {
          
              anim.SetBool("AttackBat", true);

             //startTimeBat = 2f;
              
          }
          else
          {
              anim.SetBool("AttackBat", false); 
             // timeBat -= Time.deltaTime;
           // anim.SetBool("Move", true);
          }      
      }       
  }

  public void OnAttackBat()
  { 
      startTimeBat = 0f;
      Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPosBat.position, attackRange, enemy);
      for (int i = 0; i < enemies.Length; i++)
      {
          enemies[i].GetComponent<enemy1>().TakeDamage(damage);    
      }      
      PlayerStats.instance.UseStamina(20);
  }

  private void OnDrawGizmosSelected()
  {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(attackPosBat.position, attackRange);
  }
}
