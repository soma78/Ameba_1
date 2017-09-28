using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouch : MonoBehaviour {

    public float m_movingSpeed = 50f;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

	void Update()
    {
        if(Input.GetMouseButton(0)&&Input.mousePosition.x > Screen.width * 0.5f)
        {
            Move(Vector2.right);
        }
        else if(Input.GetMouseButton(0)&Input.mousePosition.x < Screen.width * 0.5f)
        {
            Move(Vector2.left);
        }
    }

    void Move(Vector2 direction)
    {
        player.transform.Translate(direction * m_movingSpeed * Time.deltaTime);
    }
}
