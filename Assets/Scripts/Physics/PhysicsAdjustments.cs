using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsAdjustments : MonoBehaviour
{ 
    void Start()
    {
        Physics.gravity = new Vector3(0, -16.0f, 0);
        Debug.Log("***Gravity set on Physics Adjustments script***");
    }

}
