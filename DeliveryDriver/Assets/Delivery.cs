using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0,0,0,0);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    [SerializeField] float delay = .5f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("oops... I thing i hit something!!!");
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("A Package is Picked Up.");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, delay);
        }
        else if(other.tag == "Package" && hasPackage)
        {
            Debug.Log("Please deliver the Package you have");
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("The Package is delivered.");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        else if(other.tag == "Customer" && !hasPackage)
        {
            Debug.Log("There is no Package to delivered.");
        }
    }
}
