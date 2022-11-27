using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravitySpace : MonoBehaviour
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

    void OnTriggerStay(Collider player) {
        Debug.Log("*ReverseGravitySpace Script Triggered");
        //Physics.gravity = new Vector3(0, 0.3f, 0);
        
        Player playerClass = playerObject.GetComponent<Player>();    
        playerClass.SetGravity("reverseGravity");
    }
}
