using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SCores : Singleton<SCores>
{
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI score;
    int Intscore = 0;
    float sec;
    int min = 0;
    private void Update()
    {
        score.text = "Score : " + Intscore;
        PlayerPrefs.SetInt("Score", Intscore);
        sec += Time.deltaTime;
        
        if(sec > 60)
        {
            sec -= 60;
            min++;
        }
        time.text = $"0{min} : {(int)sec}";

        if(Intscore >= 2000)
        {
            SceneManager.LoadScene("End");
        }
    }
    public int returnScore()
    {
        return Intscore;
    }
    public void GetScore()
    {
        Intscore += 100;
    }
}
