using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;

    [SerializeField] float chasingRange = 5f;
    float distanceToTarget = Mathf.Infinity;

    bool IsProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, this.transform.position);
        if(IsProvoked){
            EngageTarget();
        }
        else if(distanceToTarget<=chasingRange){
            IsProvoked = true;
            // navMeshAgent.SetDestination(target.position);
        }
    }

    private void EngageTarget()
    {
        if(distanceToTarget>=navMeshAgent.stoppingDistance){
            ChaseTarget();
        }else{
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        Debug.Log(name+"attacking"+target.name);
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chasingRange);
    }
}
