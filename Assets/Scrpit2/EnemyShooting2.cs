using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting2 : MonoBehaviour {

    //public GameObject m_bulletPrefab;
    private float m_movignSpeed = 300f;

    void Start()
    {
        //Tip : 30분 해맴--> 시작 부분에서만 생성해주니까. 생성 한번만하고, 계속 새로 생성됨
        //즉 아래  Instantiate하기 전에 Pop해줘야 된다.
        //m_bulletPrefab = ObjectPoolingManager.Instance.PopFromPool("Bullet");
        StartCoroutine(Burst(20f, 5));
    }
    
    IEnumerator Burst(float oneShoting, int shotCount)
    {
        float angle = 306 / oneShoting;
        do
        {
            for (int i = 0; i < oneShoting; i++) 
            {
                //Start가 아니라 여기서 PopFromPool해줘야 한다.
                GameObject m_bulletPrefab = ObjectPoolingManager.Instance.PopFromPool("Bullet");
                GameObject obj = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);
                obj.SetActive(true);
                obj.name = "Bullet";
                    obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(m_movignSpeed*Mathf.Cos(Mathf.PI*2*i/oneShoting),
                        m_movignSpeed*Mathf.Sin(Mathf.PI*2*i/oneShoting)));
                obj.transform.Rotate(new Vector3(0f, 0f, 360 * i / oneShoting - 90));

            }
            yield return new WaitForSeconds(2f);
            shotCount--;
        } while (shotCount > 0);
    }

    
}
