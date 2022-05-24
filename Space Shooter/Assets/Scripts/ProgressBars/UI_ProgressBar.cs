using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI_ProgressBar : MonoBehaviour
{
    [SerializeField] protected Image ProgressBar;

    // warning: do not implement Start();

    public void SetBarFillAmount(float value){
        if(ProgressBar!=null){
            ProgressBar.fillAmount = value;
        }else{
            Debug.LogError("ProgressBar is null");
        }
    }

    public void SetColor(Color color){
        if(ProgressBar!=null){
            ProgressBar.color = color;
        }else{
            Debug.LogError("ProgressBar color is null");
        }
    }
    public void SetSprite(Sprite sprite){
        if(ProgressBar!=null){
            ProgressBar.sprite = sprite;
        }else{
            Debug.LogError("ProgressBar sprite is null");
        }
    }
    public void Show(){
        ProgressBar.gameObject.SetActive(true);
    }
    public void Hide(){
        ProgressBar.gameObject.SetActive(false);
    }
}
