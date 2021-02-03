using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParent;

    Queue<Tower> towers = new Queue<Tower>();
    // Start is called before the first frame update
    
    public void AddTower(Waypoint baseWaypoint)
    {
        if (towers.Count < towerLimit)
        {
            InstantiateTowers(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
        
    }
    private void InstantiateTowers(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParent;
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
       
        towers.Enqueue(newTower);
    }
    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towers.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;

        oldTower.baseWaypoint = newBaseWaypoint;
        newBaseWaypoint.isPlaceable = false;

        oldTower.transform.position = newBaseWaypoint.transform.position;

        towers.Enqueue(oldTower);
    }

   
}
