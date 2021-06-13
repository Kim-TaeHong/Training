using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject hpGage;

    // Start is called before the first frame update
    void Start()
    {
        this.hpGage = GameObject.Find("hpGage");
    }

    //Hp 감소 함수
    public void DecreaseHp()
    {
        this.hpGage.GetComponent<Image>().fillAmount -= 0.1f;
        if(hpGage.GetComponent<Image>().fillAmount <= 0.1)
        {
            SceneManager.LoadScene("GameTitle");
        }
    }

    //Hp 증가 함수
    public void IncreaseHp()
    {
        this.hpGage.GetComponent<Image>().fillAmount += 0.5f;
    }

    //보스몹의 hp 감소 함수
    public void Boss()
    {
        this.hpGage.GetComponent<Image>().fillAmount -= 0.3f;
        if (hpGage.GetComponent<Image>().fillAmount <= 0.1)
        {
            SceneManager.LoadScene("GameTitle");
        }
    }

}
