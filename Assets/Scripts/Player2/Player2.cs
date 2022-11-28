using System.Collections;
using System.Collections.Generic;
using PlayerDataPackages;
using UnityEngine;

namespace PlayerDataPackages
{
    public class PassToStateMachine : MonoBehaviour
    {
        public string InputType { get; set; }
        public string InputValue { get; set; }

        public void Insert(string Type, string Value)
        {
            InputType = Type;
            InputValue = Value;
        }
    }
}

public class Player2 : MonoBehaviour
{

    //Self
    Rigidbody Player;

    //Scripts
    public StateMachinePlayer2 StateMachine;
    public MovementPlayer2 Movement;
    public AnimationPlayer2 AnimationPlayer;
    public InventoryPlayer2 Inventory;

    //State 
    public string PlayerState = "Idle";
    //Direction
    public string PlayerDirection = "Right";
    //Current Input
    public string PlayerCurrentInput = null;

    void Start()
    {
        StateMachine = GetComponent<StateMachinePlayer2>();
        Movement = GetComponent<MovementPlayer2>();
        AnimationPlayer = GetComponent<AnimationPlayer2>();
        Inventory = GetComponent<InventoryPlayer2>();
    }

    private void Update()
    {
        PlayerCurrentInput = TrackUserInput();
        PassToStateMachine DirectInput = new PassToStateMachine();
        DirectInput.Insert("UserInput", PlayerCurrentInput);


        PlayerState = StateMachine.CheckState(DirectInput);
    }
    void FixedUpdate()
    {
        
        

    }

    private void callStateScript()
    { 
        
    }

    private string TrackUserInput() 
    {
        string UserInput;

        //Priority for two types of character stances: 
        //(1) Jumping - "w" && "a" or "d"
        //(2) Crouching - "s" && "a" or "d"
        //Otherwise "Standing" is default
        //This is all ONLY Input, but structured for further down the line

        //**Double Buttons
        //
        //*Jumping

        //Right
        if (Input.GetKey("w") && Input.GetKey("d")) 
        {
            UserInput = "wd";

            Debug.Log(UserInput + " was pressed");

            return UserInput;
        }

        //Left
        if (Input.GetKey("w") && Input.GetKey("a"))
        {
            UserInput = "wa";

            Debug.Log(UserInput + " was pressed");

            return UserInput;
        }

        //*Crouching

        //Right
        if (Input.GetKey("s") && Input.GetKey("d"))
        {
            UserInput = "sd";

            Debug.Log(UserInput + " was pressed");

            return UserInput;
        }

        //Left
        if (Input.GetKey("s") && Input.GetKey("a"))
        {
            UserInput = "sa";

            Debug.Log(UserInput + " was pressed");

            return UserInput;
        }

        //*Default Standing

        //single button priority defined by order
        if (Input.GetKey("w"))
        {
            UserInput = "w";
        }
        else if (Input.GetKey("s"))
        {
            UserInput = "s";
        }
        else if (Input.GetKey("a"))
        {
            UserInput = "a";
        }
        else if (Input.GetKey("d"))
        {
            UserInput = "d";
        }
        else if (Input.GetKey("space")) 
        {
            UserInput = "space";
        } 
        else
        {
            UserInput = null;
        }

        Debug.Log(UserInput + " was pressed");

        return UserInput;
    }
}
