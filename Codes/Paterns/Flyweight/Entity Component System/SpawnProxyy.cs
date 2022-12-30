using System;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnProxyy : MonoBehaviour, IConvertGameObjectToEntity, IConvertGameObjectToEntity
{
    //For ESC to work you need to change Api compatibility level to .Net 4
    //Import Packages #Entities and #HybridRenderer
    //Add this and #ConvertToEntity Component to the gameobject(Spawner) and put prefabed cube(the one that has PerlinPositionProxy) in it

    public GameObject cube;
    public int rows;
    public int cols;

    public void DeclareRefrencedPrefabs(List<GameObject> gameObjects)
    {
        gameObjects.Add(cube);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjcetConversionSystem conversionSystem)
    {
        var spawnerData = new Spawner
        {
            Prefab = conversionSystem.GetPrimaryEntity(cube),
            Erows = rows,
            Ecols = cols
        };
        dstManager.AddComponentData(entity, spawnerData);
    }
}
