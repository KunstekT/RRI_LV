using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 5;
    [SerializeField] float firingRate = 10f;
    [SerializeField] float firingDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Fire();
    }

    // Update is called once per frame
    void Update()
    {

    }

        
    private void OnTriggerEnter2D(Collider2D collider){

        DamageDealer damageDealer = collider.gameObject.GetComponent<DamageDealer>();
        DealDamage(collider.gameObject, damageDealer.GetDamage());
        if(collider.gameObject.tag=="PlayerLaser"){
            Destroy(collider.gameObject);  
        }
    }

    private void DealDamage(int damage){
        health -= damage;
        if(health <= 0){

            Destroy(gameObject);
        }
    }

    private void DealDamage(GameObject damageDealer, int damage){
        health -= damage;
        if(health <= 0){
            if(damageDealer.GetComponent<Laser>()!=null)damageDealer.GetComponent<Laser>().NotifyLaserDestroyedTarget(1);
            else{Debug.LogWarning("Laser is null (Enemy)");}
            Destroy(gameObject);
        }
    }

    private void Fire(){
        StartCoroutine(FireStartDelay());
    }

    IEnumerator FireStartDelay(){
        
        yield return new WaitForSeconds(firingDelay);

        StartCoroutine(FireShot());
    }

    IEnumerator FireShot(){

            yield return new WaitForSeconds(firingRate);

            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
            StartCoroutine(FireShot());
    }
}
