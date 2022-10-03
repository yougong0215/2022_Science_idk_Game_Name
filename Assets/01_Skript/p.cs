using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p : MonoBehaviour
{
    [SerializeField] GameObject P;
    private void OnCollisionEnter(Collision collision)
    {
        P.transform.position = transform.position;
        if (collision.gameObject.CompareTag("n"))
        {
            SCores.Instance.GetScore();
            Instantiate(P);
            P.GetComponent<ParticleSystem>().startColor = new Color(255, 231, 23);
            P.transform.position = transform.position;
            Destroy(collision.gameObject);
        }
    }
}
