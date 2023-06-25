using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public Material defaultSprite;
    //public Collider2D enemy;
    public Material flashMaterial;
    private float flashDuration;
    private int flashCount;

    private Renderer objectRenderer;
    // Start is called before the first frame update
    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        flashDuration = 0.2f;
        flashCount = 4;
    }

    /* Call co routine to flash when taking a hit */
    public void TakeHit() {
        StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed() {
        for(int i = 0; i < flashCount; i++) {
            objectRenderer.material = flashMaterial;
            yield return new WaitForSeconds(flashDuration);

            objectRenderer.material = defaultSprite;
            yield return new WaitForSeconds(flashDuration);
        }
    }
}
