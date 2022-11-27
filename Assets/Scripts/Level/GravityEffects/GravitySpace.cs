using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySpace : MonoBehaviour
{
    private bool isInBox;
    [SerializeField] public Player playerObject;
    // Start is called before the first frame update
    void Start()
    {
        isInBox = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider player)
    {
        //Physics.gravity = new Vector3(0, -9.81f, 0);

        Debug.Log("*GravitySpace Script Triggered");

        Player playerClass = playerObject.GetComponent<Player>();
        playerClass.SetGravity("normalGravity");
    }
}