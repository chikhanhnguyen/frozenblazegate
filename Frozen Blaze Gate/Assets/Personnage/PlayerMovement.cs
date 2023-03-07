using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class PlayerMovement : MonoBehaviour
{

	[Header("Movement")]
	public float moveSpeed;
	public float groundDrag;
	public float jumpForce;
	public float jumpCooldown;
	public float airMultiplier;
	bool readyToJump;

	[Header("Ground Check")]
	public float playerHeight;
	public LayerMask whatIsGround;
	bool grounded;

	public Transform orientation;

	public float horizontalInput;
	public float verticalInput;

	Vector3 moveDirection;

	Rigidbody rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		readyToJump = true;
	}
	
	public void OnJump()
	{
		if (readyToJump && grounded)
		{
			readyToJump = false;
			Jump();
			Invoke(nameof(ResetJump), jumpCooldown);
		}
	}

	public void OnHorizontal(InputValue val)
	{
		horizontalInput = val.Get<float>();
	}
	
	public void OnVertical(InputValue val)
	{
		verticalInput = val.Get<float>();
	}

	private void MovePlayer()
	{
		//calculate movement direction
		moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

		//on ground
		if(grounded) {
			rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
		} else if(!grounded) {
			rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
		}
	}

	private void SpeedControl()
	{
		Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

		//limit velocity if needed
		if(flatVel.magnitude > moveSpeed) {
			Vector3 limitedVel = flatVel.normalized * moveSpeed;
			rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
		}
	}

	private void Jump() {
		//reset y velocity
		rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
		rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
	}

	private void ResetJump() {
		readyToJump = true;
	}

	// Update is called once per frame
	void Update()
	{
		//grounded
		grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
		SpeedControl();

		//handle 
		if(grounded) {
			rb.drag = groundDrag;
		} else {
			rb.drag = 0;
		}
	}

	void FixedUpdate()
	{
		MovePlayer();
	}
}
