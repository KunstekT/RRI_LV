using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    float mousePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // print(Input.mousePosition.x / Screen.width);
        Vector2 paddlePos = new Vector2(8f,0.5f);
        mousePos = Input.mousePosition.x / Screen.width*16;
        paddlePos.x = Mathf.Clamp(mousePos, 0.5f, 15.5f);
        transform.position = paddlePos;
    }

    public void MoveToMiddle(){        
        Vector2 paddlePos = new Vector2(8f,0.5f);
        mousePos = Input.mousePosition.x / Screen.width*16;
        paddlePos.x = Mathf.Clamp(mousePos, 0.5f, 15.5f);
        transform.position = paddlePos;
    }
}
