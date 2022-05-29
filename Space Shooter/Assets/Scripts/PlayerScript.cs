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

    [SerializeField] float defaultFiringRate = 0.15f;
    float firingRate;
    int fireRateBoostLevel = 0;

    float laserFatness = 1f;
    float projectileSpeedBuff = 0f;
    bool IsTripleLaserOn = false;
    bool IsQuintupleLaserOn = false;

    Coroutine firingCoroutine;
    HealthController healthController;

    IEnumerator FireContinuously(){

        while(true){
            FireSingleProjectile(0f);
            if(IsTripleLaserOn){
                FireSingleProjectile(-0.5f);
                FireSingleProjectile(0.5f);
            }
            if(IsQuintupleLaserOn){
                FireSingleProjectile(-0.25f);
                FireSingleProjectile(0.25f);
            }
            yield return new WaitForSeconds(firingRate);
        }
    }

    void FireSingleProjectile(float positionOffset){
        GameObject laser = Instantiate(laserPrefab, new Vector3(
            transform.position.x+positionOffset,
            transform.position.y,
            transform.position.z), 
            Quaternion.identity) as GameObject;
        laser.transform.localScale = new Vector3(1f*laserFatness,1f,1f);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed+projectileSpeedBuff);
        if(laser.GetComponent<Laser>()!=null)laser.GetComponent<Laser>().SetLaserCreator(this.gameObject);
    }

    void Start()
    {
        firingRate = defaultFiringRate;
        healthController = GetComponent<HealthController>();
        GetBoundaries();
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

        // var newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, -5.14f, 5.14f);
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

    public void BoostFireRate(float value, float seconds){
        fireRateBoostLevel+=1;
        
        firingRate=defaultFiringRate/(fireRateBoostLevel+1);
        StartCoroutine(RemoveFireRateBoost(value, seconds));
    }

    IEnumerator RemoveFireRateBoost(float value, float seconds){
        yield return new WaitForSeconds(seconds);
        fireRateBoostLevel-=1;
        firingRate=defaultFiringRate/(fireRateBoostLevel+1);
    }

    public void BoostLaserFatness(float value, float seconds){
        laserFatness+=value;
        StartCoroutine(RemoveLaserFatnessBuff(value, seconds));
    }

    IEnumerator RemoveLaserFatnessBuff(float value, float seconds){
        yield return new WaitForSeconds(seconds);
        laserFatness-=value;
    }    
    public void BoostLaserSpeed(float value, float seconds){
        projectileSpeedBuff+=value;
        StartCoroutine(RemoveLaserSpeedBuff(value, seconds));
    }

    IEnumerator RemoveLaserSpeedBuff(float value, float seconds){
        yield return new WaitForSeconds(seconds);
        projectileSpeedBuff-=value;
    } 
    public void SetTripleLaserBuff(float seconds){
        if(IsTripleLaserOn){
            IsQuintupleLaserOn = true;
            StartCoroutine(RemoveTripleLaserBuff(seconds));
        }else{
            IsTripleLaserOn = true;
            StartCoroutine(RemoveTripleLaserBuff(seconds));
        }
    }

    IEnumerator RemoveTripleLaserBuff(float seconds){
        yield return new WaitForSeconds(seconds);
        if(IsQuintupleLaserOn)IsQuintupleLaserOn=false;
        else IsTripleLaserOn = false;
    }
}
