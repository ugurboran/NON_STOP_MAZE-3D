
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {

    public float Velocity;
    [Space]

	public float InputX;
	public float InputZ;
	public Vector3 desiredMoveDirection;
	
	public Vector3 moveDirection;
	public float jumpspeed = 5;
	
	public bool blockRotationPlayer;
	public float desiredRotationSpeed = 0.5f;
	public Animator anim;
	public float Speed;
	public float allowPlayerRotation = 0.1f;
	public Camera cam;
	public CharacterController controller;
	public bool isGrounded;

	

	[Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0,1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    public float verticalVel;
    private Vector3 moveVector;

	Quaternion quad;
	Vector2 tempRotation;

	/*
	Rigidbody rb;

	public Vector3 jump;
	public float jumpForce = 2.0f;

	*/

	// Use this for initialization
	void Start () {

		/*
		rb = GetComponent<Rigidbody>();
		jump = new Vector3(0.0f, 2.0f, 0.0f);
		*/

		Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = true;

		anim = this.GetComponent<Animator> ();
		cam = Camera.main;
		controller = this.GetComponent<CharacterController> ();

		//quad = transform.rotation;
		//tempRotation = new Vector2(cam.transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y);
	}
	
	// Update is called once per frame
	void Update () {
		InputMagnitude ();

        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            verticalVel -= 0;

			//Feed moveDirection with input.
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);



			//Multiply it by speed.
			//moveDirection *= 100;
			//Jumping
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpspeed;
				GameObject.Find("Run_sound").GetComponent<AudioSource>().Play();
		}
        else
        {
            verticalVel -= 1;
			GameObject.Find("Whistle_sound").GetComponent<AudioSource>().Play();
        }
		

		//moveVector = new Vector3(0, verticalVel * .2f * Time.deltaTime, 0);

		//Applying gravity to the controller
		moveDirection.y -= 10 * Time.deltaTime;
		//Making the character move
		controller.Move(moveDirection * Time.deltaTime);
		//controller.Move(moveVector);

		
		float mouseX = Input.GetAxis("Mouse X");
		mouseX *= desiredRotationSpeed;


		float mouseY = Input.GetAxis("Mouse Y");
		mouseY *= desiredRotationSpeed;

		float tempValue = tempRotation.x + mouseY;
		Mathf.Clamp(tempValue, -60, 60);

		//if(Mathf.Abs(tempValue) < 40)
        //{
		tempRotation = new Vector2(tempRotation.x + mouseY, tempRotation.y + mouseX);
		cam.transform.localRotation = Quaternion.Euler(-tempRotation.x, tempRotation.y , 0);
		//}



		/*
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{

			rb.AddForce(jump * jumpForce, ForceMode.Impulse);
			isGrounded = false;
		}
		*/

		}

    void PlayerMoveAndRotation() {
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		var camera = Camera.main;
		var forward = cam.transform.forward;
		var right = cam.transform.right;


		forward.y = 0f;
		right.y = 0f;

		forward.Normalize ();
		right.Normalize ();

		desiredMoveDirection = forward * InputZ + right * InputX;

		if (blockRotationPlayer == false) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationSpeed);
            //GameObject.Find("Run_sound").GetComponent<AudioSource>().Play();
			controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);
			
		}
	}

    public void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), desiredRotationSpeed);
    }

    public void RotateToCamera(Transform t)
    {

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        desiredMoveDirection = forward;

        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }

	void InputMagnitude() {
		//Calculate Input Vectors
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		//anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
		//anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

		//Calculate the Input Magnitude
		Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        //Physically move player

		if (Speed > allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StartAnimTime, Time.deltaTime);
			PlayerMoveAndRotation ();
		} else if (Speed < allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, StopAnimTime, Time.deltaTime);
		}
	}

    /*private void OnCollisionEnter(Collision collision)
    {
		if(collision.gameObject.name.Equals("Cube (41)"))
        {
			print("crash");
        }
    }
	*/
}
