using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    private Image heart1;
    private Image heart2;
    private Image heart3;
    Color defaultColor = new Color(1f,1f,1f,1f);
    Color invisColor = new Color(0f,0f,0f,0f);

    private readonly int maxLives = 3;
    int livesLeft = 3;

    public void ReduceLifeCount(){
        livesLeft--;
        EditHearts();
    }

    private void EditHearts(){
        if(livesLeft == 0){EditHeartsColors(invisColor,invisColor,invisColor);}
        else if(livesLeft == 1){EditHeartsColors(defaultColor,invisColor,invisColor);}
        else if(livesLeft == 2){EditHeartsColors(defaultColor,defaultColor,invisColor);}
        else if(livesLeft == 3){EditHeartsColors(defaultColor,defaultColor,defaultColor);}    
    }

    private void EditHeartsColors(Color c1,Color c2,Color c3){
        heart1.color = c1;
        heart2.color = c2;
        heart3.color = c3;
    }

    public int GetLivesCount(){
        return livesLeft;
    }

    public bool IsGameOver(){
        if(GetLivesCount()<=0){
            return true;
        }
        else{
            return false;
        }
    }

    private void InitializeHearts(){
        
        heart1 = GameObject.FindGameObjectWithTag("heart1").GetComponent<Image>();
        heart2 = GameObject.FindGameObjectWithTag("heart2").GetComponent<Image>();
        heart3 = GameObject.FindGameObjectWithTag("heart3").GetComponent<Image>();

    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    void Awake(){

    }
    public void Initialize(){
        InitializeHearts();
        Debug.Log("LIVES LEFT: "+ livesLeft);
        EditHearts();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
