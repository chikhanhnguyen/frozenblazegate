using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
	public float sensX;
	public float sensY;

	public Transform orientation;
	
	float xRotation;
	float yRotation;

	// Start is called before the first frame update
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		
	}

	// Update is called once per frame
	void LateUpdate()
	{
		//Get mouse input

		float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
		float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

		yRotation += mouseX;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		//Rotate cam and orientation
		transform.rotation = Quaternion.Euler(xRotation, yRotation + transform.parent.rotation.eulerAngles.y, 0);
		orientation.rotation = Quaternion.Euler(0, yRotation + transform.parent.rotation.eulerAngles.y, 0);
	}
}
