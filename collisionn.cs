using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collisionn : MonoBehaviour
{
    Rigidbody rb;
    float speed = 1;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            if (!atmRush.instance.cubes.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<collisionn>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                
                atmRush.instance.StackCube(other.gameObject, atmRush.instance.cubes.Count - 1);
            }
        }
        if (other.tag != "Block")
        {

        }
      

    }
   
}
