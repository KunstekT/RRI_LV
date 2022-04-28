using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int breakableCount = 0;
    [SerializeField] private LivesManager livesManager;
    private BrickCounter brickCounter;

    void Start(){
        livesManager = GameObject.FindObjectOfType<LivesManager>();

        breakableCount = GameObject.FindGameObjectsWithTag("Breakable").Length;
        brickCounter = GameObject.FindGameObjectWithTag("BrickCounter").GetComponent<BrickCounter>();
        brickCounter.SetText(breakableCount.ToString());
    }
    public void LoadLevel(string Name){
        breakableCount = 0;
        SceneManager.LoadScene(Name);
    }
    public void QuitRequest(){
        Application.Quit();        
    }
    
    public void LoadNextLevel(){
        breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed(){
        breakableCount--;
        brickCounter.SetText(breakableCount.ToString());
        if( breakableCount <= 0){
            LoadNextLevel();
        }
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
        livesManager.Initialize();
    }
}
