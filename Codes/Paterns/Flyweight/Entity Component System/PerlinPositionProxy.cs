using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[RequiresEntityConversion]
public class PerlinPositionProxy : MonoBehaviour, IConvertGameObjectToEntity
{
    //For ESC to work you need to change Api compatibility level to .Net 4
    //Import Packages #Entities and #HybridRenderer
    //Add this and #ConvertToEntity Component to the gameobject(cube) and make a prefab of it

    public void Convert(Entity entity, EntityManager dstManager, GameObjcetConversionSystem conversionSystem)
    {
        var data = new PerlinPosition { };
        dstManager.AddComponentData(entity, data);
    }
}
