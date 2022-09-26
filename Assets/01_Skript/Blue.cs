using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blue : MonoBehaviour
{
    [SerializeField] Material mt1;
    [SerializeField] Material mt2;
    [SerializeField] Material mt3;
    [SerializeField] Image Blues;
    [SerializeField] Image Reds;
    [SerializeField] float speed = 3;
    private Transform _player = null;
    Material[] _mt;

    Transform F, S;

    public Transform Player
    {
        get
        {
            if (_player == null)
            {
                _player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            return _player;
        }

    }

    bool number = false;
    int o = 0;
    int check = 0;

    bool nDiod = false;
    bool pDiod = false;

    Ray ray;
    RaycastHit hit1;
    RaycastHit hit2;

    private void OnEnable()
    {
        _mt = GetComponent<MeshRenderer>().materials;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (number == true)
            {
                number = false;
                Blues.color = Color.red;
                Reds.color = Color.blue;
            }
            else if (number == false)
            {
                Blues.color = Color.blue;
                Reds.color = Color.red;
                number = true;
            }
            if (Physics.Raycast(ray, out hit1) && number == false)
            {
                try
                {
                    F = hit1.collider.gameObject.transform;
                }
                catch
                {
                    Debug.Log("그딴거 없음");
                }

                if (F.gameObject.CompareTag("n") || F.gameObject.CompareTag("p"))
                {
                    
                    F = hit1.collider.gameObject.transform;
                    pDiod = true;
                }
                else
                {
                    pDiod = false;
                }

            }
            else if (Physics.Raycast(ray, out hit2) && number == true)
            {
                try
                {
                    S = hit2.collider.gameObject.transform;
                }
                catch
                {
                    Debug.Log("그딴거 없음");
                }
                if (S.gameObject.CompareTag("n") || S.gameObject.CompareTag("p"))
                {
                    
                    S = hit2.collider.gameObject.transform;
                    nDiod = true;
                }
                else
                {
                    nDiod = false;
                }


            }
        }
        if (nDiod && pDiod)
        {
            if (F.gameObject.CompareTag("n") && S.gameObject.CompareTag("p"))
            {
                StartCoroutine(Moveing(F, S));
                nDiod = false;
                pDiod = false;
            }
        }
        if (pDiod)
        {
            
            DrawLine(mt2, F.transform.position, transform.position + new Vector3(0.5f, -6, 0), Color.red, 0.03f);

        }
        if (nDiod)
        {
            DrawLine(mt1, S.transform.position, transform.position + new Vector3(-0.5f, -7, 0), Color.red, 0.03f);
        }
    }

    IEnumerator Moveing(Transform First, Transform Second)
    {
        while (true)
        {
            try
            {
                _mt[2].SetColor("_EmissionColor", Color.white * (SCores.Instance.returnScore())/200f);
                DrawLine(mt3, First.transform.position, Second.transform.position, Color.red, 0.03f);
                Vector3 dir1 = First.transform.position - Second.transform.position;
                dir1.Normalize();
                Vector3 dir2 = Second.transform.position - First.transform.position;
                dir2.Normalize();

                First.transform.position += dir2 * speed * Time.deltaTime;
                Second.transform.position += dir1 * speed * Time.deltaTime;
            }
            catch
            {
                break;
            }

            // 충돌하면 break;


            yield return new WaitForSeconds(0.02f);
        }
    }

    void DrawLine(Material mtt, Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = mtt;
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
  
}
