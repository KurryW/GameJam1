using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemycontroller : MonoBehaviour

{
    //private Rigidbody myRB;
    //public float moveSpeed;

    //public Playermovement thePlayer;

    public float lookRadius = 15f;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //myRB = GetComponent<Rigidbody>();
        //thePlayer = FindObjectOfType<Playermovement>();

        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        //myRB.velocity = (transform.forward * moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(thePlayer.transform.position);

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
