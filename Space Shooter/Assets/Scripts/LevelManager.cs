using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Scene scene;

    void Start(){
        scene = SceneManager.GetActiveScene();
    }
    public void LoadLevel(string Name){
        SceneManager.LoadScene(Name);
    }
    public void RequestQuit(){
        Application.Quit();        
    }
    
    public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
        
    
    void OnEnable()
    {
    //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
    //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled.
    //Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        // Debug.Log("Level Loaded");
        // Debug.Log(scene.name);
        // Debug.Log(mode);
        if(scene.name == "Level 1"){            
            GameObject.FindGameObjectWithTag("Score").GetComponent<HighScoreManager>().ResetScore();
        }
    }
}
