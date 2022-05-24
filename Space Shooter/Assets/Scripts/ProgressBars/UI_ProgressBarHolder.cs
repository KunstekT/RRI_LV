using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ProgressBarHolder : MonoBehaviour
{
    [SerializeField] List<UI_ProgressBar>uiProgressBars;
    [SerializeField] Image backgroundImage;
    
    public void Show(){
        backgroundImage.gameObject.SetActive(true);
        foreach(UI_ProgressBar progressBar in uiProgressBars){
            progressBar.Show();
        }
    }  
    public void Hide(){
        backgroundImage.gameObject.SetActive(false);
        foreach(UI_ProgressBar progressBar in uiProgressBars){
            progressBar.Hide();
        }
    }
}
