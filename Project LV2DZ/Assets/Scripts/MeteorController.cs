using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public int index;
    float greenAndBlueComponent;
    public void AmpRedColor(){
        greenAndBlueComponent = (this.gameObject.GetComponent<DestroyableComponent>().CurrentHealth/this.gameObject.GetComponent<DestroyableComponent>().MaxHealth);
        // Debug.Log(this.gameObject.GetComponent<DestroyableComponent>().CurrentHealth+"/"+this.gameObject.GetComponent<DestroyableComponent>().MaxHealth+", "+greenAndBlueComponent);
        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, greenAndBlueComponent,greenAndBlueComponent, 1.0f);
    }
}
