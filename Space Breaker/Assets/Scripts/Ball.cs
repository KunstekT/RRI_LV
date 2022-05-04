using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ball : MonoBehaviour
{
    public Paddle paddle;
    public AudioClip[] ballSounds;

    private Vector2 paddleToBallVector;
    private AudioSource myAudioSource;

    private bool hasStarted = false;

    float constantSpeed = 12f;


    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        Debug.Log(ballSounds[0].name);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted){            
            Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
        }  

        if(!hasStarted && Input.GetMouseButtonDown(0)){
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D){
        Vector2 tweakVelocity = new Vector2(Random.Range(-0.15f,0.15f), Random.Range(-0.15f,0.15f));
        Vector2 targetDirection = (GetComponent<Rigidbody2D>().velocity+tweakVelocity).normalized;
        if(hasStarted){
            GetComponent<Rigidbody2D>().velocity = targetDirection * constantSpeed;
            AudioClip clip = ballSounds[2];
            myAudioSource.PlayOneShot(clip);
        }
    }

    public void ResetStartState(){
        hasStarted = false;
    }
}
