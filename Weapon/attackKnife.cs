using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackKnife : MonoBehaviour
{
   public Transform attackPosKnife;
   public LayerMask enemy;
   public float attackRange;
   public int damage;
   public LayerMask whatIsSolid;
   public Animator anim;

  void Update()
  {  
        if (Input.GetMouseButton(1))
        {
            anim.SetBool("AttackKnife", true);
        }
        else
        {
            anim.SetBool("AttackKnife", false); 
           // anim.SetBool("Move", true);
        }   
  }

  public void OnAttackKnife()
  { 
      Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPosKnife.position, attackRange, enemy);
      for (int i = 0; i < enemies.Length; i++)
      {
          enemies[i].GetComponent<enemy1>().TakeDamage(damage);    
      }       
  }

  private void OnDrawGizmosSelected()
  {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(attackPosKnife.position, attackRange);
  }
}
