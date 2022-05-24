using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] HighScoreManager highScoreManager;
    float projectileSpeed = 10f;
    float moveSpeed = 15f;
    float padding = 0.6f;
    float minX, minY, maxX, maxY;
    float firingRate = 0.2f;
    Coroutine firingCoroutine;
    HealthController healthController;

    // Start is called before the first frame update
    IEnumerator PrintAndWait(){
        Debug.Log("Prva poruka");
        yield return new WaitForSeconds(firingRate);
        Debug.Log("Druga poruka"); 
        yield return new WaitForSeconds(firingRate);
    }

    IEnumerator FireContinuously(){

        while(true){
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            if(laser.GetComponent<Laser>()!=null)laser.GetComponent<Laser>().SetLaserCreator(this.gameObject);
            yield return new WaitForSeconds(firingRate);
        }
    }
    void Start()
    {
        healthController = GetComponent<HealthController>();
        GetBoundaries();
        StartCoroutine(PrintAndWait());
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
        Fire();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; //edit project settings input manager axes 
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed; 

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void GetBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
    
    private void Fire()
    {
        if(Input.GetButtonDown("Fire1")){
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if(Input.GetButtonUp("Fire1")){
            StopCoroutine(firingCoroutine);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "EnemyLaser"){
            DamageDealer damageDealer = collider.gameObject.GetComponent<DamageDealer>();
            DealDamage(damageDealer.GetDamage());
            Destroy(collider.gameObject);
        }
    }

    private void DealDamage(int damage){
        healthController.DealDamage(damage);
    }

    public void AddScore(int value){
        highScoreManager.AddScore(value);
    }
}
