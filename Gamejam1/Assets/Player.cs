using UnityEngine;
using System.Collections;
//using UnityEditor.Experimental.GraphView;

public class Player : MonoBehaviour {

	//private Animator anim;
	private CharacterController controller;

    public AudioSource footstepsSound;
    public AudioSource waterSound;

    public float speed = 600.0f;
	public float turnSpeed = 400.0f;
	public float jumpHeight = 15f;
	
	//jump
	private float yVelocity;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;


    private void OnTriggerEnter(Collider other)
    {
		if (other.CompareTag("Water"))
		{
			waterSound.Play();
		}
		
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            waterSound.Stop();
        }
    }

    void Start () 
	{
		controller = GetComponent <CharacterController>();
		//anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		Vector3 direction = new Vector3(horizontalInput, 0, 0);
		Vector3 velocity = direction * speed;

		//if (Input.GetKey("w"))
		//{
		//	anim.SetInteger("AnimationPar", 1);
  //          footstepsSound.enabled = true;
  //      }
		//else
		//{
		//	anim.SetInteger("AnimationPar", 0);
  //          footstepsSound.enabled = false;
  //      }

		
		moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			yVelocity = jumpHeight;
            //anim.SetInteger("JumpPar", 1);
			
		}
		else
		{
			yVelocity -= gravity;
            //anim.SetInteger("JumpPar", 0);
			
        }
		
		velocity.y = yVelocity;
		controller.Move(velocity * Time.deltaTime);

		float turn = Input.GetAxis("Horizontal");
		
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;

	}
}
