using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPLaser : Laser
{
    [SerializeField] GameObject lesserLaserPrefab;
    float projectileSpeed=5f;

    void Start(){
        StartCoroutine(BoomOPNess());
    }  
    GameObject laser;

    IEnumerator BoomOPNess(){
        yield return new WaitForSeconds(0.4f+Random.Range(0,1f));


        laser = Instantiate(lesserLaserPrefab, transform.position, Quaternion.Euler(0f,0f,-45f)) as GameObject;
        float value = Mathf.Sqrt(projectileSpeed*projectileSpeed+projectileSpeed*projectileSpeed);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, -projectileSpeed);
        laser.GetComponent<AudioSource>().Play(0); 
        
        laser = Instantiate(lesserLaserPrefab, transform.position, Quaternion.Euler(0f,0f,45f)) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, -projectileSpeed);

        laser = Instantiate(lesserLaserPrefab, transform.position, Quaternion.Euler(0f,0f,0)) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        laser.GetComponent<AudioSource>().Play(0);

        laser = Instantiate(lesserLaserPrefab, transform.position, Quaternion.Euler(0f,0f,-90)) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed,0);

        laser = Instantiate(lesserLaserPrefab, transform.position, Quaternion.Euler(0f,0f,90f)) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
        laser.GetComponent<AudioSource>().Play(0);
        

        Destroy(this.gameObject);
    }
}
