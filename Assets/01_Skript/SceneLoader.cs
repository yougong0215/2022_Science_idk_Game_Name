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
    }

    public void extititi()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator A(string a)
    {
        t += 100;

        yield return new WaitForSeconds(0.01f);
        SceneManager.LoadScene(a);
    }
}
