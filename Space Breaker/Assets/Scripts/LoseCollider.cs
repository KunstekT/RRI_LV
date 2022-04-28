using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] LivesManager livesManager;
    [SerializeField] Ball ball;

    void OnTriggerEnter2D(Collider2D trigger){
        livesManager.ReduceLifeCount();
        if(livesManager.IsGameOver()){
            SceneManager.LoadScene("Lose");
        }else{
            ball.ResetStartState();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        livesManager = GameObject.FindObjectOfType<LivesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
