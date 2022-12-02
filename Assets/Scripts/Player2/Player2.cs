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
        public string AttackingState;

        public void SetState(string FirstState, string? SecondState, string ThirdState)
        {
            InitialState = FirstState;
            AdditionalState = SecondState;
            AttackingState = ThirdState;
            
        }
    }
    public class CharacterStateTypes
    {
        public string isJumping = "isJumping";
        public string isFloating = "isFloating";
        public string isMoving = "isMoving";
        public string isCrouching = "isCrouching";
        public string isIdle = "isIdle";
        public string isAttacking = "isAttacking";
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
    public EquipmentManager EquipmentManager;
    public Weapons Weapons;

    //State { InitialState, AdditionalState, AttackingState }
    public PlayerDataPackages.PlayerState PlayerState; //Refer to namespace for "PlayerDataPackages" (This file up top)
    public string[] TempPlayerState;

    //Player Variables
    public string PlayerDirection;
    public bool HasJumped;
    public bool IsGrounded;
    public string PlayerCurrentInput;
    public string CurrentWeapon;

    private void Awake()
    {
        StateMachine = GetComponent<StateMachinePlayer2>();
        Movement = GetComponent<MovementPlayer2>();
        AnimationPlayer = GetComponent<AnimationPlayer2>();
        Inventory = GetComponent<InventoryPlayer2>();
        Raycast = GetComponent<Raycast2>();
        EquipmentManager = GetComponent<EquipmentManager>();
        Weapons = GetComponent<Weapons>();

    }
    void Start()
    {
        //Starting conditions
        PlayerState = new PlayerState();
        PlayerDirection = "Right";

        //Starting up the state machine 
        string[] TempPlayerState = { "Idle", null, null };
        PlayerState.SetState(TempPlayerState[0], TempPlayerState[1], TempPlayerState[2]);
        HasJumped = false;
        IsGrounded = false;
        PlayerCurrentInput = null;
    }

    private void Update()
    {
        //Get Input
        PlayerCurrentInput = TrackUserInput();

        //Pass Input to StateMachine "StateMachinePlayer2"
        PlayerDataPackages.PassToStateMachine DirectInput = new PlayerDataPackages.PassToStateMachine();
        //@params type, input - Refer to namespace PlayerDataPackages for more information (top of this file)
        DirectInput.Insert("UserInput", PlayerCurrentInput);
        TempPlayerState = StateMachine.CheckState(DirectInput);

        //Set Player2 Script State (this script)
        PlayerState.SetState(TempPlayerState[0], TempPlayerState[1], TempPlayerState[2]);

        //EquipmentManager.HandleWeaponPosition(
        //    "Pistol", 
        //    PlayerState.InitialState, 
        //    PlayerState.AdditionalState, 
        //    PlayerState.AttackingState,
        //    HasJumped, 
        //    "Knife"
        //);
        
        if (Input.GetKeyDown("space"))
        {
            Weapons.ShootPistol(transform.position);
        }
        

        //Checking if player is grounded to refine jump state before passing all the player states to ***animation player***
        if (Raycast.IsGrounded())
        {
            HasJumped = false;
        }


        if (Input.GetKey("space"))
        {
            AnimationPlayer.SetAnimationState(PlayerState.InitialState, PlayerState.AdditionalState, PlayerDirection, HasJumped, "isAttacking");
        }
        else if (Input.GetKey("q"))
        {
            AnimationPlayer.SetAnimationState(PlayerState.InitialState, PlayerState.AdditionalState, PlayerDirection, HasJumped, "isNeutral");
        }
        else
        {
            AnimationPlayer.SetAnimationState(PlayerState.InitialState, PlayerState.AdditionalState, PlayerDirection, HasJumped, PlayerState.AttackingState);
        }
    }
    void FixedUpdate()
    {
       
        //Fix after Animation Player
        Movement.MovePlayer(PlayerState.InitialState, PlayerState.AdditionalState, PlayerDirection, HasJumped);

    }

    //Summary function TrackUserInput
    // Filters the user's input into a specific string. All UserInput that
    // results in an action has been sanitized here before getting passed
    // to the state machine. 
    private string TrackUserInput()
    {
        string? UserInput;

        //****** Equipment Buttons ********//
        //**NOTE: (1) Handles here so equipping and unequip take precedence
        //        WITHOUT stopping movement
        //        (2) Keep in mind, tons of explicit input will need to be defined
        //            to make sure movement WITH equips work. But maybe it just works 
        //            without all that extra work. We will see.

        if (Input.GetKey("1")) 
        {
            CurrentWeapon = "Pistol";
        }

        //****** Attacking Stance Buttons *******//

        //Right
        if (Input.GetKey("space") && Input.GetKey("w") && Input.GetKey("d"))
        {
            UserInput = "spacewd";
            HasJumped = true;
        }
        //Left
        else if (Input.GetKey("space") && Input.GetKey("w") && Input.GetKey("a"))
        {
            UserInput = "spacewa";
            HasJumped = true;
        }
        //Right
        else if (Input.GetKey("space") && Input.GetKey("s") && Input.GetKey("d"))
        {
            UserInput = "spacesd";
        }
        //Left
        else if (Input.GetKey("space") && Input.GetKey("s") && Input.GetKey("a"))
        {
            UserInput = "spacesd";
        }
        else if (Input.GetKey("space") && Input.GetKey("w"))
        {
            UserInput = "spacew";
            HasJumped = true;
        }
        else if (Input.GetKey("space") && Input.GetKey("s"))
        {
            UserInput = "spaces";

        }
        else if (Input.GetKey("space") && Input.GetKey("d"))
        {
            UserInput = "spaced";
        }
        else if (Input.GetKey("space") && Input.GetKey("a"))
        {
            UserInput = "spacea";
        }

        //****** Running Stance Buttons *******//

        //**Double Buttons
        //
        //*Jumping

        //Right
        if (Input.GetKey("w") && Input.GetKey("d")) 
        {
            UserInput = "wd";
            PlayerDirection = "Right";
            HasJumped = true;

            return UserInput;
        }

        //Left
        if (Input.GetKey("w") && Input.GetKey("a"))
        {
            UserInput = "wa";
            PlayerDirection = "Left";
            HasJumped = true;

            return UserInput;
        }

        //*Crouching

        //Right
        if (Input.GetKey("s") && Input.GetKey("d"))
        {
            UserInput = "sd";
            PlayerDirection = "Right";

            return UserInput;
        }

        //Left
        if (Input.GetKey("s") && Input.GetKey("a"))
        {
            UserInput = "sa";
            PlayerDirection = "Left";

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
        else if (Input.GetKey("q"))
        {
            UserInput = "q";
        }
        else
        {
            UserInput = null;
        }

        return UserInput;
    }
}
