using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] List<GameObject> objectsToShoot;
    [SerializeField] float shootDelay = 2f;
    [SerializeField] float projectileSpeed = 5f;

    GameObject go;

    IEnumerator ShootSomething(){
        yield return new WaitForSeconds(shootDelay);
        
        go = Instantiate(objectsToShoot[Random.Range(0, objectsToShoot.Count-1)], transform.position, Quaternion.identity) as GameObject;
        go.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        
        StartCoroutine(ShootSomething());
    }

    void Start(){
        StartCoroutine(ShootSomething());
    }
}
