using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraTuto : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    public GameObject wallPortalA { get; set; }
    public GameObject wallPortalB { get; set; }
    
    // Update is called once per frame
    void LateUpdate()
    {
        if (otherPortal)
        {
            Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
            playerOffsetFromPortal.y += 1;
            transform.position = portal.position - playerOffsetFromPortal;
        
            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

            if (angularDifferenceBetweenPortalRotations == 0)
            {
                if (wallPortalA)
                {
                    if (wallPortalA.layer == 13)
                    {
                        Quaternion portalRotationalDifference =
                            Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
                        Vector3 newCameraDirection = portalRotationalDifference * -playerCamera.forward;
                        transform.rotation = Quaternion.LookRotation(new Vector3(newCameraDirection.x, -newCameraDirection.y, newCameraDirection.z), Vector3.up);
                    }
                    else
                    {
                        Quaternion portalRotationalDifference =
                            Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
                        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
                        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
                    }
                }
            }
        }
    }
}
