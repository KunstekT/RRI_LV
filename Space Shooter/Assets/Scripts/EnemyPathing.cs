using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;

    int waypointIndex = 0;
    bool forwardFlag = true;

    public void SetWaveConfig(WaveConfig wc){
        waveConfig = wc;
    }
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if(waypointIndex <= waypoints.Count && forwardFlag)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movingThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movingThisFrame);

            if(transform.position == targetPosition){
                waypointIndex++;
            }
            if(waypointIndex == waypoints.Count){
                if(waveConfig.IsReversing){
                    forwardFlag = false;
                    waypointIndex--;
                }
                else{
                    waypointIndex = 0;
                    Debug.Log("waypointIndex "+waypointIndex);
                }
            }
        }

        if(!forwardFlag)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movingThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movingThisFrame);

            if(transform.position == targetPosition){
                waypointIndex--;
            }
            if(waypointIndex == 0){
                forwardFlag = true;
            }
        }
    }
}
