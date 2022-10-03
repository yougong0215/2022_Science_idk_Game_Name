using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class asdfasasf : Singleton<asdfasasf>
{
    [SerializeField] Image I;
    public void Damaged()
    {
        I.fillAmount -= 0.10f;
    }
    private void Update()
    {
        if(I.fillAmount == 0)
        {
            SceneManager.LoadScene("End");
        }
    }
}
