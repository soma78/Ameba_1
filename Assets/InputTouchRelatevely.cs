using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchRelatevely : MonoBehaviour
{
    public const float M_MAX_X = 28f;
    public const float M_MIN_X = -28f;

    public Transform m_PlayerTr;

    private float m_offsetDistance;

    void Start()
    {
        m_PlayerTr = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            m_offsetDistance = pos.x - m_PlayerTr.position.x;
        }else if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            m_PlayerTr.position = new Vector3(Mathf.Clamp(pos.x - m_offsetDistance, M_MIN_X, M_MAX_X),
                -32f, -1f);

        }
    }

}
