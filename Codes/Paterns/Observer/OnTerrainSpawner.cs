using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTerrainSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Terrain terrain;
    TerrainData terrainData;
    public Event prefabDrop;

    void Start()
    {
        terrainData = terrain.terrainData;
        InvokeRepeating("CreatePrefab", 1f, 2f);
    }

    void CreatePrefab()
    {
        int x = (int)Random.Range(0, terrainData.size.x);
        int z = (int)Random.Range(0, terrainData.size.z);
        Vector3 pos = new Vector3(x, 0, z);
        pos.y = terrain.SpampleHeight(pos) + 10;
        GameObject prefabInstance = Instantiate(prefab, pos, Quaternion.identuty);
        prefabDrop.Occurred(prefabInstance);
    }
}
