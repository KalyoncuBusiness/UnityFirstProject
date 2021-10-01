 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public int platformSpawnCount;

    public Vector3 lastEndPoint;



    public void SpawnPlatforms()
    {
        for (int i = 0; i < platformSpawnCount; i++)
        {
            GameObject platform = GameObject.Instantiate(platformPrefab);
            Platform platformScript = platform.GetComponent<Platform>();

            platform.transform.position = lastEndPoint;

            lastEndPoint = platformScript.ReturnEndPoint();
        }



    }

    void Start()
    {
        SpawnPlatforms();
    }


}
