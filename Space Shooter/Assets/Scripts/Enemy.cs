using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 5;
    [SerializeField] float firingRate = 1f;
    [SerializeField] float firingRateRandomFactor = 0.2f;
    [SerializeField] float firingDelay = 0.3f;
    [SerializeField] bool IsBoss = false;

    [SerializeField] float positionOffset = 0.4f;
    bool IsDestroyed = false;
    
    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        Fire();
        if(GameObject.FindGameObjectWithTag("LevelManager")){
            levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        }
    }
        
    private void OnTriggerEnter2D(Collider2D collider){

        DamageDealer damageDealer = collider.gameObject.GetComponent<DamageDealer>();
        DealDamage(collider.gameObject, damageDealer.GetDamage());
        if(collider.gameObject.tag=="PlayerLaser"){
            Destroy(collider.gameObject);  
        }
    }

    private void DealDamage(GameObject damageDealer, int damage){

        health -= damage;

        if(health <= 0){
            if(damageDealer.GetComponent<Laser>()!=null)damageDealer.GetComponent<Laser>().NotifyLaserDestroyedTarget(1);
            if(!IsDestroyed)levelManager.ReduceEnemyCount();
            IsDestroyed = true;
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
GameObject laser;
    IEnumerator FireShot(){
            if(IsBoss){
                laser = Instantiate(laserPrefab, new Vector3(
                    transform.position.x+positionOffset,
                    transform.position.y,
                    transform.position.z), 
                    Quaternion.identity) as GameObject;
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed); 
                laser.GetComponent<AudioSource>().Play(0);   
                laser = Instantiate(laserPrefab, new Vector3(
                    transform.position.x-positionOffset,
                    transform.position.y,
                    transform.position.z), 
                    Quaternion.identity) as GameObject;
                laser.GetComponent<AudioSource>().Play(0); 
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);  
         
            }else{
                laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
                laser.GetComponent<AudioSource>().Play(0);
            }


            yield return new WaitForSeconds(firingRate+Random.Range(-firingRateRandomFactor*firingRate,firingRateRandomFactor*firingRate));


            StartCoroutine(FireShot());
    }
}
