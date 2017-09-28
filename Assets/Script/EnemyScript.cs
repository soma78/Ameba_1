using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

    public float m_Maxhp;
    public float m_curentHp;
    public GameObject m_particleExplositionPrefab;
    public Slider m_hpBarSlider;

    void Start()
    {
        m_Maxhp = 100f;
        m_curentHp = 100f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Missile")
        {
            float _power = col.GetComponent<MIssileMove>().m_Power;
            //Debug.Log(_power.ToString());
            Damaged(_power);
            Destroy(col.gameObject);
            if (m_curentHp <= 0)
            {           
                Destroy(gameObject);
                //GameManager1.Instance.ScoreUp(500);
                Instantiate(m_particleExplositionPrefab, transform.position, Quaternion.identity);
                GameManager.Instance.CreateItem(this.transform);
            }
        }
    }

    public void Damaged(float _power)
    {
        m_curentHp -= _power;
        //Debug.Log(m_curentHp.ToString());
        //Debug.Log(m_Maxhp.ToString());
        m_hpBarSlider.value = m_curentHp / m_Maxhp;
    }
}
