using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour {

    private float m_movingSpeed= 10f;
    private float m_BGSpacing = 96f;

	void Update()
    {
        //Debug.Log("BGMoving is working");
        transform.Translate(Vector2.down * m_movingSpeed * Time.deltaTime);
        if(transform.position.y <= -m_BGSpacing)
        {
            transform.position= new Vector3(0,96f,1);
        }
    }
}
