using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHitDetection : MonoBehaviour
{
    public string objectToDestroy = "Enemy";
    private bool hitKeyPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Keyboard.current.spaceKey.wasPressedThisFrame){
            hitKeyPressed = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (hitKeyPressed){
            Debug.Log("Hit Triggered");
            if(other.CompareTag(objectToDestroy)){
                Destroy(other.gameObject);
            }
            hitKeyPressed = false;
        }
    }
}
