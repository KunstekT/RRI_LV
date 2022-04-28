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

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted){            
            Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
        }

        if(Input.GetMouseButtonDown(0)){
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D){
        Vector2 tweakVelocity = new Vector2(Random.Range(0f,0.2f), Random.Range(0f, 0.2f));
        if(hasStarted){
            GetComponent<Rigidbody2D>().velocity += tweakVelocity;
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }

    public void ResetStartState(){
        hasStarted = false;
    }
}
