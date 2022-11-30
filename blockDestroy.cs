using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockDestroy : MonoBehaviour
{
    public GameObject exp;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Untagged")
        {
            Destroy(col.gameObject);
         //   Destroy(gameObject);
            Instantiate(exp, col.transform.position, col.transform.rotation);
        }   
    }
}
