using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

	
    // Update is called once per frame
    void Update()
    {

	}

	public bool isGrounded()
    {
		bool groundTouched;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, 0.1f))
		{
			//Debug.Log("HIT!");
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
			groundTouched = true;
		}
		else
		{
			//Debug.Log("No hit...");
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.green);
			groundTouched = false;
		}

		return groundTouched;
    }
}
