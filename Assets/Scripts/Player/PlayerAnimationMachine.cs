using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerAnimationMachine : MonoBehaviour
{
    Animator animator;
    private string currentState;
    public bool canPunch = true;
    public bool canJump = true;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = "idle";
    }

    public void changeAnimationState(string newState)
    {

        Debug.Log(animator.updateMode);
        if (currentState == newState) 
        {
            return;
        }

        if (newState == "Idle" && Input.GetKey("a"))
        {
            return;
        }
        else if (newState == "Idle" && Input.GetKey("d"))
        {
            return;
        }
        else if (newState == "Idle" && currentState == "CrouchIdle") 
        {
            return;
        }
        else if (newState == "Idle" && currentState == "Jumping" && canJump == true) 
        {
            return;
        }
        else if (newState == "Idle" && currentState == "PunchingStraight" && canPunch == true) 
        {
            animator.CrossFade(currentState, 0.05f);
            return;
        }

        animator.CrossFade(newState, 0.05f);
        //animator.Play(newState);
        currentState = newState;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
