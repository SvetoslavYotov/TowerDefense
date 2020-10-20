﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int gridPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer TopMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        TopMeshRenderer.material.color = color;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
