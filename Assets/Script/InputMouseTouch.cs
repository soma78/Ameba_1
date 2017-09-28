using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouseTouch : MonoBehaviour {

    public float m_movingSpeed = 20;

    void Update()
    {

        if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width * 0.5f)
        {
            //Debug.Log("Right Clicked " + Input.mousePosition.x);
            Move(Vector2.right);

        }
        else if (Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width * 0.5f)
        {
            Move(Vector2.left);
        }
    }

    void Move(Vector2 _direction)
    {
        transform.Translate(_direction * m_movingSpeed * Time.deltaTime);

    }
}
