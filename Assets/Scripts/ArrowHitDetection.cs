using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowHitDetection : MonoBehaviour {

    private Flash flash;
    public Renderer playerRenderer;
    public GameManager gameManager;

    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            flash = other.gameObject.GetComponent<Flash>();
            playerRenderer = other.gameObject.GetComponent<Renderer>();
            //other.gameObject.GetComponent<PlayerMovement>().movementSpeed = 0;
            Debug.Log("Player hit with arrow");
            gameManager.DecHP();
            flash.TakeHit(playerRenderer);
            Destroy(gameObject);
        }
    }

}