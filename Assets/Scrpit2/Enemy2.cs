using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Enemy2 : MonoBehaviour {

    public int m_enemyWordId;
    public float m_MaxHp;
    public float m_currentHp;
    public Slider m_slider;
    public GameObject m_normalexplosionPrefab;
    public GameObject m_correctExplosionPrefab;
    public SpriteRenderer m_currentImage;

    public Sprite[] images;
    private bool isAnimation = false;
    void Start()
    {
        m_MaxHp = 100f;
        m_currentHp = 100f;
        InitImages();
        SetImage();
    }

    void InitImages()
    {
        images = Resources.LoadAll<Sprite>("word/");
        m_enemyWordId = Random.Range(0, 7);
    }

    void SetImage()
    {
        m_currentImage.sprite = images[m_enemyWordId];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Missile")
        {
            float damgePower = col.GetComponent<MIssileMove>().m_Power;
            SetDamage(damgePower);
            
            Destroy(col.gameObject);
            if(m_currentHp <= 0)
            {
                
                bool isCorrect;
                isCorrect = GameManager1.Instance.CheckAnswer(m_enemyWordId, m_currentImage.sprite);

                if (isCorrect)
                {
                    //isAnimation = true;

                    Destroy(GetComponent<Collider2D>());
                    //이부분이 중요함. Collider만 없애주려면 destory사용한다.
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    Instantiate(m_correctExplosionPrefab, transform.position, Quaternion.identity);
                    transform.DORotate(new Vector3(0, 0, 720), 1f, RotateMode.FastBeyond360).OnComplete(() =>
                    { 
                        Debug.Log("MOVING!@!!!");
                        transform.DOMove(new Vector2(0, -40), 5f);
                        Destroy(gameObject, 2.7f);
                        //isAnimation = false;
                    });
                }
                else if (!isCorrect) 
                {
                    //if (isAnimation) return;
                    Instantiate(m_normalexplosionPrefab, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                
                //Create Item from GameManager
            }
        }
    }

    void SetDamage(float power)
    {
        m_currentHp -= power;
       // Debug.Log("m_currentHp : " + m_currentHp);
        m_slider.value = m_currentHp / m_MaxHp;
    }


}
