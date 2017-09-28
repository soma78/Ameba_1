using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PooledObject2 {

    public string pooledObjectName = string.Empty;
    public int poolingCount = 0;
    public GameObject prefab = null;

    [SerializeField]
    private List<GameObject> poolList = new List<GameObject>();

    public void Init(Transform parent)
    {
        for (int i = 0; i < poolList.Count; i++)
        {
            poolList.Add(CreatePooledObject(parent));
            
        }
    }

    public GameObject PopFromPool(Transform parent = null)
    {
        if(poolList.Count == 0)
        {
            poolList.Add(CreatePooledObject(parent));
        }

        GameObject obj = poolList[0];
        poolList.RemoveAt(0);
        return obj;
    }

    public void PushToPool(GameObject obj, Transform parent)
    {
        poolList.Add(obj);
        obj.transform.SetParent(parent);
        obj.SetActive(false);
    }

    public GameObject CreatePooledObject(Transform parent)
    {
        GameObject obj = Object.Instantiate(prefab) as GameObject;
        obj.name = pooledObjectName;
        obj.transform.SetParent(parent);
        obj.SetActive(false);

        return obj;


    }
}

