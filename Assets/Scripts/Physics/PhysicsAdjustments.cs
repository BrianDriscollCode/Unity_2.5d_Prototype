using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsAdjustments : MonoBehaviour
{
    [SerializeField] public Player2 Player;
    [SerializeField] public Object[] GravityTriggers;
    public Rigidbody Rigidbody;
    public bool inNormalGravity = true;
    public bool inReverseGravity = false;
    public bool inZeroGravity = false;

    void Start()
    {
        //Set Gravity of Scene
        Physics.gravity = new Vector3(0, -16.0f, 0);
        Rigidbody = Player.GetComponent<Rigidbody>();
        Debug.Log("***Gravity set on Physics Adjustments script***");
    }

    public void SetGravity(string GravityType)
    {
        if (GravityType == "ReverseGravity")
        {
            Physics.gravity = new Vector3(0, 0f, 0);
            Rigidbody.AddForce(new Vector3(0, 3.0f, 0), ForceMode.Force);
        }
        else if (GravityType == "ZeroGravity")
        {
            Physics.gravity = new Vector3(0, 0.0f, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, -16.0f, 0);
        }
    }


}
