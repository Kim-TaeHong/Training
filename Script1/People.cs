using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{

    //플레이어와 충돌시 객체 제거
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }       
    }
}
