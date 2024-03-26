using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockedBat : MonoBehaviour
{
    public GameObject blockPosBat;
    public LayerMask whatIsSolid;
    public Animator anim;

    private void Update()
    {  
        if (Input.GetMouseButton(1))
        {
            blockPosBat.gameObject.SetActive(true); 
        }
        else
        {
            blockPosBat.gameObject.SetActive(false); 
        }     
    } 
}
