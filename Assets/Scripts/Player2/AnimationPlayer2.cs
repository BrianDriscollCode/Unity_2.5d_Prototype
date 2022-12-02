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
    string CurrentAttackingState;
    bool InAttackState;
    Rigidbody Rigidbody;
    string PlayerDirection;
    void Start()
    {
        Animator = GetComponent<Animator>();
        Raycast = GetComponent<Raycast2>();
        Rigidbody = GetComponent<Rigidbody>();
        JumpPreviousState = false;
        InAttackState = false;
        CurrentState = "Idle";
        Animator.CrossFade(CurrentState, 0.05f);
        PlayerDirection = "Right";
    }

    //** FIX ORDER AND THEN ALSO FIX ORDER FOR Player2 function calls for both animation and movement script
    public void SetAnimationState(string InitialState, string AdditionalState, string Direction, bool HasJumped, string isAttacking)
    {
        //Debug.Log("Initial State:" + InitialState + " || " + "Additional State:" + AdditionalState + " || " + "Direction:" + Direction + " || " + "HasJumped:" + HasJumped + " || " + "isAttacking State:" + isAttacking);
        
        if (PlayerDirection != Direction)
        {
            transform.Rotate(0, 180, 0);
            PlayerDirection = Direction;
        }

        //Don't change animations if ALL states match ALL previous states
        if (
            CurrentState == InitialState
            && CurrentAdditionalState == AdditionalState
            && JumpPreviousState == HasJumped
            && CurrentAttackingState == isAttacking
           )
        {
            //Debug.Log("***SAME STATE***");
            return;
        }


        //Initiating Attack Stance
        if (isAttacking == "isAttacking")
        {
            InAttackState = true;
        }

        //Deactivating Attack Stanceddd
        if (isAttacking == "isNeutral")
        {
            InAttackState = false;
        }

        //Debug.Log(InitialState + "Initial State");

        //***Attacking Stance Animations
        if (InAttackState == true && InitialState == "isIdle" && AdditionalState == null && HasJumped == false)
        {
            //Debug.Log("***Idle Pistol***");
            Animator.CrossFade("PistolIdle", 0.02f);
        }
        else if (InAttackState == true && InitialState == "isMoving" && AdditionalState == null && HasJumped == false)
        {
           
            //Debug.Log("***Run Pistol***");
            Animator.CrossFade("PistolRun", 0.02f);
        }
        


        //IF IN ATTACK STATE NEVER go beyond this point
        if (InAttackState)
        {

            CurrentState = InitialState;
            CurrentAdditionalState = AdditionalState;
            JumpPreviousState = HasJumped;
            CurrentAttackingState = isAttacking;

            return;
        }

        //***Normal Stance Animations

        if (HasJumped)
        {
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
        CurrentAttackingState = isAttacking;


    }

}
