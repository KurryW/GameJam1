using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDMG : MonoBehaviour
{
    public Vector3 enterPos;
    public Vector3 exitPos;

    public int FallValue = 10;

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Ground"))
        {
            enterPos = transform.position;
            Debug.Log("begin positie");
            
            if(exitPos.y - enterPos.y > FallValue)
            {
                PlayerHealth.currentHealth -= 5 * exitPos.y - enterPos.y;
            }
        }

        
    }

    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Ground"))
        {
            exitPos = transform.position;
        }
    }
}
