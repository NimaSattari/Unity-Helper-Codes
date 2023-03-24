using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 speed;

    private IObjectPool<Bullet> bulletPool;

    public void SetPool(IObjectPool<Bullet> pool)
    {
        bulletPool = pool;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        bulletPool.Release(this);
    }
}