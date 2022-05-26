using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{ 
    protected AudioSource audioData;
    [SerializeField] protected float fadeoutDestroyDelay = 5f;   
    protected virtual void Start()
    {
        if(GetComponent<AudioSource>()!=null){
            audioData = GetComponent<AudioSource>();
            audioData.Pause();
        }
        StartCoroutine(FadeoutDestroy());
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player")
            Collect(collider.gameObject);
    }

    IEnumerator FadeoutDestroy(){
        yield return new WaitForSeconds(fadeoutDestroyDelay);
        Destroy(this.gameObject);
    }

    protected IEnumerator PendingDestroy(){
        yield return new WaitForSeconds(audioData.clip.length);
        Destroy(this.gameObject);
    }

    protected abstract void Collect(GameObject gameObject);
}
