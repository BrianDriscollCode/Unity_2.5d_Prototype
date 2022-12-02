using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    private void Start()
    {
        Debug.Log("How to use now?");    
        //Probably for equipping the different weapons

    }

    //THIS IS CODE FROM NE BEING STUPID. Put the weapon in the correct hand and you don't need to
    //rotate and repostion based on state.

    //Rigidbody Rigidbody;
    //public GameObject CurrentWeapon;
    //public GameObject[] WeaponInventory;


    //float RotationX;
    //float RotationY;
    //float RotationZ;
    //Vector3 CurrentRotation;

    //bool NeutralStance = true;
    //bool FiringStance = false;


    ////in attack position
    ////x = -129.1
    ////y = -23.6
    ////z = -50.631

    ////from currentx to new -129.1 - -71.606 = 57.494 (or subtract this to 129)
    ////from current y to new -23.6 - 10.983 = 34.583 (or subtract this from 10)
    ////
    //void Start()
    //{
    //    Debug.Log("Equipment Manager Activated");
    //    Rigidbody = GetComponent<Rigidbody>();
    //    //RotationX = -71.606f;
    //    //RotationY = 10.983f;
    //    //RotationZ = -50.631f;
    //    //RotationX = 0f;
    //    //RotationY = 0f;
    //    //RotationZ = 0f;
    //    //CurrentRotation = new Vector3(RotationX, RotationY, RotationZ);

    //    //CurrentWeapon.transform.Rotate(CurrentRotation);
    //    CurrentWeapon.transform.localScale -= new Vector3(0.4f, 0f, 0f);

    //}

    //public void HandleWeaponPosition(
    //    string type, 
    //    string InitialState, 
    //    string AdditionalState, 
    //    string AttackingState, 
    //    bool HasJumped, 
    //    string? PreviousWeapon
    //)
    //{
    //    //Take current weapon type, set it in the right position for the state
    //    //OR make opague the right weapon

    //    //Also handle rotation

    //    //Also handle sheathing/holstering weapons

    //    if (type == "Pistol" && AttackingState == "isAttacking" && NeutralStance == true)
    //    {
    //        this.NeutralStance = false;
    //        this.FiringStance = true;
    //        Debug.Log("activated pistol rotation");
    //        //CurrentRotation = new Vector3(-40f, 20f, -63f);
    //        CurrentWeapon.transform.localEulerAngles = new Vector3(-57.466f, 158.922f, -258.533f);
    //        CurrentWeapon.transform.localPosition = new Vector3(0.065f, 0.075f, -0.042f);
    //        //CurrentWeapon.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);

    //    }
    //    else if (type == "Pistol" && AttackingState == "isNeutral" && NeutralStance == false)
    //    {
    //        this.NeutralStance = true;
    //        this.FiringStance = false;
    //        Debug.Log("activated pistol de-rotation");
    //        CurrentWeapon.transform.localEulerAngles = new Vector3(-57.466f, 158.922f, -258.533f);
    //        CurrentWeapon.transform.localPosition = new Vector3(0.065f, 0.075f, -0.042f);
    //    }

    //}
}

