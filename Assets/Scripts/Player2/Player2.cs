using System.Collections;
using System.Collections.Generic;
using PlayerDataPackages;
using UnityEngine;

namespace PlayerDataPackages
{

    public class PlayerState
    {
        public string InitialState;
        public string AdditionalState;

        public void SetState(string FirstState, string? SecondState)
        {
            InitialState = FirstState;
            AdditionalState = SecondState;
        }
    }
    public class CharacterStateTypes
    {
        public string isJumping = "isJumping";
        public string isFloating = "isFloating";
        public string isMoving = "isMoving";
        public string isCrouching = "isCrouching";
        public string isIdle = "isIdle";
    }
    public class PassToStateMachine
    {
        public string InputType;
        public string InputValue;

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
    public Raycast2 Raycast;

    //State { FirstState, SecondState }
    public PlayerState PlayerState = new PlayerState();
    public string[] TempPlayerState = { "Idle", null };
    //Player Variables
    public string PlayerDirection = "Right";
    public bool HasJumped = false;
    public bool IsGrounded = false;
    //Current Input
    public string? PlayerCurrentInput = null;

    void Start()
    {
    
        StateMachine = GetComponent<StateMachinePlayer2>();
        Movement = GetComponent<MovementPlayer2>();
        AnimationPlayer = GetComponent<AnimationPlayer2>();
        Inventory = GetComponent<InventoryPlayer2>();
        Raycast = GetComponent<Raycast2>();

        PlayerState.SetState(TempPlayerState[0], TempPlayerState[1]);
        AnimationPlayer.SetAnimationState("Idle", null, "Right", false);
    }

    private void Update()
    {
        //Get Input
        PlayerCurrentInput = TrackUserInput();
        PassToStateMachine DirectInput = new PassToStateMachine();
        DirectInput.Insert("UserInput", PlayerCurrentInput);
        
        //Fetch State From Input
        TempPlayerState = StateMachine.CheckState(DirectInput);
        
        //Set Player2 Script State (this script)
        PlayerState.SetState(TempPlayerState[0], TempPlayerState[1]);
        //Debug.Log(PlayerState.InitialState + " " + PlayerState.AdditionalState + " -Current player state");

        //Inventory management here???

        //Handle communicating with animation player
        if (Raycast.IsGrounded())
        {
            HasJumped = false;
        }
        AnimationPlayer.SetAnimationState(PlayerState.InitialState, PlayerState.AdditionalState, PlayerDirection, HasJumped);
        //Debug.Log("******************" + PlayerState.AdditionalState);

        //Debug.Log("Camera here: " + Camera.transform );
    }
    void FixedUpdate()
    {

        //Debug.Log(HasJumped + " -HasJumped************");
        if (Raycast.IsGrounded())
        {
            HasJumped = false;
        }

        //Finish Writing the direction logic
        Movement.MovePlayer(PlayerState.InitialState, PlayerState.AdditionalState, PlayerDirection, HasJumped);
        //Debug.Log(HasJumped + " -HasJumped equals");

        
    }

   
    private string TrackUserInput() 
    {
        string? UserInput;

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
            PlayerDirection = "Right";
            HasJumped = true;

            //Debug.Log(UserInput + " was pressed");

            return UserInput;
        }

        //Left
        if (Input.GetKey("w") && Input.GetKey("a"))
        {
            UserInput = "wa";
            PlayerDirection = "Left";
            HasJumped = true;

            //Debug.Log(UserInput + " was pressed");

            return UserInput;
        }

        //*Crouching

        //Right
        if (Input.GetKey("s") && Input.GetKey("d"))
        {
            UserInput = "sd";
            PlayerDirection = "Right";

            //Debug.Log(UserInput + " was pressed");

            return UserInput;
        }

        //Left
        if (Input.GetKey("s") && Input.GetKey("a"))
        {
            UserInput = "sa";
            PlayerDirection = "Left";

            //Debug.Log(UserInput + " was pressed");

            return UserInput;
        }

        //*Default Standing

        //single button priority defined by order
        if (Input.GetKey("w"))
        {
            UserInput = "w";
            HasJumped = true;
        }
        else if (Input.GetKey("s"))
        {
            UserInput = "s";
        }
        else if (Input.GetKey("a"))
        {
            UserInput = "a";
            PlayerDirection = "Left";
        }
        else if (Input.GetKey("d"))
        {
            UserInput = "d";
            PlayerDirection = "Right";
        }
        else if (Input.GetKey("space")) 
        {
            UserInput = "space";
        } 
        else
        {
            UserInput = null;
        }

        //Debug.Log(UserInput + " was pressed");

        return UserInput;
    }
}
