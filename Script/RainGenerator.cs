using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGenerator : MonoBehaviour
{


    public GameObject RainPrefab;
    float span = 1.0f;
    float delta = 0;


    // Update is called once per frame

    // RainPrefab을 x값 -6 ~ 7, y값 60 높이에서 계속 생성시킴.
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(RainPrefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 60, 0);
        }
    }
}