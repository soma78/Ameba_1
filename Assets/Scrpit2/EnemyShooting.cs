using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject m_bulletPrefab;
    private Vector3 m_originPos;
    private float speed = 300f;

    void Start()
    {
        StartCoroutine(Burst1(30f,5));
        //InvokeRepeating("ChangeDirection", 0f, 2f);
        //StartCoroutine(Burst(m_player, m_bulletPrefab, 20, 3, 1.0f));
        m_originPos = transform.position;
    }

    IEnumerator Burst1(float oneShoting, int shotCount)
    {
        float anlge = 360 / oneShoting;
        do
        {
            for (int i = 0; i < oneShoting; i++)
            {
                GameObject obj = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);
                //obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(20f, 20f));
                //Rigidbody.AddForce를 쓰려면, Body Type이 Dynamic이여야 한다. kinetic이면 작동안함
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting),
                    speed * Mathf.Sin(Mathf.PI * 2 * i / oneShoting)));
                obj.transform.Rotate(new Vector3(0f, 0f, 306 * i / oneShoting - 90));

            }
            yield return new WaitForSeconds(2f);
            shotCount--;
        } while (shotCount > 0);

    }

    IEnumerator StartBulletPattern()
    {

        yield return null;
    }

    IEnumerator Blast(Transform shooter, Transform bulletTrans, int volly, float spread, float shotTime)
    {
        yield return null;
    }

    IEnumerator Sprial()
    {
        yield return null;
    }

    IEnumerator Burst(Transform shooter, GameObject bulletTrans, int shotNum, int shotCount, float intervalTime)
    {
        float bulletRot = 0.0f;
        while(shotCount > 0)
        {
            for (int i = 0; i < shotNum; i++)
            {
                Instantiate(bulletTrans, shooter.position, Quaternion.Euler(0, bulletRot, 0));
                bulletRot += 360 / shotNum;
            }
            bulletRot = 0.0f;
            shotCount--;
            yield return new WaitForSeconds(intervalTime);
        }
    }

    IEnumerator Flower()
    {
        yield return null;
    }

}