using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    [SerializeField] Image at;
    float t;
    public void Loader(string a)
    {
        SceneManager.LoadScene(a);
        StartCoroutine(A(a));
    }
    private void Update()
    {
        t = Time.deltaTime;
        at.color = new Color(0,0,0,t);
    }

    IEnumerator A(string a)
    {
        t += 100;

        yield return new WaitForSeconds(0.01f);
        SceneManager.LoadScene(a);
    }
}
