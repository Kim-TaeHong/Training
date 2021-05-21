using System.Collections;
using UnityEngine;

public class RainController : MonoBehaviour
{


    GameObject Snake;

    // Start is called before the first frame update
    void Start()
    {
        this.Snake = GameObject.Find("Snake");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.05f, 0);

        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        //충돌을 감지

        Vector2 p1 = transform.position;
        Vector2 p2 = this.Snake.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        //충돌이 일어나면 객체를 없앤 후 GameDirector의 DecreaseHp에 알림.

        if (d < r1 + r2)
        {
            Destroy(gameObject);

            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
        }
    }
}