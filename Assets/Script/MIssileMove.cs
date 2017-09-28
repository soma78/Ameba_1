using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIssileMove : MonoBehaviour {
    public Transform parent;
    public float m_Power;

    private float m_elapsedTime = 0f;
    private float m_MovingSpeed = 50f;
    private float lifeTime = 3f;

    void Start()
    {
        m_Power = 40f;
        //Invoke("PushtoPool", 2f);
        //Invoke로 했더니 원하는데로 작동안한다. 새로운 불렛이 생성된다.
        //그래서 elaspedTime과 lifeTime으로 했더니 제대로 작동한다.
        parent = GameObject.Find("ObjectPoolingManager").transform;
    }

    void PushtoPool()
    {
        
        Debug.Log("PushtoPool !!");
        
    }

    void Update()
    {
        transform.Translate(Vector2.up * m_MovingSpeed * Time.deltaTime);
        if(GetTimer() > lifeTime)
        {
            ResetTimer();
            ObjectPoolingManager.Instance.PushToPool("Bullet", gameObject, parent);
        }

    }

    float GetTimer()
    {
        return (m_elapsedTime += Time.deltaTime);
    }
    void ResetTimer()
    {
        m_elapsedTime = 0f;
    }
}
