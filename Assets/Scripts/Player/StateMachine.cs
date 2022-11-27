using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    string playerState;
    
    // Start is called before the first frame update
    void Start()
    {
        playerState = "idle";
    }

    public string getCurrentState()
    {
        return playerState;
    }

    public string checkCurrentState(string action)
    {

        switch(action)
        {
            //For now I want left and right for debugging purposes
            //but this will be extrapolated into just "running" 
            //in the future
            case ("punching"):
                Debug.Log("we are punching! - STATE MACHINE");
                playerState = "punching";
                break;
            case "runLeft":
                playerState = "runningLeft";
                break;
            case "runRight":
                playerState = "runningRight";
                break;
            case "jump":
                playerState = "jumping";
                break;
            case "walk":
                playerState = "walking";
                break;
            case "sprint":
                playerState = "sprint";
                break;
            case "crouch":
                playerState = "crouching";
                break;
            default:
                playerState = "idle";
                break;
        }

        return playerState;
    }
}

