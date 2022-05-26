using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Collectible
{
    [SerializeField] float healValue = 100;           

    protected override void Start(){
        base.Start();

    }

    protected override void Collect(GameObject gameObject){
        if(gameObject.GetComponent<HealthController>()==null){
            Debug.LogWarning("Player could not be healed: no health controller component");
            return;
        }
        else{
            if(audioData!=null){
                audioData.Play();
            }
            gameObject.GetComponent<HealthController>().Heal(healValue);
            Destroy(GetComponent<Collider2D>());
            if(GetComponent<ParticleSystem>()!=null){Destroy(GetComponent<ParticleSystem>());}
            if(GetComponent<SpriteRenderer>()!=null){Destroy(GetComponent<SpriteRenderer>());}
            StartCoroutine(PendingDestroy());
        }
    }
}
