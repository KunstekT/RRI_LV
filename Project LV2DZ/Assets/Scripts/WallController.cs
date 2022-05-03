using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] List<int> meteorIndexesToDetect;
    [SerializeField] Level1Controller levelController;

    void Update(){
    }

    public void NotifyLevelController(){
        levelController.isMeteorEscaping = true;
    }

    void OnTriggerEnter(Collider otherCollider){
        if(otherCollider.gameObject.tag == "Meteor"){
            if(meteorIndexesToDetect.Contains(otherCollider.gameObject.GetComponent<MeteorController>().index)){
                NotifyLevelController();                
                Debug.Log("Level contoller notified");
            }
        }
    }
}
