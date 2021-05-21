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

    // DecreaseHP가 호출되면 fillAmount 값을 0.1씩 감소시키고 0이 되면 StartScene를 호출함.
    public void DecreaseHp()
    {
        this.hpGage.GetComponent<Image>().fillAmount -= 0.1f;

        if (this.hpGage.GetComponent<Image>().fillAmount == 0f)
        {
            SceneManager.LoadScene("StratScene");
        }
    }

    //creaseHP가 호출되면 fillAmount가 0.3 더해짐.

    public void CreaseHp()
    {
        this.hpGage.GetComponent<Image>().fillAmount += 0.3f;
    }
}
