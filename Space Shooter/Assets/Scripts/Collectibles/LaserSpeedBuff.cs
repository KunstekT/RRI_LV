using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpeedBuff : Collectible
{
    [SerializeField]float boostValue = 7.5f;
    [SerializeField]float buffDuration = 5f;
    protected override void Collect(GameObject gameObject)
    {
        if(gameObject.GetComponent<PlayerScript>()==null){
            Debug.LogWarning("Player could not be buffed: no PlayerScript component");
            return;
        }
        else{
            if(audioData!=null){
                audioData.Play();
            }
            BoostLaserSpeed(gameObject.GetComponent<PlayerScript>());
            Destroy(GetComponent<Collider2D>());
            if(GetComponent<ParticleSystem>()!=null){Destroy(GetComponent<ParticleSystem>());}
            if(GetComponent<SpriteRenderer>()!=null){Destroy(GetComponent<SpriteRenderer>());}
            StartCoroutine(PendingDestroy());
        }
    }

    protected override void Start()
    {
        base.Start();
    }

    void BoostLaserSpeed(PlayerScript playerScript){
        playerScript.BoostLaserSpeed(boostValue,buffDuration);
    }

}
