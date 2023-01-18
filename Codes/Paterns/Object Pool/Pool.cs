//this code is usefull when a lot of the same object is getting created and destoryed fast
//for example a ship shooting bullets can use this code instead of regular Instatiating and destroying

//Wherever you wanted to Instatiate the object before use commented code bellow now
/*
    GameObject b = Pool.instance.Get("tag");
    if(b != null)
    {
        b.transform.position = this.transform.position;
        b.SetActive(true);
    }
*/
//Whereever you wanted to destroy the object instead use this
/*
    gameObject.SetActive(false);
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
    //prefab of the item you want to make
    public GameObject prefab;

    //the allowed amount of it in screen
    public int amount;

    //if you run out of objects and need more rightaway turn this to true
    public bool expandable;
}

public class Pool : MonoBehaviour
{
    public static Pool instance;

    //List of items you want to make
    public List<PoolItem> items;
    public List<GameObject> pooledItems;

    void Awake()
    {
        instance = this;
    }

    public GameObject Get(string tag)
    {
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if(!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
            {
                return pooledItems[i];
            }
        }
        foreach (var item in items)
        {
            if(item.prefab.tag == tag && item.expandable)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);
                return obj;
            }
        }
        return null;
    }

    void Start()
    {
        pooledItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);
            }
        }
    }
}
