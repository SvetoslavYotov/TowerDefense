using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoint = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        
        ProcessHit();
        if (hitPoint < 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoint -= 1;
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
