using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class n : MonoBehaviour
{
    [SerializeField] GameObject P;    
    
    private void OnCollisionEnter(Collision collision)
    {
        P.transform.position = transform.position;
        if (collision.gameObject.CompareTag("p"))
        {
            SCores.Instance.GetScore();
            Instantiate(P);
            P.transform.position = transform.position;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
