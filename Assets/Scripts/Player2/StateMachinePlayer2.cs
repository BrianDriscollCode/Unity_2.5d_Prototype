using System.Collections;
using System.Collections.Generic;
using PlayerDataPackages;
using UnityEngine;

public class StateMachinePlayer2 : MonoBehaviour
{
    string[]? CurrentState = { "isIdle", null, null };
    PlayerDataPackages.CharacterStateTypes StateTypes = new PlayerDataPackages.CharacterStateTypes();

    // @params CharacterData
    //      position 0: type
    //      position 1: value
    // @return CurrentState
    //      position 0: InitialState
    //      position 1: AdditionalState
    //      Position 2: AttackingState
    public string[] CheckState(PlayerDataPackages.PassToStateMachine CharacterData)

    {
        string type = CharacterData.InputType;
        string value = CharacterData.InputValue;

        if (type == "UserInput")
        {
            switch (value)
            {
                case "spacew":
                    CurrentState[0] = StateTypes.isJumping;
                    CurrentState[1] = null;
                    CurrentState[2] = "isAttacking";
                    break;
                case "spaces":
                    CurrentState[0] = StateTypes.isCrouching;
                    CurrentState[1] = null;
                    CurrentState[2] = "isAttacking";
                    break;
                case "spaced":
                    CurrentState[0] = StateTypes.isMoving;
                    CurrentState[1] = null;
                    CurrentState[2] = "isAttacking";
                    break;
                case "spacea":
                    CurrentState[0] = StateTypes.isMoving;
                    CurrentState[1] = null;
                    CurrentState[2] = "isAttacking";
                    break;
                case "space":
                    CurrentState[0] = StateTypes.isIdle;
                    CurrentState[1] = null;
                    CurrentState[2] = "isAttacking";
                    break;
                case "q":
                    CurrentState[0] = StateTypes.isIdle;
                    CurrentState[1] = null;
                    CurrentState[2] = "isNeutral";
                    break;
                //right
                case "wd": 
                    CurrentState[0] = StateTypes.isJumping; 
                    CurrentState[1] = StateTypes.isMoving;
                    //CurrentState[2] = null;
                    break;
                //left
                case "wa":
                    CurrentState[0] = StateTypes.isJumping; 
                    CurrentState[1] = StateTypes.isMoving;
                    //CurrentState[2] = null;
                    break;
                case "w":
                    CurrentState[0] = StateTypes.isJumping;
                    CurrentState[1] = null;
                    //CurrentState[2] = null;
                    break;
                //right
                case "sd":
                    CurrentState[0] = StateTypes.isCrouching;
                    CurrentState[1] = StateTypes.isMoving;
                    //CurrentState[2] = null;
                    break;
                //left
                case "sa":
                    CurrentState[0] = StateTypes.isCrouching;
                    CurrentState[1] = StateTypes.isMoving;
                    CurrentState[2] = null;
                    break;
                case "s":
                    CurrentState[0] = StateTypes.isCrouching; 
                    CurrentState[1] = null;
                    //CurrentState[2] = null;
                    break;
                //right
                case "d":
                    CurrentState[0] = StateTypes.isMoving;
                    CurrentState[1] = null;
                    //CurrentState[2] = null;
                    break;
                //left
                case "a":
                    CurrentState[0] = StateTypes.isMoving;
                    CurrentState[1] = null;
                    //CurrentState[2] = null;
                    break;
                default:
                    CurrentState[0] = StateTypes.isIdle;
                    CurrentState[1] = null;
                    //CurrentState[2] = null;
                    break;
            }
        }

        return CurrentState;
    }
}
