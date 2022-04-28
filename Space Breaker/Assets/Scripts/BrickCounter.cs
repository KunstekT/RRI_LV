using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickCounter : MonoBehaviour
{
    private Text counter;
    // Start is called before the first frame update
    public void SetText(string text){
        if(counter==null){
            counter = this.GetComponent<Text>();
        }
        counter.text = text;
    }
}
