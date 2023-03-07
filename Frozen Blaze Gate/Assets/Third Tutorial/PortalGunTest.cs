using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunTest : MonoBehaviour
{
	public Camera cam;

	private const KeyCode PortalAKey = KeyCode.Mouse0;
	private const KeyCode PortalBKey = KeyCode.Mouse1;

	private GameObject wallPortalA;
	private GameObject wallPortalB;

	public GameObject PrefabPortal;
	private GameObject portalA;
	private GameObject portalB;

	private void Start()
	{
		portalA = null;
		portalB = null;
		wallPortalA = null;
		wallPortalB = null;
	}

	// Update is called once per frame
	void Update()
	{
		//Launch Portal
		if (Input.GetKeyDown(PortalAKey))
			ShootPortalA();
		if (Input.GetKeyDown(PortalBKey))
			ShootPortalB();
	}
	
	// ReSharper disable Unity.PerformanceAnalysis
	private void ShootPortalA()
	{
		RaycastHit rayHit;

		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rayHit))
		{
			//Condition de poser portail : a rectifier
			if (rayHit.transform.gameObject.layer == 7 || rayHit.transform.gameObject.CompareTag("Portal A"))
			{
				//Récupérer le point du raycast
				Vector3 hitPos = rayHit.point;

				//Rotation
				wallPortalA = rayHit.collider.gameObject;
				Quaternion transformRotation = new Quaternion();
				Vector3 transformRotationEulerAngles = transformRotation.eulerAngles;
				if (wallPortalA.CompareTag("FrontWall"))
				{
					transformRotationEulerAngles.x = 0;
					transformRotationEulerAngles.y = 0;
					transformRotationEulerAngles.z = 0;
				}
				else if (wallPortalA.CompareTag("BackWall"))
				{
					transformRotationEulerAngles.x = 0;
					transformRotationEulerAngles.y = 180;
					transformRotationEulerAngles.z = 0;
				}
				else if (wallPortalA.CompareTag("RightWall"))
				{
					transformRotationEulerAngles.x = 0;
					transformRotationEulerAngles.y = 90;
					transformRotationEulerAngles.z = 0;
				}
				else if (wallPortalA.CompareTag("LeftWall"))
				{
					transformRotationEulerAngles.x = 0;
					transformRotationEulerAngles.y = 270;
					transformRotationEulerAngles.z = 0;
				}
				else if (wallPortalA.CompareTag("Ceiling"))
				{
					transformRotationEulerAngles.x = 270;
					transformRotationEulerAngles.y = 0;
					transformRotationEulerAngles.z = 0;
				}
				else if (wallPortalA.CompareTag("InclinedLeftWall"))
				{
					transformRotationEulerAngles.x = 45;
					transformRotationEulerAngles.y = 270;
					transformRotationEulerAngles.z = 0;
				}
				else if (wallPortalA.CompareTag("InclinedRightWall"))
				{
					transformRotationEulerAngles.x = 45;
					transformRotationEulerAngles.y = 90;
					transformRotationEulerAngles.z = 0;
				}
				transformRotation.eulerAngles = transformRotationEulerAngles;
				
				//Actualiser la nouvelle vue après avoir changer la position et la rotation des portails
				if(portalA)
					Destroy(portalA);
				portalA = Instantiate(PrefabPortal);
				portalA.transform.position = hitPos;
				portalA.transform.rotation = transformRotation;
				portalA.tag = "Portal A";
				if (portalB)
				{
					portalB.GetComponent<Portal>().targetPortal = portalA.GetComponent<Portal>();
					portalA.GetComponent<Portal>().targetPortal = portalB.GetComponent<Portal>();
					portalA.transform.Find("Collider").GetComponent<PortalTeleporter>().reciever = portalB.transform;
					if (!portalB.transform.Find("Collider").GetComponent<PortalTeleporter>().reciever)
					{
						portalB.transform.Find("Collider").GetComponent<PortalTeleporter>().reciever = portalA.transform;
					}
				}
			}
		}
	}
	
	// ReSharper disable Unity.PerformanceAnalysis
	private void ShootPortalB()
	{
		RaycastHit rayHit;

		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rayHit))
		{
			//Condition de poser portail : a rectifier
			if (rayHit.transform.gameObject.layer == 7 || rayHit.transform.gameObject.CompareTag("Portal B"))
			{
				//Récupérer le point du raycast
				Vector3 hitPos = rayHit.point;

				//Rotation
				wallPortalB = rayHit.collider.gameObject;
				Quaternion transformRotation = new Quaternion();
				Vector3 transformRotationEulerAngles = transformRotation.eulerAngles;
				if (wallPortalB.CompareTag("FrontWall"))
				{
					transformRotationEulerAngles.x = 0;
					transformRotationEulerAngles.y = 0;
					transformRotationEulerAngles.z = 0;
				}
				else if (wallPortalB.CompareTag("BackWall"))
				{
					transformRotationEulerAngles.x = 0;
					transformRotationEulerAngles.y = 180;
					transformRotationEulerAngles.z = 0;
				}
				else if (wallPortalB.CompareTag("RightWall"))
				{
					transformRotationEulerAngles.x = 0;
					transformRotationEulerAngles.y = 90;
					transformRotationEulerAngles.z = 0;
				}
				else if (wallPortalB.CompareTag("LeftWall"))
				{
					transformRotationEulerAngles.x = 0;
					transformRotationEulerAngles.y = 270;
					transformRotationEulerAngles.z = 0;
				}
				else if (wallPortalB.CompareTag("Ceiling"))
				{
					transformRotationEulerAngles.x = 270;
					transformRotationEulerAngles.y = 0;
					transformRotationEulerAngles.z = 0;
				}
				else if (wallPortalB.CompareTag("InclinedLeftWall"))
				{
					transformRotationEulerAngles.x = 45;
					transformRotationEulerAngles.y = 270;
					transformRotationEulerAngles.z = 0;
				}
				else if (wallPortalB.CompareTag("InclinedRightWall"))
				{
					transformRotationEulerAngles.x = 45;
					transformRotationEulerAngles.y = 90;
					transformRotationEulerAngles.z = 0;
				}
				transformRotation.eulerAngles = transformRotationEulerAngles;
				
				//Actualiser la nouvelle vue après avoir changer la position et la rotation des portails
				if(portalB)
					Destroy(portalB);
				portalB = Instantiate(PrefabPortal);
				portalB.transform.position = hitPos;
				portalB.transform.rotation = transformRotation;
				portalB.tag = "Portal B";
				if (portalA)
				{
					portalB.GetComponent<Portal>().targetPortal = portalA.GetComponent<Portal>();
					portalA.GetComponent<Portal>().targetPortal = portalB.GetComponent<Portal>();
					portalB.transform.Find("Collider").GetComponent<PortalTeleporter>().reciever = portalA.transform;
					if (!portalA.transform.Find("Collider").GetComponent<PortalTeleporter>().reciever)
					{
						portalA.transform.Find("Collider").GetComponent<PortalTeleporter>().reciever = portalB.transform;
					}
				}
				
			}
		}
	}
}
