using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{    
    void OnCollisionEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player")
            Collect(collider.gameObject);
    }

    protected abstract void Collect(GameObject gameObject);
}
