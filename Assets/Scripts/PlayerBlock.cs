using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    
    public InputAction blockAction;
    public bool isBlocking;
    private bool isBlockBtnDown;
    
    // Update is called once per frame
    void Update()
    {
        if(isBlockBtnDown) {
            Block();
        } else {
            EndBlock();
       }
    }

    private void OnEnable(){
        blockAction.Enable();
        //button hold implementation
        blockAction.started += OnBlockButtonDown;
        blockAction.canceled += OnBlockButtonUp;
    }

    private void OnDisable(){
        blockAction.Disable();
        // button hold implementation
        blockAction.started -= OnBlockButtonDown;   
        blockAction.canceled -= OnBlockButtonDown;
    }

    private void OnBlockButtonDown(InputAction.CallbackContext context) {
        isBlockBtnDown = true;
    }

    private void OnBlockButtonUp(InputAction.CallbackContext context) {
        isBlockBtnDown = false;
    }

    private void Block() {
        isBlocking = true;
        Debug.Log("Player is blocking");
    }

    private void EndBlock() {
        isBlocking = false;
    }
}
