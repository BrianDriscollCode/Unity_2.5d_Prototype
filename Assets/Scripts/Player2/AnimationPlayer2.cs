using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer2 : MonoBehaviour
{
    Animator Animator;
    bool JumpPreviousState;
    public Raycast2 Raycast;
    string CurrentState;
    string CurrentAdditionalState;
    Rigidbody Rigidbody;
    string PlayerDirection;
    void Start()
    {
        Animator = GetComponent<Animator>();
        JumpPreviousState = false;
        Raycast = GetComponent<Raycast2>();
        CurrentState = "Idle";
        Animator.CrossFade(CurrentState, 0.05f);
        Rigidbody = GetComponent<Rigidbody>();
        PlayerDirection = "Right";
    }

    public void SetAnimationState(string InitialState, string AdditionalState, string Direction, bool HasJumped)
    {

        if (PlayerDirection != Direction) 
        {
            transform.Rotate(0, 180, 0);
            PlayerDirection = Direction;
        } 

       
        if (CurrentState == InitialState && CurrentAdditionalState == AdditionalState && JumpPreviousState == HasJumped)
        {
            return;
        }


        if (HasJumped)
        {
            //Debug.Log("I AM JUMPING *************");
            Animator.CrossFade("Jumping", 0.05f);

            if (Raycast.IsGrounded())
            {
                Animator.CrossFade("Idle", 0.2f);
            }

        }
        else if (InitialState == "isMoving" && AdditionalState == null && Direction == "Right")
        {
            Animator.CrossFade("Running", 0.05f);
        }
        else if (InitialState == "isMoving" && AdditionalState == null && Direction == "Left")
        {
            Animator.CrossFade("Running", 0.05f);
        }
        else if (InitialState == "isCrouching" && AdditionalState == "isMoving" && Direction == "Right")
        {
            Animator.CrossFade("CrouchWalk", 0.05f);
        }
        else if (InitialState == "isCrouching" && AdditionalState == "isMoving" && Direction == "Left")
        {
            Animator.CrossFade("CrouchWalk", 0.05f);
        }
        else if (InitialState == "isCrouching" && AdditionalState == null)
        {
            Animator.CrossFade("CrouchIdle", 0.02f);
        }
        else if (!HasJumped)
        {
            Animator.CrossFade("Idle", 0.05f);
        }
        else
        {
            Animator.CrossFade("Idle", 0.05f);
        }

        CurrentState = InitialState;
        CurrentAdditionalState = AdditionalState;
        JumpPreviousState = HasJumped;


    }

}
