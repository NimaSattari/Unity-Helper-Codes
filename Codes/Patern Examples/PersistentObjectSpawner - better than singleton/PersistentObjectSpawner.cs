using UnityEngine;

public class PersistentObjectSpawner : MonoBehaviour
{
    // CONFIG DATA
    [Tooltip("This Prefab will only be spawned once and persisted between scenes.")]
    [SerializeField] GameObject presistantObjectPrefab = null;

    // PRIVATE STATE
    static bool hasSpawned = false;

    // PRIVATE
    private void Awake()
    {
        if (hasSpawned) return;
        SpawnPersistentObjects();
        hasSpawned = true;
    }

    private void SpawnPersistentObjects()
    {
        GameObject persistentObject = Instantiate(presistantObjectPrefab);
        DontDestroyOnLoad(persistentObject);
    }
}
