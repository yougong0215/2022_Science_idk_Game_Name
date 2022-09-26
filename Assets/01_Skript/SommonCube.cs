using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SommonCube : MonoBehaviour
{
    [SerializeField] GameObject n;
    [SerializeField] GameObject p;

    private void OnEnable()
    {
        StartCoroutine(aa());
    }
    // Update is called once per frame
    IEnumerator aa()
    {
        Vector3 spawner = new Vector3(Random.Range(-26.5f, 34f), Random.Range( - 12.6f, 20f), Random.Range(-5.2f, 42f));
        GameObject _obj = null;
        _obj = Instantiate(n);
        _obj.transform.position = spawner;
        yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
        spawner = new Vector3(Random.Range(-26.5f, 34f), Random.Range(-12.6f, 20f), Random.Range(-5.2f, 42f));
        _obj = Instantiate(p);
        _obj.transform.position = spawner;
        yield return new WaitForSeconds(Random.Range(0.5f,2.5f));
        StartCoroutine(aa());
    }
}
