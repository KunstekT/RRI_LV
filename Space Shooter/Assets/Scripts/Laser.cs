using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    protected GameObject laserCreator;
    
    public void SetLaserCreator(GameObject laserCreator){
        this.laserCreator = laserCreator;
    }

    public void NotifyLaserDestroyedTarget(int targetScoreValue){
        if(laserCreator.tag == "Player"){
            laserCreator.GetComponent<PlayerScript>().AddScore(targetScoreValue);
        }
    }
}
