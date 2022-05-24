using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] float maxHealth;
    private float currentHealth;
    private bool isDestroyed;
    
    [SerializeField] UI_HealthBar uiHealthBar;

    private bool HasUIProgressBarChangeIndicator = false;
    [SerializeField] UI_ProgressBarChangeIndicator uiProgressBarChangeIndicator;

    public float CurrentHealth { get => currentHealth; private set => currentHealth = value; }
    public float MaxHealth { get => maxHealth;}
    public bool IsDestroyed { get => isDestroyed; private set => isDestroyed = value; }

    void Awake(){
        InitializeHealth();
        if(uiProgressBarChangeIndicator != null){
            HasUIProgressBarChangeIndicator = true;
        }
    }
    
    public void InitializeHealth(){
        CurrentHealth = MaxHealth;
        isDestroyed = false;
        SetBarFillAmount(currentHealth/maxHealth);
    }

    public void DealDamage(float value){
        Debug.Log("Dealing "+value+" damage");
        if(currentHealth - value <= 0){
            if(HasUIProgressBarChangeIndicator)uiProgressBarChangeIndicator.Popup_Subtraction(value-currentHealth);
            currentHealth = 0;
            isDestroyed = true;
            SetBarFillAmount(0);
        }else{
            currentHealth -= value;
            if(HasUIProgressBarChangeIndicator)uiProgressBarChangeIndicator.Popup_Subtraction(value);
            SetBarFillAmount(currentHealth/maxHealth);
        }
    }
    public void Heal(float value){
        if(currentHealth + value > maxHealth){
            if(HasUIProgressBarChangeIndicator)uiProgressBarChangeIndicator.Popup_Addition(maxHealth-currentHealth);
            currentHealth = maxHealth;
        }else{
            if(HasUIProgressBarChangeIndicator)uiProgressBarChangeIndicator.Popup_Addition(value);
            currentHealth += value;
        }
        SetBarFillAmount(currentHealth/maxHealth);
    }

    // Use only when leveling up, equiping gear etc.
    public void SetMaxHealth(float value){
        if(value <= 0){            
            maxHealth = 0;
            currentHealth = 0;
            isDestroyed = true;
            SetBarFillAmount(0);
        }
        else if(value > maxHealth){
            currentHealth += value - maxHealth;
            maxHealth = value;            
            SetBarFillAmount(currentHealth/maxHealth);
        }
        else if(value < maxHealth){
            if(value < currentHealth){
                currentHealth = value;
            }
            maxHealth = value;            
            SetBarFillAmount(currentHealth/maxHealth);
        }
    }

    void Update(){
        if(isDestroyed){
            if(this.gameObject.tag == "Player"){
                if(GameObject.FindGameObjectWithTag("LevelManager")!=null){
                    GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().LoadLevel("Lose");
                }else{Debug.LogWarning("No level manager in the scene.");}
            }else{
                Object.Destroy(this.gameObject);
            }
        }
    }

    private void SetBarFillAmount(float value){
        if(uiHealthBar!=null){
            uiHealthBar.SetBarFillAmount(value);
        }else{
            Debug.LogWarning("UI_HealthBar object is null (HealthController.cs)");
        }
    }    
}
