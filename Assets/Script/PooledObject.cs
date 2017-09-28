using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PooledObject
{

    public string pooledObjectname = string.Empty; //객체를 검색할때 사용할 이름
    public int poolingCount = 0; //초기화할때 생성할 개체수
    public GameObject prefab = null;

    [SerializeField]
    private List<GameObject> poolList = new List<GameObject>();

    public void Init(Transform parent= null)
    {
        for (int i = 0; i < poolingCount; ++i)
        {
            poolList.Add(CreatePooledObject(parent));
        }
    }

    public void PushToPool(GameObject obj, Transform parent= null)
    {
        poolList.Add(obj);
        
        obj.SetActive(false);

        obj.transform.SetParent(parent);
    }

    //public GameObject PopFromPool(string name, Transform parent)
    public GameObject PopFromPool(Transform parent = null)
    {
        if (poolList.Count == 0)
        {
            poolList.Add(CreatePooledObject(parent));
        }

        GameObject obj = poolList[0];
        //poolList.RemoveAt[0]; TIP : []게 아니고 ()로 해야 된다.
        poolList.RemoveAt(0);
        return obj;
    }

    public GameObject CreatePooledObject(Transform parent=null)
    {
        GameObject obj = (GameObject)Object.Instantiate(prefab);
        obj.name = pooledObjectname;
        obj.transform.SetParent(parent);
        obj.SetActive(false);

        return obj;
    }

}