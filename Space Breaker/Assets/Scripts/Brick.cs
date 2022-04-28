using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] Sprite[] hitSprites;
    private bool isBreakable;
    public GameObject Smoke;
    private int currentHitCount = 0;
    private LevelManager levelManager;

    private int maxHits;
    // Start is called before the first frame update
    void Start()
    {        
        isBreakable = (this.tag == "Breakable");
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(gameObject.tag == "Unbreakable"){
            
        }
        else if(gameObject.tag == "Breakable"){
            currentHitCount++;
            maxHits = hitSprites.Length;
            if(currentHitCount>= maxHits){
                
                levelManager.BrickDestroyed();
                Instantiate(Smoke, this.gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }else{
                int spriteIndex = currentHitCount;
                GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            }
        }
    }
}
