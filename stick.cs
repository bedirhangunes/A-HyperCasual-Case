using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class stick : MonoBehaviour
{
    public string stuckObjTag = "Finish";
    private movement mov;
    Rigidbody rb;
     void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(stuckObjTag))
        {
         // GetComponent<Rigidbody>().isKinematic = true;

           
        }
        if (col.gameObject.CompareTag("Finish"))
        {

              rb.velocity = Vector3.zero;
            rb.GetComponent<Rigidbody>().isKinematic = false;
         
            
        }
    }
}
