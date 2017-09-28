using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance  
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public GameObject m_Player;
    public int m_score;
    public Text m_ScoreText;
    public GameObject m_enemyPrefab;
    public List<GameObject> ItemList = new List<GameObject>();

    //public List<Sprite> testSpirteList = new List<Sprite>();

    private float duration = 1.4f;

    void Start()
    {
        //SpriteInitLoading();
        InitItemList();
        m_score = 0;
        InvokeRepeating("CreateEnemy", 2f, 2f);
    }

    //아래는 작동안한다. (SPrite[])가 아니라. <SPrite>로 해야 되는듯.....
    //private void SpriteInitLoading()
    //{
    //    Sprite[] sprites = (Sprite[])Resources.LoadAll("Sprite", typeof(Sprite));
    //    foreach(Sprite sprite in sprites)
    //    {
    //        testSpirteList.Add(sprite);
    //    }
    //}

    private void InitItemList()
    {
        GameObject[] temp = Resources.LoadAll<GameObject>("2");
        foreach(GameObject obj in temp)
        {
            ItemList.Add(obj);
        }
    }
    private void CreateEnemy()
    {
        Vector2 spwanPos = new Vector2(Random.Range(-24f, 24f), Random.Range(58f, 70f));
        GameObject obj = (GameObject)Instantiate(m_enemyPrefab, spwanPos, Quaternion.identity);       
    }

    public void ScoreUp(int value)
    {
        int target = m_score + value;
        StopCoroutine("CountRollingTo");
        StartCoroutine("CountRollingTo", target);
        UpdateScoreText();
    }

    IEnumerator CountRollingTo(int target)
    {
        int start = m_score;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            m_score = (int)Mathf.Lerp(start, target, progress);
            yield return null;
            UpdateScoreText();

        }
        m_score = target;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        //m_ScoreText.text = "Score :" + (m_score/1000).ToString("0.#K");
        m_ScoreText.text = "Score :" + m_score.ToString("n0");
    }

    public void CreateItem(Transform pos)
    {
        int rand = Random.Range(0, ItemList.Count);
        GameObject obj = Instantiate(ItemList[rand], pos.position, Quaternion.identity);
        obj.name = "item" + rand.ToString();
        obj.transform.SetParent(this.transform);
    }
    //=========================================
    //DOTween 연습

    public void DoColor()
    {
        m_Player = GameObject.Find("Player");
        Renderer renderer = m_Player.GetComponent<Renderer>();
        renderer.material.DOColor(Color.red, 3f).OnComplete(()=>
        {
            renderer.material.color = Color.white;
            DOShakePosition();
        });
    }

    //Tip : 아래처럼 scale 바꿔주는것 말고도 transform.DoShakePosition쓸수도 있음

    public void DoScale()
    {
        m_Player = GameObject.Find("Player");
        m_Player.transform.DOScale(new Vector3(1.5f, 1.5f, 1), 0.5f).SetLoops(2).OnComplete(() =>
        {
            m_Player.transform.localScale = Vector3.one;
        });
    }

    public void DOShakePosition()
    {
        Camera.main.DOShakePosition(1f, 1.3f, 10, 90, false);
    }
    
}
