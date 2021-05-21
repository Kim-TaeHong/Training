using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    GameObject Snake;

    // Start is called before the first frame update
    void Start()
    {
        this.Snake = GameObject.Find("Snake");
    }

    // Update is called once per frame

    //"Snake"객체와 충돌을 감지하면 DecresaeHp에 알림
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Snake")
        {
            Destroy(gameObject);

            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
        }
    }
}
