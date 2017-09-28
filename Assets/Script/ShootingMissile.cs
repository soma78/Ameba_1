using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMissile : MonoBehaviour {

    public GameObject m_missilePrefab;
    public Transform m_pollingManager;
    //public Transform[] m_shootingPos;
    void Start()
    {
        NormalShooting();
    }

    public void NormalShooting()
    {
        InvokeRepeating("Shooting", 1f, 0.3f);
    }

    public void SpeedUpItem()
    {
        CancelInvoke();
        InvokeRepeating("Shooting", 0.1f, 0.1f);
    }

    void Shooting()
    {
        GameObject bullet = ObjectPoolingManager.Instance.PopFromPool("Missile", m_pollingManager);

        //이동시키는 아래 줄 빼먹어서, 30분동안 해맸음. 총알이 pool에는 있는데 안나옴.
        //안나오던게 아니고, 사라졌던 자리에서 계속 이어서 나가고 있었음...
        bullet.transform.position = transform.position + transform.up;
        bullet.SetActive(true);
        //Instantiate(m_missilePrefab, transform.position, Quaternion.identity);

    }
}
