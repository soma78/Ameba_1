using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Toast : MonoBehaviour
{

}

public class ShootingMissile1 : MonoBehaviour
{

    float fevertime = 5f;

    public Transform m_poolingManager;

    public void NormalShotting()
    {
        InvokeRepeating("Shooting", 1f, 0.3f);
    }

    public void SpeepdUpShooting()
    {
        StartCoroutine(SpeedUp(4f));
    }

    IEnumerator SpeedUp(float _time)
    {
        
        while(fevertime < _time)
        {

        }
        yield return null;
    }


    void Shooting()
    {
        GameObject bullet = ObjectPoolingManager.Instance.PopFromPool("Missile", m_poolingManager);

        bullet.transform.position = transform.position + transform.up;
        bullet.SetActive(true);
    }
}