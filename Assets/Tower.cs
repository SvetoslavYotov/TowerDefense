using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetedEnemy;
    [SerializeField] float attackRange = 10.0f;
    [SerializeField] ParticleSystem projectilePartile;


    // Update is called once per frame
    void Update()
    {
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
