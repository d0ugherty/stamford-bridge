using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitDetection : MonoBehaviour
{
    public string objectToDestroy = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Enemy")){
            Debug.Log("enemy object destroyed");
            Destroy(other.gameObject, 0.8f);
        }
    }

}

