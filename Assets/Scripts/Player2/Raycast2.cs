using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2 : MonoBehaviour
{


	// Update is called once per frame
	void Update()
	{

	}

	public bool IsGrounded()
	{
		bool GroundTouched;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, 0.1f))
		{
			//Debug.Log("ON FLOOR!");
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
			GroundTouched = true;
		}
		else
		{
			//Debug.Log("not on floor...");
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.green);
			GroundTouched = false;
		}

		return GroundTouched;
	}
}
