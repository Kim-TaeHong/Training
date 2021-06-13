using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScore : MonoBehaviour
{
    public Text text;
    public int enemyScore;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }


    void Update()
    {
        text.text = "Enemy :" + enemyScore.ToString();
    }

    //enemy 점수판 컨트롤
    public void IncreaseEnemy()
    {
        enemyScore += 1;
    }
}
