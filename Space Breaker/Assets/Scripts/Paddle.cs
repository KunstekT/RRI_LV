using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float mousePos;
    void Start()
    {
        
    }
    
    void Update()
    {   
        // print(Input.mousePosition.x / Screen.width);
        CenterPaddle();
    }

    public void CenterPaddle(){        
        Vector2 paddlePos = new Vector2(8f,0.5f);
        mousePos = Input.mousePosition.x / Screen.width*16;
        paddlePos.x = Mathf.Clamp(mousePos, 0.5f, 15.5f);
        transform.position = paddlePos;
    }
}
