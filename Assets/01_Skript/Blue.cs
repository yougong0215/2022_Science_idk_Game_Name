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

    bool np = false;
    bool pn = false;
    Ray ray;
    RaycastHit hit;

    private void OnEnable()
    {
        _mt = GetComponent<MeshRenderer>().materials;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (np == true)
            {
                Blues.color = Color.red;
                Reds.color = Color.blue;
                np = false;
            }
            else
            {
                Blues.color = Color.blue;
                Reds.color = Color.red;
                np = true;
            }
            pn = false;

        }
        if (F != null)
        {

            if (np == true)
            {
                if (F.CompareTag("n") == true)
                {
                    DrawLine(mt2, transform.position, F.transform.position, 0.2f);
                    pn = true;
                }
                else
                {
                    asdfasasf.Instance.Damaged();
                    DrawLine(mt1, transform.position, F.transform.position, 0.2f);
                }
                if (pn == true)
                {
                    StartCoroutine(Moveing(F, "np"));
                    pn = false;
                }
            }
            else if (np == false)
            {
                if (F.CompareTag("p") == true)
                {
                    DrawLine(mt1, transform.position, F.transform.position, 0.2f);
                    pn = true;
                }
                else
                {
                    asdfasasf.Instance.Damaged();
                    DrawLine(mt2, transform.position, F.transform.position, 0.2f);
                }
                if (pn == true)
                {
                    StartCoroutine(Moveing(F, "pn"));
                    pn = false;
                }
            }
            if (np == true)
            {
                Blues.color = Color.red;
                Reds.color = Color.blue;
                np = false;
            }
            else
            {
                Blues.color = Color.blue;
                Reds.color = Color.red;
                np = true;
            }
            F = null;
        }


        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("n") || hit.collider.gameObject.CompareTag("p"))
                {
                    F = hit.collider.gameObject.transform;
                }
                else
                {
                    pn = false;
                }
            }
            else
            {
                asdfasasf.Instance.Damaged();
            }
        }

    }

    IEnumerator Moveing(Transform First, string np)
    {
        Transform Second = null;
        while (true)
        {
            Second = GameObject.FindGameObjectWithTag(np).transform;
            try
            {
                _mt[2].SetColor("_EmissionColor", Color.white * (SCores.Instance.returnScore()) / 200f);
                DrawLine(mt3, First.transform.position, Second.transform.position, 0.03f);
                Vector3 dir2 = Second.transform.position - First.transform.position;
                dir2.Normalize();

                First.transform.position += dir2 * speed * Time.deltaTime;
            }
            catch
            {
                break;
            }

            // 충돌하면 break;


            yield return new WaitForSeconds(0.02f);
        }
    }

    void DrawLine(Material mtt, Vector3 start, Vector3 end, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = mtt;
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }

}
