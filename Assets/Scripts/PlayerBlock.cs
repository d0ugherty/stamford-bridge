using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    
    public InputAction blockAction;
    public bool isBlocking;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(blockAction.triggered){
            isBlocking = true;
        } else {
            isBlocking = false;
        }
    }

    private void OnEnable(){
        blockAction.Enable();
    }

    private void OnDisable(){
        blockAction.Disable();
    }
}
