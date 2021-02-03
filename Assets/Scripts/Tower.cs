using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Parameters of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectilePartile;

     public Waypoint baseWaypoint;

    //State of each tower
    Transform targetedEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetedEnemy)
        {
            objectToPan.LookAt(targetedEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0)
        {
            targetedEnemy = null;
            return; 
        }

        var closestEnemy = sceneEnemies[0].transform;
        
        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }

        targetedEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if ( distToA < distToB)
        {
            return transformA;
        }
        return transformB;
    }

    private void FireAtEnemy()
    {
        var distanceToEnemy = Vector3.Distance(targetedEnemy.transform.position, gameObject.transform.position);
        Shoot(distanceToEnemy <= attackRange ? true : false);
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectilePartile.emission;
        emissionModule.enabled = isActive;
    }
}
