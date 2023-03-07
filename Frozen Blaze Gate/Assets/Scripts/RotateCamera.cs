using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform playerCamera;
    public GameObject portal;
    public GameObject otherportal;

    void Update()
    {
        Vector3 playerOffsetFromPortal = (playerCamera.transform.position - otherportal.transform.position);
        playerOffsetFromPortal.z /= 10;
        playerOffsetFromPortal.z += 10;
        playerOffsetFromPortal.y = otherportal.transform.position.y - 3;
        playerOffsetFromPortal.x /= 1.5f;
        transform.position = portal.transform.position + playerOffsetFromPortal;
        
        float angle = Quaternion.Angle(portal.transform.rotation, otherportal.transform.rotation);
        Quaternion angleQuaternion = Quaternion.AngleAxis(angle, Vector3.down);
        Vector3 dir =  angleQuaternion * -playerCamera.forward;
        dir.x /= -(playerCamera.transform.position.z - otherportal.transform.position.z);
        dir.y /= -(playerCamera.transform.position.z - otherportal.transform.position.z);
        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, -dir.y,dir.z), Vector3.up);
        Quaternion angleCamera = transform.rotation;
        var angleCameraEulerAngles = angleCamera.eulerAngles;
        angleCameraEulerAngles.y += 18;
        angleCamera.eulerAngles = angleCameraEulerAngles;
        transform.rotation = angleCamera;
    }
}
