using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour {

    #region //SingleTon
    private static GameManager1 instance;
    public static GameManager1 Instance
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

    #endregion

    public int m_Score;
    public Text m_ScoreText;
    public GameObject m_enemyPrefab;
    public List<GameObject> m_enemyList = new List<GameObject>();
    public Color m_offColor = new Color(0.72f, 0.65f, 0.978f,0.8f);
    public Color m_OnColor = Color.white;

    public GameObject m_word1;
    public GameObject m_word2;
    public GameObject m_word3;

    public int[] answers;

    public bool isCorrect_1 = false;
    public bool isCorrect_2 = false;
    public bool isCorrect_3 = false;
    public GameObject UI_Panel;


    private float rollingNumInterval = 1f;
    void Start()
    {
        UI_Panel.SetActive(false);
        Screen.SetResolution(800, 1280, true);
        InitWord();
        SetWordColor();
        SetWordAnswer();
        //Debug.Log(m_offColor);
        m_Score = 0;
        m_ScoreText.text = "Score : " + m_Score.ToString("n0");
        StartCoroutine(CreateEnemy());
        //InvokeRepeating("CreateEnemy",1f, 1f);
        //Random인터벌로 CreateEnemy하려면, StartCoroutine하고, 
        //while(true)안에서 yield return new WaitForSecond 사용한다.
        SetStageWord();
    }

    void InitWord()
    {
        //for (int i = 0; i < 3; ++i)
        //{
        //    string defaultName = "m_word";
        //    defaultName = string.Format(defaultName, i.ToString());
        //  여기서 포기!!! 그냥 하드코딩함.    
        m_word1 = GameObject.Find("targetImage1");
        m_word2 = GameObject.Find("targetImage2");
        m_word3 = GameObject.Find("targetImage3");
    }

    void SetWordColor()
    {
        m_word1.GetComponent<SpriteRenderer>().color = m_offColor;
        m_word2.GetComponent<SpriteRenderer>().color = m_offColor;
        m_word3.GetComponent<SpriteRenderer>().color = m_offColor;
    }

    void SetWordAnswer()
    {
        answers = new int[3];
        for (int i = 0; i < answers.Length; i++)
        {
            answers[0] = 0;
            answers[1] = 1;
            answers[2] = 2;
        }
    }

    public bool CheckAnswer(int value, Sprite _sprite)
    {
        if(value == answers[0])
        {
            if (!isCorrect_1)
            {
                isCorrect_1 = true;
                
                m_word1.GetComponent<SpriteRenderer>().color = m_OnColor;
                m_word1.GetComponent<SpriteRenderer>().sprite = _sprite;
                return true;
            }
        }

        if (value == answers[1])
        {
            if (!isCorrect_2)
            {
                isCorrect_2 = true;
                
                m_word2.GetComponent<SpriteRenderer>().color = m_OnColor;
                m_word2.GetComponent<SpriteRenderer>().sprite = _sprite;
                return true;

            }
        }

        if (value == answers[2])
        {
            if (!isCorrect_3)
            {
                isCorrect_3 = true;
                
                m_word3.GetComponent<SpriteRenderer>().color = m_OnColor;
                m_word3.GetComponent<SpriteRenderer>().sprite = _sprite;
                return true;

            }
        }
        return false;
    }

    IEnumerator CreateEnemy()
    {
        do
        {
            Vector2 spwanPos = new Vector2(Random.Range(-30f, 30f), Random.Range(55f, 70f));

            //GameObject obj = Instantiate(m_enemyList[Random.Range(0, m_enemyList.Count)], spwanPos, Quaternion.identity);
            GameObject obj = Instantiate(m_enemyList[1], spwanPos, Quaternion.identity);
            //Debug.Log("ID : " + obj.GetComponent<Enemy2>().m_enemyWordId.ToString());
            yield return new WaitForSeconds(Random.Range(0, 3f));
        } while (true);
    }

    void Update()
    {
        if (isCorrect_1 && isCorrect_2 && isCorrect_3)
        {
            UI_Panel.SetActive(true);
        }
    }

    void SetStageWord()
    {

    }

    public void reLoadGame()
    {
        SceneManager.LoadScene(1);
    }



}
