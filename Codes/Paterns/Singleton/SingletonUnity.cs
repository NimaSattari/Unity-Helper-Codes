using System;

public class SingletonUnity : MonoBehaviour
{
    public static SingletonUnity Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
}
