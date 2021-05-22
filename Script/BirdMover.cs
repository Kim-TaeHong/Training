using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMover : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform desPos;
    public float speed;

    // Start is called before the first frame update

    //박쥐의 위치는 startPos, desPos는 endPos의 position값으로 초기화 시킴.
    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
    }

    // Update is called once per frame

    //박쥐가 desPos에 도착하면 desPos의 값을 startPos로 초기화 하여 그 사이를 왕복하게 만듦.

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);

        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        {
            if (desPos == endPos) desPos = startPos;
            else desPos = endPos;
        }
    }

}
