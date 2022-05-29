using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<MeteorController>()!=null){

        }
        else if(col.GetComponent<HealthController>()==null){
            Destroy(col.gameObject);
        }else if(col.GetComponent<Enemy>()!=null){
            
        }
        else{
            col.GetComponent<HealthController>().DealDamage(9999f);
        }

    }
}
