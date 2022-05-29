using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Scene scene;
    [SerializeField]float spawnDelay = 5f;
    [SerializeField]float spawnDelayRandomnessFactor = 0.2f;
    [SerializeField]List<Collectible> collectiblesToSpawn;
    [SerializeField]float RandomSpawnFactor=0.5f;
    [SerializeField]EnemySpawner spawner;
    int TotalNumberOfEnemiesToDestroy=0;
    int EnemiesToDestroyCount=0;    


    void Start(){
        if(spawner!=null){
            TotalNumberOfEnemiesToDestroy=spawner.GetEnemyCount();
            EnemiesToDestroyCount=TotalNumberOfEnemiesToDestroy;
        }
        scene = SceneManager.GetActiveScene();
        if(scene.name=="Level 1")
        StartCoroutine(SpawnCollectibleCoroutine(collectiblesToSpawn[Random.Range(0,collectiblesToSpawn.Count)]));

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

    IEnumerator SpawnCollectibleCoroutine(Collectible collectible){
        Instantiate(collectible.gameObject, GetRandomPosition(), Quaternion.identity);
        yield return new WaitForSeconds(spawnDelay+spawnDelay*Random.Range(0-spawnDelayRandomnessFactor,0+spawnDelayRandomnessFactor));
        StartCoroutine(SpawnCollectibleCoroutine(collectiblesToSpawn[Random.Range(0,collectiblesToSpawn.Count)]));
     }

    private Vector3 GetRandomPosition(){
        return new Vector3(0f+Random.Range(-5f, 5f),
        0f+Random.Range(-7f, 2f),
        0f);
    }

    public void ReduceEnemyCount(){
        EnemiesToDestroyCount--;
        if(EnemiesToDestroyCount<=0){
            Debug.Log(EnemiesToDestroyCount);
            LoadLevel("Victory");
        }
    }
}
