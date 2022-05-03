using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject missilePrefab;

    float maxPosition = 7.5f;
    float movementDelay = 0.005f;
    float shootDelay = 0.2f;
    float movementPerTick = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && !Input.GetKeyDown(KeyCode.D) && !moveLeftFlag && playerShip.transform.position.x > -maxPosition){
            moveLeftFlag = true;
            StartCoroutine(MoveLeftCoroutine());             
        }
        else if(Input.GetKey(KeyCode.D) && !Input.GetKeyDown(KeyCode.A) && !moveRightFlag && playerShip.transform.position.x < maxPosition){
            moveRightFlag = true;
            StartCoroutine(MoveRightCoroutine());    
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            StartCoroutine(ShootCoroutine());   

        }
    }
    bool moveLeftFlag = false;
    bool moveRightFlag = false;
    IEnumerator MoveLeftCoroutine(){
        yield return new WaitForSeconds(movementDelay);
        moveLeftFlag = false;
        MoveLeft();
    }
    IEnumerator MoveRightCoroutine(){
        yield return new WaitForSeconds(movementDelay);
        moveRightFlag = false;
        MoveRight();
    }
    IEnumerator ShootCoroutine(){
        yield return new WaitForSeconds(shootDelay);
        Shoot();
    }

    private void Shoot(){
        ShootMissile();
    }

    private void SetLocation(Vector2 newPosition){
        playerShip.transform.position = newPosition;
    }
    
    public void MoveLeft(){
        moveLeftFlag = false;
        Vector2 v = playerShip.transform.position;
        v.x -= movementPerTick;
        SetLocation(v);
    }
    public void MoveRight(){
        moveRightFlag = false;
        Vector2 v = playerShip.transform.position;
        v.x += movementPerTick;
        SetLocation(v);
    }

    private void ShootMissile(){        
        GameObject go = Instantiate(missilePrefab,new Vector3(playerShip.transform.position.x, playerShip.transform.position.y+0.1f,0f), Quaternion.Euler(0f, 180f, 0f)) as GameObject;
        go.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 5.0f, 0.0f),ForceMode.VelocityChange);
    }
}
