using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoMotor : MonoBehaviour
{
    public float walkSpeed;
    public float turnSpeed;
    public float runSpeed;

    public string InputFront;
    public string InputBack;
    public string InputLeft;
    public string InputRight;

    public Vector3 jumpSpeed;
    BoxCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = gameObject.GetComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(InputFront)) {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
        }

        if(Input.GetKey(InputBack)) {
            transform.Translate(0, 0,-(walkSpeed/2) * Time.deltaTime);
        }

        if(Input.GetKey(InputLeft)) {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }

        if(Input.GetKey(InputRight)) {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
    }
}
