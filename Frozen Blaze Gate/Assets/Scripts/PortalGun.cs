using System;
using Unity.VisualScripting;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
	public Camera cam;
	/*public GameObject prefabPortalA;
	public GameObject prefabPortalB;*/
	public GameObject portalA;
	public GameObject portalB;
	private const KeyCode PortalAKey = KeyCode.Mouse0;
	private const KeyCode PortalBKey = KeyCode.Mouse1;
	public float sizePortal;
	public float sizeWallStart;

	// Update is called once per frame
	void Update()
	{
		//Launch Portal
		if (Input.GetKeyDown(PortalAKey))
			ShootPortalA();
		if (Input.GetKeyDown(PortalBKey))
			ShootPortalB();
	}
	
	private void ShootPortalA()
	{
		RaycastHit rayHit;

		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rayHit))
		{
			//Condition de poser portail : a rectifier
			if (rayHit.transform.gameObject.layer == 7 || rayHit.transform.gameObject.layer == 11 || rayHit.transform.gameObject.layer == 12 || rayHit.transform.gameObject.layer == 13)
			{
				/*
				if (wallPortalA)
				{
					if (wallPortalA.layer == 13)
						wallPortalA.layer = 12;
					else
						wallPortalA.layer = 7;
				}
				//Masquer le wall sur lequel est le portail
				wallPortalA = rayHit.collider.gameObject;
				if(wallPortalA.layer == 12 || wallPortalA.layer == 13)
					rayHit.transform.gameObject.layer = 13;
				else
					rayHit.transform.gameObject.layer = 11;
				
				//Creer le portail
				
				portalA = Instantiate(prefabPortalA);
				GameObject.Find("Camera A").GetComponent<PortalCameraTuto>().playerCamera = cam.transform;
				GameObject.Find("Camera A").GetComponent<PortalCameraTuto>().portal = GameObject.Find("Portal A").transform;
				if (GameObject.FindGameObjectsWithTag("Portal B").Length == 0)
				{
					GameObject.Find("Camera A").GetComponent<PortalCameraTuto>().otherPortal = null;
				}
				else
				{
					GameObject.Find("Camera A").GetComponent<PortalCameraTuto>().otherPortal = GameObject.Find("Portal B").transform;
				}
				Debug.Log(portalA.transform.Find("Camera A").GetComponent<PortalCameraTuto>().wallPortalA);
				
				//Set le mur pour le rendre invisible
				portalA.transform.parent.Find("Camera A").GetComponent<PortalCameraTuto>().wallPortalA = wallPortalA;*/
				
				//Récupérer le point du raycast
				Vector3 hitPos = rayHit.point;
				
				//Rotation
				GameObject hit = rayHit.transform.gameObject;
				portalA.transform.rotation = hit.transform.rotation;

				//Rotation du mur
				float angleX = portalA.transform.rotation.eulerAngles.x;
				float angleY = portalA.transform.rotation.eulerAngles.y;
				float angleZ = portalA.transform.rotation.eulerAngles.z;

				//Position

				//Si le mur est droit
				if ((angleX == 0 && angleY == 0 && angleZ == 0) || (angleX == 90 && angleY == 0 && angleZ == 0) ||
				    (angleX == 0 && angleY == 90 && angleZ == 0))
				{
					float x = hitPos.x % 5;
					float y = hitPos.y % 5;
					float z = hitPos.z % 5;

					//Si rotation mur y : changePosY et changePosZ
					//Si rotation mur x : changePosZ et changePosX
					//Si aucune rotation : changePosX et changePosY

					//Changer la position de x si necessaire
					if ((angleX == 0 && angleY == 0 && angleZ == 0) || (angleX == 90 && angleY == 0 && angleZ == 0))
					{
						if (x <= -2.5)
						{
							hitPos.x = hitPos.x - x - sizePortal + sizeWallStart;
						}
						else if (x <= 2.5)
						{
							hitPos.x = hitPos.x - x + sizeWallStart;
						}
						else
						{
							hitPos.x = hitPos.x - x + sizePortal + sizeWallStart;
						}
					}

					//Changer la position de y si necessaire
					if ((angleX == 0 && angleY == 0 && angleZ == 0) || (angleX == 0 && angleY == 90 && angleZ == 0))
					{
						if (y <= -2.5)
						{
							hitPos.y = hitPos.y - y - sizePortal + sizeWallStart;
						}
						else if (y <= 2.5)
						{
							hitPos.y = hitPos.y - y + sizeWallStart;
						}
						else
						{
							hitPos.y = hitPos.y - y + sizePortal + sizeWallStart;
						}
					}

					//Changer la position de z si necessaire
					if ((angleX == 90 && angleY == 0 && angleZ == 0) || (angleX == 0 && angleY == 90 && angleZ == 0))
					{
						if (z <= -2.5)
						{
							hitPos.z = hitPos.z - z - sizePortal + sizeWallStart;
						}
						else if (z <= 2.5)
						{
							hitPos.z = hitPos.z - z + sizeWallStart;
						}
						else
						{
							hitPos.z = hitPos.z - z + sizePortal + sizeWallStart;
						}
					}
					/*
					if (angleX == 90 && angleY == 0 && angleZ == 0)
					{
						Transform portal = portalA.transform;
						var portalLocalScale = portal.localScale;
						portalLocalScale.x = 1;
						portalLocalScale.y = 3.5f;
						portal.localScale = portalLocalScale;
						portalA.transform.localScale = portalLocalScale;
					}
					else if (angleX == 0 && angleY == 90 && angleZ == 0)
					{
						Transform portal = portalA.transform;
						var portalLocalScale = portal.localScale;
						portalLocalScale.x = 3.5f;
						portalLocalScale.y = 1;
						portal.localScale = portalLocalScale;
						portalA.transform.localScale = portalLocalScale;
					}
					else
					{
						Transform portal = portalA.transform;
						var portalLocalScale = portal.localScale;
						portalLocalScale.x = 1;
						portalLocalScale.y = 1;
						portal.localScale = portalLocalScale;
						portalA.transform.localScale = portalLocalScale;
					}*/

					//Changer la position du portail
					portalA.transform.position = hitPos;
				}

				//Si le mur est penche
				else
				{
					Vector3 positionWall = rayHit.transform.position;
					positionWall.y += 1;
					portalA.transform.position = positionWall;
				}
			}
		}
	}
	
	private void ShootPortalB()
	{
		RaycastHit rayHit;

		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rayHit))
		{
			//Condition de poser portail : a rectifier
			if (rayHit.transform.gameObject.layer == 7 || rayHit.transform.gameObject.layer == 11 || rayHit.transform.gameObject.layer == 12 || rayHit.transform.gameObject.layer == 13)
			{
				/*
				if (wallPortalB)
				{
					if (wallPortalB.layer == 13)
						wallPortalB.layer = 11;
					else
						wallPortalB.layer = 7;
				}
				//Masquer le wall du portail
				wallPortalB = rayHit.collider.gameObject;
				if(wallPortalB.layer == 11 || wallPortalB.layer == 13)
					rayHit.transform.gameObject.layer = 13;
				else
					rayHit.transform.gameObject.layer = 12;
				/*
				Instantiate(portalB);
				GameObject.Find("Camera B").GetComponent<PortalCameraTuto>().playerCamera = cam.transform;
				GameObject.Find("Camera B").GetComponent<PortalCameraTuto>().portal = GameObject.Find("Portal B").transform;
				if (!portalA)
				{
					GameObject.Find("Camera A").GetComponent<PortalCameraTuto>().otherPortal = null;
				}
				else
				{
					GameObject.Find("Camera B").GetComponent<PortalCameraTuto>().otherPortal = GameObject.Find("Portal A").transform;
				}
				
				portalB.transform.parent.Find("Camera B").GetComponent<PortalCameraTuto>().wallPortalB = wallPortalB;*/
				//Récupérer le point du raycast
				Vector3 hitPos = rayHit.point;

				//Rotation
				GameObject hit = rayHit.transform.gameObject;
				portalB.transform.rotation = hit.transform.rotation;

				//Rotation du mur
				float angleX = portalB.transform.rotation.eulerAngles.x;
				float angleY = portalB.transform.rotation.eulerAngles.y;
				float angleZ = portalB.transform.rotation.eulerAngles.z;

				//Position

				//Si le mur est droit
				if((angleX == 0 && angleY == 0 && angleZ == 0) || (angleX == 90 && angleY == 0 && angleZ == 0) || (angleX == 0 && angleY == 90 && angleZ == 0))
				{
					float x = hitPos.x % 5;
					float y = hitPos.y % 5;
					float z = hitPos.z % 5;

					//Si rotation mur y : changePosY et changePosZ
					//Si rotation mur x : changePosZ et changePosX
					//Si aucune rotation : changePosX et changePosY

					//Changer la position de x si necessaire
					if((angleX == 0 && angleY == 0 && angleZ == 0) || (angleX == 90 && angleY == 0 && angleZ == 0))
					{
						if (x <= -2.5)
						{
							hitPos.x = hitPos.x - x - sizePortal + sizeWallStart;
						}
						else if (x <= 2.5)
						{
							hitPos.x = hitPos.x - x + sizeWallStart;
						}
						else
						{
							hitPos.x = hitPos.x - x + sizePortal + sizeWallStart;
						}
					}

					//Changer la position de y si necessaire
					if((angleX == 0 && angleY == 0 && angleZ == 0) || (angleX == 0 && angleY == 90 && angleZ == 0))
					{
						if (y <= -2.5)
						{
							hitPos.y = hitPos.y - y - sizePortal + sizeWallStart;
						}
						else if (y <= 2.5)
						{
							hitPos.y = hitPos.y - y + sizeWallStart;
						}
						else
						{
							hitPos.y = hitPos.y - y + sizePortal + sizeWallStart;
						}
					}
/*
					//Changer la position de z si necessaire
					if((angleX == 90 && angleY == 0 && angleZ == 0) || (angleX == 0 && angleY == 90 && angleZ == 0))
					{
						if (z <= -2.5)
						{
							hitPos.z = hitPos.z - z - sizePortal + sizeWallStart;
						}
						else if (z <= 2.5)
						{
							hitPos.z = hitPos.z - z + sizeWallStart;
						}
						else
						{
							hitPos.z = hitPos.z - z + sizePortal + sizeWallStart;
						}
					}
					
					if (angleX == 90 && angleY == 0 && angleZ == 0)
					{
						Transform portal = portalB.transform;
						var portalLocalScale = portal.localScale;
						portalLocalScale.x = 1;
						portalLocalScale.y = 3.5f;
						portal.localScale = portalLocalScale;
						portalB.transform.localScale = portalLocalScale;
					}
					else if (angleX == 0 && angleY == 90 && angleZ == 0)
					{
						Transform portal = portalB.transform;
						var portalLocalScale = portal.localScale;
						portalLocalScale.x = 3.5f;
						portalLocalScale.y = 1;
						portal.localScale = portalLocalScale;
						portalB.transform.localScale = portalLocalScale;
					}
					else
					{
						Transform portal = portalB.transform;
						var portalLocalScale = portal.localScale;
						portalLocalScale.x = 1;
						portalLocalScale.y = 1;
						portal.localScale = portalLocalScale;
						portalB.transform.localScale = portalLocalScale;
					}

					//Changer la position du portail*/
					portalB.transform.position = hitPos;
				}

				//Si le mur est penche
				else
				{
					Vector3 positionWall = rayHit.transform.position;
					positionWall.y += 1;
					portalB.transform.position = positionWall;
				}
			}
		}
	}
}
