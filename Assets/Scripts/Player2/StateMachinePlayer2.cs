using System.Collections;
using System.Collections.Generic;
using PlayerDataPackages;
using UnityEngine;

public class StateMachinePlayer2 : MonoBehaviour
{
    string[]? CurrentState = { "isIdle", null };
    CharacterStateTypes StateTypes = new CharacterStateTypes();

    public string[] CheckState(PassToStateMachine CharacterData)

    {
        string type = CharacterData.InputType;
        string value = CharacterData.InputValue;

        if (type == "UserInput")
        {
            switch (value)
            {
                //right
                case "wd": 
                    CurrentState[0] = StateTypes.isJumping; 
                    CurrentState[1] = StateTypes.isMoving; 
                    break;
                //left
                case "wa":
                    CurrentState[0] = StateTypes.isJumping; 
                    CurrentState[1] = StateTypes.isMoving;
                    break;
                case "w":
                    CurrentState[0] = StateTypes.isJumping;
                    CurrentState[1] = null; 
                    break;
                //right
                case "sd":
                    CurrentState[0] = StateTypes.isCrouching;
                    CurrentState[1] = StateTypes.isMoving;
                    break;
                //left
                case "sa":
                    CurrentState[0] = StateTypes.isCrouching;
                    CurrentState[1] = StateTypes.isMoving;
                    break;
                case "s":
                    CurrentState[0] = StateTypes.isCrouching; 
                    CurrentState[1] = null;
                    break;
                //right
                case "d":
                    CurrentState[0] = StateTypes.isMoving;
                    CurrentState[1] = null;
                    break;
                //left
                case "a":
                    CurrentState[0] = StateTypes.isMoving;
                    CurrentState[1] = null;
                    break;
                default:
                    CurrentState[0] = StateTypes.isIdle;
                    CurrentState[1] = null;
                    break;
            }
        }

        return CurrentState;
    }
}
