using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Collectible
{
    [SerializeField] float healValue = 10;
    protected override void Collect(GameObject gameObject){
        if(gameObject.GetComponent<HealthController>()==null){
            Debug.LogWarning("Player could not be healed: no health controller component");
            return;
        }
        gameObject.GetComponent<HealthController>().Heal(10);
    }
}
