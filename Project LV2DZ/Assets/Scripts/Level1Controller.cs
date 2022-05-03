using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour, ILevelController
{
    [SerializeField] GameObject meteorPrefab;
    [SerializeField] List<GameObject> meteors;
    [SerializeField] SceneController sceneController;
    public bool isMeteorEscaping = false;
    bool isLevelComplete =false;

    // Start is called before the first frame update
    void Start()
    {

        meteors = new List<GameObject>();
        GameObject meteor1 = Instantiate(meteorPrefab, new Vector3(7f,5f,0f), Quaternion.Euler(0f, 0f, 0f));
        meteor1.GetComponent<Rigidbody>().AddForce(new Vector3(-1f, -0.25f, 0.0f),ForceMode.VelocityChange);
        meteor1.GetComponent<Rigidbody>().freezeRotation = true;
        meteor1.tag = "Meteor";
        meteor1.GetComponent<MeteorController>().index = 1;
        meteor1.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        
        GameObject meteor2 = Instantiate(meteorPrefab, new Vector3(-13.0f, 1.6f, 0f), Quaternion.Euler(0f, 0f, 0f));
        meteor2.GetComponent<Rigidbody>().AddForce(new Vector3(1.4f, -0.06f, 0.0f),ForceMode.VelocityChange);
        meteor2.GetComponent<Rigidbody>().freezeRotation = true;
        meteor2.tag = "Meteor";
        meteor2.GetComponent<MeteorController>().index = 2;
        meteor2.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;

        GameObject meteor3 = Instantiate(meteorPrefab, new Vector3(8f,4.2f, 0f), Quaternion.Euler(0f, 0, 0f));
        meteor3.GetComponent<Rigidbody>().AddForce(new Vector3(-1f, -0.12f, 0.0f),ForceMode.VelocityChange);
        meteor3.GetComponent<Rigidbody>().freezeRotation = true;        
        meteor3.tag = "Meteor";
        meteor3.GetComponent<MeteorController>().index = 3;
        meteor3.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;

        GameObject meteor4 = Instantiate(meteorPrefab, new Vector3(16f,4f,0f), Quaternion.Euler(0f, 0f, 0f));
        meteor4.GetComponent<Rigidbody>().AddForce(new Vector3(-1.5f, -0.22f, 0.0f),ForceMode.VelocityChange);
        meteor4.GetComponent<Rigidbody>().freezeRotation = true;
        meteor4.tag = "Meteor";
        meteor4.GetComponent<MeteorController>().index = 4;
        meteor4.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;

        meteors.Add(meteor1);
        meteors.Add(meteor2);
        meteors.Add(meteor3);
        meteors.Add(meteor4);   

        StartCoroutine(CheckMeteorCountCoroutine());    
    }

    IEnumerator CheckMeteorCountCoroutine(){
        yield return new WaitForSeconds(0.5f);
        if(!isLevelComplete){
            CheckMeteorCount();
            StartCoroutine(CheckMeteorCountCoroutine());
        }
    }

    void CheckMeteorCount(){
        // Debug.Log("CheckMeteorCount");
        foreach(GameObject m in meteors){
            if(m == null)continue;
            else if(meteors.Count == 0){break;}
            else{
                return;
            }
        }
        
        Debug.Log("Level Complete");
        sceneController.LoadGameWin();
        isLevelComplete = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(isMeteorEscaping == true){
            sceneController.LoadGameLost();
        }
    }

}
