using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove1 : MonoBehaviour {

    public Transform m_poolingManager;
    public Transform m_bulletsParent;

    private float m_bulletIntervalTime = 0.3f;

    void Start()
    {
        m_poolingManager = GameObject.Find("ObjectPoolingManager").transform;
        InvokeRepeating("Shooting", 1f, m_bulletIntervalTime);
    }

    void Shooting()
    {
        GameObject obj = ObjectPoolingManager.Instance.PopFromPool("Bullet");
        obj.transform.position = transform.position;
        obj.name = "Bullet";
        //obj.transform.SetParent(m_bulletsParent);
        obj.SetActive(true);
    }

}
