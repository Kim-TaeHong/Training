using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //시작과 동시에 "Snake" 오프젝트를 찾음.
        this.player = GameObject.Find("Snake");
    }

    // Update is called once per frame
    void Update()
    {
        //오프젝트의 x, y, z값에 따라 카메라의 포지션도 같이 변경됨.
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(
            transform.position.x, playerPos.y, transform.position.z);
    }
}

