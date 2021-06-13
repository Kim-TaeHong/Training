using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PeopleScore : MonoBehaviour
{
    public Text text;
    int peopleScore;
    private EnemyScore enemyScore;

    // Start is called before the first frame update
    void Start()
    {
        enemyScore = FindObjectOfType<EnemyScore>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "People :" + peopleScore.ToString();
    }

    // 사람 점수판 txt 컨트롤
    public void IncreasePeople()
    {
        peopleScore += 1;

        if(peopleScore >= 3 && enemyScore.enemyScore >= 20)
        {
            SceneManager.LoadScene("ClearScene");
            Debug.Log("끝");
        }
    }
}
