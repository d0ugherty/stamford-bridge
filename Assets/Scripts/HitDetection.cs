using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitDetection : MonoBehaviour
{
    public GameManager gameManager;
    public string objectToDestroy = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Enemy")){
            Debug.Log("enemy object destroyed");
            Destroy(other.gameObject, 0.8f);
            gameManager.SetScore(5);
        }
    }

}

