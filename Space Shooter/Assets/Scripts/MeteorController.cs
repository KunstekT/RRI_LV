using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField] float XVelocity = 0f;
    [SerializeField] float YVelocity = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(XVelocity,YVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
