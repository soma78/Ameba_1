using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour {

    public List<PooledObject> objectPool = new List<PooledObject>();
    #region SingleTon
    private static ObjectPoolingManager instance;
    public static ObjectPoolingManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    #endregion

    void OnEnable()
    {
        for (int i = 0; i < objectPool.Count; ++i)
        {
            objectPool[i].Init(gameObject.transform);
        }
    }
    

    public bool PushToPool(string itemName, GameObject obj, Transform parent = null)
    {
        PooledObject pool = GetPoolItem(itemName);
        if (pool == null) return false;

        pool.PushToPool(obj, parent == null ? transform : parent);
        return true;
    }

    public GameObject PopFromPool(string itemName, Transform parent= null)
    {
        PooledObject pool = GetPoolItem(itemName);
        if (pool == null) return null;

        return pool.PopFromPool(parent);
    }

    private PooledObject GetPoolItem(string itemName)
    {
        for (int i = 0; i < objectPool.Count ; ++i)
        {
            if (objectPool[i].pooledObjectname.Equals(itemName))
            {
                return objectPool[i];
            }
        }
        Debug.LogWarning("there is not matched pool List!!!!!");
        return null;
    }

}
