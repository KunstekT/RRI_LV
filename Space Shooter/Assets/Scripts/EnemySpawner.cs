using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        WaveConfig currentWave = waveConfigs[0]; 
        do{
            yield return StartCoroutine(SpawnAllWaves());
        }while(looping);

    }

    private IEnumerator SpawnAllWaves(){
        for(int x = 0; x< waveConfigs.Count;x++){
            var currentWave = waveConfigs[x];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig){
        for(int enemyCount=0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++){                     
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns()+
                Random.Range(
                    -waveConfig.GetSpawnRandomFactor()*waveConfig.GetTimeBetweenSpawns(),
                    waveConfig.GetSpawnRandomFactor()*waveConfig.GetTimeBetweenSpawns())
                    );

        }
    }

    public int GetEnemyCount(){
        int counter=0;
        foreach(WaveConfig wc in waveConfigs){
            counter+=wc.GetNumberOfEnemies();
        }
        return counter;
    }
}
