using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameWin(){
        SceneManager.LoadScene("Victory");
    }

    public void LoadGameLost(){
        SceneManager.LoadScene("Defeat");
    }

    public void LoadLevel(int level){
        SceneManager.LoadScene("Level"+level);
    }

    public void RequestQuit(){
        Application.Quit();
    }
}
