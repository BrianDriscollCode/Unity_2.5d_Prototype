using System.Collections;
using System.Collections.Generic;
using PlayerDataPackages;
using UnityEngine;

public class StateMachinePlayer2 : MonoBehaviour
{
    string CurrentState;
    string[] StateTypes = {
            "isJumping",
            "isFloating",
            "isMoving",
            "isCrouching",
            "isIdle"
    };

    void Start()
    {
        CurrentState = "isIdle";
    }

    public string CheckState(PassToStateMachine CharacterData)

    {
        string type = CharacterData.InputType;
        string value = CharacterData.InputValue;

        if (type == "UserInput")
        {
            switch (value)
            {
                case "wd":
                    Debug.Log(StateTypes[0] + " " + StateTypes[2]); //isJumping //isMoving
                    break;
                case "wa":
                    Debug.Log(StateTypes[0] + " " + StateTypes[2]); //isJumping //isMoving
                    break;
                case "w":
                    Debug.Log(StateTypes[0]); //isJumping
                    break;
                case "sa":
                    Debug.Log(StateTypes[3] + " " + StateTypes[2]); //isCrouching //isMoving
                    break;
                case "sd":
                    Debug.Log(StateTypes[3] + " " + StateTypes[2]); //isCrouching //isMoving
                    break;
                case "s":
                    Debug.Log(StateTypes[3]); //isCrouching
                    break;
                case "a":
                    Debug.Log(StateTypes[2]); //isMoving
                    break;
                case "d":
                    Debug.Log(StateTypes[2]); //isMoving
                    break;
                default:
                    Debug.Log(StateTypes[4] + " - Still unsure to handle default case this way");
                    break;
            }
        }

        return CurrentState;
    }
}
