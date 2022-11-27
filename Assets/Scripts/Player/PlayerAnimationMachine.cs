using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationMachine : MonoBehaviour
{
    Animator animator;
    private string currentState;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        currentState = "idle";
    }

    public void changeAnimationState(string newState)
    {

        if (currentState == newState) 
        {
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
