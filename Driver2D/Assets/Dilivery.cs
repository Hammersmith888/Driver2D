using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dilivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Outch!");
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage){
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.tag == "Castomer" && hasPackage){
            Debug.Log("Package Dilivery");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}

