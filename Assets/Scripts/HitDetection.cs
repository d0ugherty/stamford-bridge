using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitDetection : MonoBehaviour
{
    public string objectToDestroy = "Enemy";
    private bool hitKeyPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Keyboard.current.spaceKey.isPressed){
            hitKeyPressed = true;
        } else {
            hitKeyPressed = false;
        }
        
    }

    void OnTriggerStay2D(Collider2D other){
        if (hitKeyPressed && other.CompareTag("Enemy")){
            int targetId = other.gameObject.GetComponent<EnemyID>().id;
            Debug.Log("target id: " + targetId);
            DestroyObjectByID(targetId);
            hitKeyPressed = false;
        }
    }

    void DestroyObjectByID(int targetId){
        GameObject objectToDestroy = GameObject.FindWithTag("Enemy");
        EnemyID enemyID = objectToDestroy.GetComponent<EnemyID>();
        if(enemyID.id == targetId) {
            Destroy(objectToDestroy);
        }
    }
}
