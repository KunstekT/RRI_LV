using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileController : MonoBehaviour
{
    [SerializeField] GameObject missile;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] float onHitDamage;
    [SerializeField] float onHitRandomRange;
    [SerializeField] Text text;
    [SerializeField] SpriteRenderer missileSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {    

    }

    void OnTriggerEnter(Collider otherCollider){
        if(otherCollider.gameObject.GetComponent<DestroyableComponent>()!=null)
        {
            float min = onHitDamage - onHitRandomRange;
            float max = onHitDamage + onHitRandomRange;   
            System.Random random = new System.Random();
            double newDamage = (random.NextDouble() * (max - min) + min);
            
            DestroyableComponent dc = otherCollider.gameObject.GetComponent<DestroyableComponent>();
            if(dc != null){
                // Debug.Log("NEW DAMAGE"+ newDamage);
                dc.DealDamage((float)newDamage);
                ShowDamageText(newDamage);
            }else{Debug.Log("DC IS NULL");}
        }
        missile.GetComponent<Rigidbody>().velocity = Vector3.zero;
        missile.GetComponent<Rigidbody>().detectCollisions = false;
        missileSpriteRenderer.enabled = false;
        StartCoroutine(PendingDestroyMissileCoroutine());
    }

    void ShowDamageText(double newDamage){
        if(text!=null){
            text.text = newDamage.ToString("F2");
        }
        else Debug.Log("Error: Text is null!");
        
    }

    IEnumerator PendingDestroyMissileCoroutine(){
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
