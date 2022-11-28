using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Camera
    public Camera MainCamera; // connected externally

    // Self
    private Rigidbody rigidbodyComponent;

    // External Scripts
    private StateMachine externalStateMachine;
    private PlayerAnimationMachine playerAnimations;
    private Raycast raycastComponent;
    private CameraFunctions cameraFunctions;

    // Player Variables
    bool facingRightDirection = false;
    [SerializeField] string currentState;
    [SerializeField] string playerAction;
    [SerializeField] public float speed = 12f;
    [SerializeField] int jumpInput = 0;
    bool isJumping = false;
    bool hasJumped = false;
    bool isCrouching = false;
    bool isStepping = false;
    string directionFace = "right";

    //Inventory
    public int currentWeaponSelector = 0;
    public string currentWeapon = "unarmed";
    public string[] inventory = { "unarmed", "rifle" };

    // Gravity
    bool inNormalGravity = true;
    bool inReverseGravity = false;
    bool inZeroGravity = false;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        externalStateMachine = GetComponent<StateMachine>();
        playerAnimations = GetComponent<PlayerAnimationMachine>();
        raycastComponent = GetComponent<Raycast>();
        cameraFunctions = MainCamera.GetComponent<CameraFunctions>();

        currentState = externalStateMachine.getCurrentState();
        playerAction = null;
        Debug.Log(jumpInput);

        SetGravity("normal");
    }

    //no update function
    private void FixedUpdate()
    {

        checkInput();
        //Debug.Log(playerAction + " -Player Action");
        checkState(playerAction);
        movePlayer(currentState);

        if (Input.GetKey("k"))
        {
            cameraFunctions.activateZoom("out");
        }

        if (Input.GetKey("j"))
        {
            cameraFunctions.activateZoom("in");
        }

        if (Input.GetKey("w"))
        {
            isJumping = true;
        }
        else 
        {
            isJumping = false;
        }

        if (Input.GetKey("s"))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }

        if (Input.GetKey("a"))
        {
            isStepping = true;
            directionFace = "left";
            //Debug.Log("is stepping true");
        }
        else if (Input.GetKey("d"))
        {
            directionFace = "right";
            isStepping = true;
            //Debug.Log("is stepping true");
        }
        else
        {
            isStepping = false;
        }

        checkIfGrounded();
    }

    //Make item inventory function

    public void SetGravity(string gravityType) 
    {
        if (gravityType == "reverseGravity")
        {
            Debug.Log("***Reverse Gravity set***");
            inNormalGravity = false;
            inReverseGravity = true;
            inZeroGravity = false;
        }
        else if (gravityType == "zeroGravity") 
        {
            Debug.Log("***Zero Gravity set***");
            inNormalGravity = false;
            inReverseGravity = false;
            inZeroGravity = true;
        }
        else
        {
            Debug.Log("***Normal Gravity set***");
            inNormalGravity = true;
            inReverseGravity = false;
            inZeroGravity = false;
        }
    }

    private void checkIfGrounded() {

        if (isJumping && !hasJumped)
        {
            rigidbodyComponent.AddForce(new Vector3(0, 2.6f, 0), ForceMode.Impulse);
            hasJumped = true;
        }
        else
        {
            jumpInput = 0;
        }

        if (raycastComponent.isGrounded())
        {
            hasJumped = false;
        }

    }

    private void movePlayer(string state) 
    {
        Vector3 moveInput;
        float speedController = 1f;
        moveInput = new Vector3(0, 0, 0);
        //Moves player based on the current state
        switch (state)
        {
            case "punching":
                Debug.Log(playerAnimations);
                playerAnimations.changeAnimationState("PunchingStraight");
                moveInput = new Vector3(0, 0, 0);
                break;
            case "crouching":
                if (isCrouching && !isStepping)
                {
                    if (hasJumped)
                    {
                        break;
                    }

                    playerAnimations.changeAnimationState("CrouchIdle");
                    moveInput = new Vector3(0, 0, 0);
                    speedController = 1f;
                }
                else 
                {
                    if (hasJumped)
                    {
                        break;
                    }

                    playerAnimations.changeAnimationState("CrouchWalk");

                    Vector3 characterMovement = directionFace == "left" ? new Vector3(-1, 0, 0) : new Vector3(1, 0, 0);
                    moveInput = characterMovement;
                    speedController = 0.25f;

                }

                break;
            case "runningLeft":

                moveInput = new Vector3(-1, 0, 0);
                speedController = 0.9f;
                //Debug.Log(hasJumped + "- Has Jumped");

                if (hasJumped)
                {
                    playerAnimations.changeAnimationState("Jumping");
                }
                else
                {
                    playerAnimations.changeAnimationState("Running");
                }
              

                if (!facingRightDirection)
                {
                    transform.Rotate(0, 180, 0);
                    facingRightDirection = true;
                }

                break;
            case "runningRight":
                moveInput = new Vector3(1, 0, 0);
                speedController = 0.9f;
                if (hasJumped)
                {
                    playerAnimations.changeAnimationState("Jumping");
                }
                else if (Input.GetKey("d") == true)
                {
                    playerAnimations.changeAnimationState("Running");
                }
                else {
                    playerAnimations.changeAnimationState("idle");
                }

                if (facingRightDirection)
                {
                    transform.Rotate(0, 180, 0);
                    facingRightDirection = false;
                }

                break;
            case "jumping":
                moveInput = new Vector3(0, 0, 0);

                if (hasJumped)
                {
                    playerAnimations.changeAnimationState("Jumping");
                }
                else
                {
                    playerAnimations.changeAnimationState("Idle");
                }


                break;
;            case "idle":
                moveInput = new Vector3(0, 0, 0);
          
                if (!inReverseGravity) {
                    playerAnimations.changeAnimationState("Idle");
                }
               
                break;
             default:
                moveInput = new Vector3(0, 0, 0);
                //if (!inReverseGravity)
                //{
                    //playerAnimations.changeAnimationState("Idle");
                //}
                break;
        }

        //Gravity settings
        if (inReverseGravity) 
        {
            moveInput = new Vector3(moveInput.x, 1.0f, moveInput.z);
            rigidbodyComponent.useGravity = false;
            playerAnimations.changeAnimationState("Floating");
        }

        if (inZeroGravity) 
        {
            moveInput = new Vector3(moveInput.x, 0.01f, moveInput.z);
            rigidbodyComponent.useGravity = false;
            playerAnimations.changeAnimationState("Floating");
        }

        if (inNormalGravity) 
        {
            rigidbodyComponent.useGravity = true;
        }

        //Debug.Log(inReverseGravity + "- in reverse gravity");
        //Debug.Log(inZeroGravity + "- in zero gravity");

        //inNormalGravity do nothing to moveInput

        rigidbodyComponent.MovePosition(transform.position + moveInput * Time.deltaTime * speed * speedController);
    }

    private void checkState(string action) {
        currentState = externalStateMachine.checkCurrentState(action);
    }

    private void checkInput()
    {
        bool moveRight = Input.GetKey("d");
        bool moveLeft = Input.GetKey("a");
        bool crouch = Input.GetKey("s");
        bool jump = Input.GetKey("w");
        bool punch = Input.GetKey("space");

        if (punch == true)
        {
            playerAction = "punching";
            Debug.Log("setting player action to fighting");
        }
        else if (crouch == true)
        {
            playerAction = "crouch";
        }
        else if (moveLeft == true)
        {
            playerAction = "runLeft";
        }
        else if (moveRight == true)
        {
            playerAction = "runRight";
        }
        else if (jump == true)
        {
            playerAction = "jump";
        }
        else {
            playerAction = "idle";
        }
    }
}
