using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableComponent : MonoBehaviour
{
    [SerializeField] float maxHealth;
    private float currentHealth;

    public float CurrentHealth { get => currentHealth; private set => currentHealth = value; }
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    void Awake(){
        InitializeHealth();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeHealth();
    }
    public void InitializeHealth(){
        CurrentHealth = MaxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(float value){
        MaxHealth = value;
        // Debug.Log("New max health: "+maxHealth);
    }
    public void DealDamage(float damage){        
        // Debug.Log("Damage: "+damage);
        CurrentHealth -= damage;
        if(this.gameObject.GetComponent<MeteorController>() != null){
            this.gameObject.GetComponent<MeteorController>().AmpRedColor();
        }
        DestroyIfNoHP();
    }

    private void DestroyIfNoHP(){
        if(CurrentHealth<=0){
            Destroy(this.gameObject);
        }
    }
}
