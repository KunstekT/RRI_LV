using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStateController : MonoBehaviour
{
    [SerializeField] int weapon;
    [SerializeField] bool power;

    public bool Power { get => power; set => power = value; }
    public int Weapon { get => weapon; set => weapon = value; }

    // Start is called before the first frame update
    void Start()
    {
        ResetValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetValues(){
        Weapon=0;
        Power=true;
    }
}
