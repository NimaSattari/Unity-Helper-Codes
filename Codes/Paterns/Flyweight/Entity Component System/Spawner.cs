using Unity.Entities;

public struct Spawner : IComponentData
{
    //For ESC to work you need to change Api compatibility level to .Net 4
    //Import Packages #Entities and #HybridRenderer

    public Entity Prefab;
    public int Erows;
    public int Ecols;
}
