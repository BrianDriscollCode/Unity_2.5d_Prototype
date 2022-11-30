using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySpace : MonoBehaviour
{

    public PhysicsAdjustments PhysicsAdjustments;
    // Start is called before the first frame update
    void Start()
    {
        PhysicsAdjustments = GameObject.Find("Level3").GetComponent<PhysicsAdjustments>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider player2)
    {
        
        //Debug.Log("HIGH VOLTAGE");
        PhysicsAdjustments.SetGravity("NormalGravity");

    }
}