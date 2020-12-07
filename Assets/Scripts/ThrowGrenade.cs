using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public Camera mainCamera;

    public float throwForce = 10f;
    public GameObject grenadePrefab;

    public GameObject player;

    void Update()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

		//Rotate Object to Mouse Position
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButtonDown(1) && Player.grenadeNumber > 0)
        {
            Player.grenadeNumber--;
            Throw();
        }
    }

	/// <summary>
	/// Initializes throwing the grenade
	/// </summary>
	void Throw()
    {
        GameObject grenade = Instantiate(grenadePrefab) as GameObject;
        grenade.transform.position = transform.position + player.transform.forward;
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.velocity = player.transform.forward * throwForce;
    }
}
