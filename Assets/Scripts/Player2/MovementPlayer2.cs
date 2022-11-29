using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer2 : MonoBehaviour
{

    private Rigidbody Player;
    private Vector3 MoveInput = new Vector3(0, 0, 0);
    private int BaseSpeed = 1;
    private float speedModifier = 3.5f; //Slows or speeds up percentage

    private void Start()
    {
        Player = GetComponent<Rigidbody>();
    }

    public void MovePlayer(string InitialState, string AdditionalState, string Direction, bool HasJumped) 
    {
        if (InitialState == "isJumping" && HasJumped == false)
        {
            //Debug.Log("isJumping TEST " + HasJumped);
            Player.AddForce(new Vector3(0, 7.6f, 0), ForceMode.Impulse);
        }
        else if (InitialState == "isJumping" && AdditionalState == "isMoving" && Direction == "Right") 
        {
            if (!HasJumped) 
            {
                Player.AddForce(new Vector3(0, 7.6f, 0), ForceMode.Impulse);
            }
            MoveInput = new Vector3(1, 0, 0);
            speedModifier = 3.5f;
        }
        else if (InitialState == "isJumping" && AdditionalState == "isMoving" && Direction == "Left")
        {
            if (!HasJumped)
            {
                Player.AddForce(new Vector3(0, 7.6f, 0), ForceMode.Impulse);
            }
            MoveInput = new Vector3(-1, 0, 0);
            speedModifier = 3.5f;
        }
        else if (InitialState == "isMoving" && Direction == "Right")
        {
            MoveInput = new Vector3(1, 0, 0);
            speedModifier = 3.5f;
        }
        else if (InitialState == "isMoving" && Direction == "Left")
        {
            MoveInput = new Vector3(-1, 0, 0);
            speedModifier = 3.5f;
        }
        else if (InitialState == "isCrouching" && AdditionalState == "isMoving" && Direction == "Right")
        {
            MoveInput = new Vector3(1, 0, 0);
            speedModifier = 1.5f;
        }
        else if (InitialState == "isCrouching" && AdditionalState == "isMoving" && Direction == "Left")
        {
            MoveInput = new Vector3(-1, 0, 0);
            speedModifier = 1.5f;
        }
        else
        {
            MoveInput = new Vector3(0, 0, 0);
        }

        Player.MovePosition(transform.position + MoveInput * Time.deltaTime * BaseSpeed * speedModifier);
    }

}


