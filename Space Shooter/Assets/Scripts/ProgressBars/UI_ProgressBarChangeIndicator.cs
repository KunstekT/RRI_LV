using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ProgressBarChangeIndicator : MonoBehaviour
{
    [SerializeField] private Text changeIndicator;
    [SerializeField] private Color defaultTextColor = Color.white;
    [SerializeField] private Color AdditionColorText = Color.grey;
    [SerializeField] private Color SubtractionColorText = Color.grey;
    private float fadeTime = 0.8f;
    private float colorTime = 0.4f;
    private Coroutine fadeRoutine = null;
    private Coroutine colorChangeRoutine = null;

    void Start(){
        Hide();
    }

    void Update(){

    }
    public void SetFadeTime(float value){
        this.fadeTime = value;
    }
    private void PopupMessage(string message, Color color){
        changeIndicator.text = message;
        Show();
        if(colorChangeRoutine!=null){
            StopCoroutine(colorChangeRoutine);
            colorChangeRoutine=null;
        }
        if(fadeRoutine!=null){
            StopCoroutine(fadeRoutine);
            fadeRoutine=null;
        }
        colorChangeRoutine = StartCoroutine(ColorChangeCoroutine(color));
        fadeRoutine = StartCoroutine(FadeCoroutine());
    }

    public void Popup_Addition(float value){
        if(value>0){
            string message = "+ " + value;
            PopupMessage(message, AdditionColorText);            
        }
    }

    public void Popup_Subtraction(float value){
        if(value>0){
            string message = "- " + value;
            PopupMessage(message, SubtractionColorText);            
        }
    }

    IEnumerator FadeCoroutine(){
        yield return new WaitForSeconds(fadeTime);
        Hide();
    }

    IEnumerator ColorChangeCoroutine(Color value){
        changeIndicator.color = value;
        yield return new WaitForSeconds(colorTime);
        changeIndicator.color = defaultTextColor;     
    }

    private void Show(){
        if(changeIndicator.IsActive() == false){
            changeIndicator.gameObject.SetActive(true);  
        }      
    }
    private void Hide(){
        changeIndicator.gameObject.SetActive(false);        
    }


}
