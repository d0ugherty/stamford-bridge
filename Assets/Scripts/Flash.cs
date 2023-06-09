using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Script to control sprite material flashes
*** to indicate certain states
**/

public class Flash: MonoBehaviour
{
    public Material defaultSprite;
    //public Collider2D enemy;
    public Material flashMaterial;
    private float flashDuration;
    private int flashCount;

    //private Renderer objectRenderer;
    // Start is called before the first frame update
    private void Start()
    {
        //objectRenderer = GetComponent<Renderer>();
        flashDuration = 0.2f;
        flashCount = 3;
    }

    /* Call co routine to flash when taking a hit */
    public void TakeHit(Renderer objectRenderer) {
        StartCoroutine(FlashRed(objectRenderer));
    }
    
    /** Flash to indicate an object has just spawned
    **/
    public void SpawnFlash(Renderer objectRenderer){
        // put code here
    }

    /**Sprite flashes ride to indicate it has taken a hit
    **/
    private IEnumerator FlashRed(Renderer objectRenderer) {
        for(int i = 0; i < flashCount; i++) {
            objectRenderer.material = flashMaterial;
            yield return new WaitForSeconds(flashDuration);

            objectRenderer.material = defaultSprite;
            yield return new WaitForSeconds(flashDuration);
        }
    }
}
