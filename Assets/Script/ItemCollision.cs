using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Item1,
    Item2,
    Item3
}

public class ItemCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.name);
        //Item과 item 대소문자 구별못해서 20분 해맴
        switch (col.name)
        {
            
            case "item0":
                //GetComponent<ShootingMissile>().SpeedUpItem();
                ItemCollect(col, 10);
                break;
            case "item1":
                ItemCollect(col, 100);
                break;
            case "item2":
                ItemCollect(col, 500);
                break;
            default:
                Debug.Log("Item Name Error");
                break;

        }
    }

    private void ItemCollect(Collider2D col, int score)
    {
        Destroy(col.gameObject);
        GameManager.Instance.ScoreUp(score);
        GameManager.Instance.DoScale();
        Debug.Log("1000");
    }
}
