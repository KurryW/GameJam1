using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
//using UnityEditor.Experimental.GraphView;

public class Player : MonoBehaviour {

	private Animator anim;
	private CharacterController controller;

    public AudioSource footstepsSound;

    public float speed = 600.0f;
	public float turnSpeed = 400.0f;
	public float jumpHeight = 15f;
	
	//jump
	private float yVelocity;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	[SerializeField]
	bool isGrounded;
	float beginJumpTime = 0;

    private void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag== "Ground")
		{
			isGrounded = true;
		}
	}
    private void OnTriggerExit(Collider other)
	{

		if (other.gameObject.tag == "Ground")
		{
			isGrounded = false;
		}
	}

	void Start () 
	{
		controller = GetComponent <CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		Vector3 direction = new Vector3(horizontalInput, 0, 0);
		Vector3 velocity = direction * speed;

		if (Input.GetKey(KeyCode.W))
		{
			anim.SetInteger("AnimationPar", 1);
			footstepsSound.enabled = true;
		}
		else
		{
			anim.SetInteger("AnimationPar", 0);
			footstepsSound.enabled = false;
		}


		moveDirection = transform.forward * Input.GetAxis("Vertical")  * speed;

		if (isGrounded)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				yVelocity = jumpHeight;
				beginJumpTime = Time.time;
				anim.SetInteger("JumpPar", 1);
			}
		}
        else
        {
            yVelocity -= gravity;
            anim.SetInteger("JumpPar", 0);
        }



        float currentAirTime = Time.time - beginJumpTime;

		if (controller.isGrounded == true && (currentAirTime >= 90f && currentAirTime <= 139f))
		{
            SceneManager.LoadScene("GameOver");
        }


		
		velocity.y = yVelocity;
		controller.Move(velocity * Time.deltaTime);

		float turn = Input.GetAxis("Mouse X");
		
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;

	}


}
