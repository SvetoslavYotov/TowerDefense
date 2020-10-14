using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    Vector3 snapPos;
    [SerializeField][Range(1f, 20f)] float gridSize = 10f;

    void Update()
    {
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }

}
