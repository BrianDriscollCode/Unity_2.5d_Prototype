using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravitySpace : MonoBehaviour
{
    public PhysicsAdjustments PhysicsAdjustments;
    void Start()
    {
        PhysicsAdjustments = GameObject.Find("Level3").GetComponent<PhysicsAdjustments>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider player2) {

        //***** CALL PHYSICS ADJUSTMENT AND SET GRAVITY
        ///Debug.Log("HIGH VOLTAGE");
        PhysicsAdjustments.SetGravity("ReverseGravity");

    }
}
