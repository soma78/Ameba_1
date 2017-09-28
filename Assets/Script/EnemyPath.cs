using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyPath : MonoBehaviour {

    public GameObject m_Player;
    public List<Transform> pathList = new List<Transform>();
    public Vector3[] pathArray = new Vector3[3]; //배열은 선언할떄 갯수 도 포함해야 된다.

    void Start()
    {
        
    }

    public void DoPath()
    {
        for (int i = 0; i < 4; i++)
        {
            string name = "path" + i.ToString();
            GameObject obj = GameObject.Find(name);
            //Debug.Log(obj.transform.position);
            pathList[i] = obj.transform;
            //Debug.Log(pathList[i]);
        }

        for (int i = 0; i < pathList.Count; i++)
        {
            //이부분에서 1시간 해맴~ Vector3(pathList.position)으로 하면 안되고, x,y,z를 풀어야 된다.
            pathArray[i] = new Vector3(pathList[i].position.x, pathList[i].position.y, pathList[i].position.z);
        }
        m_Player = GameObject.Find("Player");
        m_Player.transform.DOPath(pathArray, 5f, PathType.Linear, PathMode.TopDown2D);
    }
}
