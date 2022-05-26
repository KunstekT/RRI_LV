using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Scene scene;
    [SerializeField]List<float> spawnDelays;
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
        int index=0;
        if(spawnDelays!=null){
            foreach(float spawnDelay in spawnDelays){
                if(index>=collectiblesToSpawn.Count)break;
                StartCoroutine(SpawnCollectibles(spawnDelay, collectiblesToSpawn[Random.Range(0,collectiblesToSpawn.Count-1)]));
                index++;
            }
        }
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

    IEnumerator SpawnCollectibles(float spawnDelay, Collectible collectible){
        yield return new WaitForSeconds(spawnDelay);
        SpawnCollectible(collectible);
    }

    void SpawnCollectible(Collectible collectible){
        Instantiate(collectible.gameObject, GetRandomPosition(), Quaternion.identity);
    }

    private Vector3 GetRandomPosition(){
        return new Vector3(0f+Random.Range(RandomSpawnFactor*(-5.14f), RandomSpawnFactor*5.14f),0f+Random.Range(RandomSpawnFactor*(-5f), RandomSpawnFactor*2f),0f);
    }

    public void ReduceEnemyCount(){
        EnemiesToDestroyCount--;
        if(EnemiesToDestroyCount<=0){
            Debug.Log(EnemiesToDestroyCount);
            LoadLevel("Victory");
        }
    }
}
