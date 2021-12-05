using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public Vector3 SpawnStartPosition;

    void Start()
    {
        if(SpawnStartPosition == Vector3.zero)
        {
            SpawnStartPosition = transform.position;
        }
    }


    void Update()
    {
        
    }
}
