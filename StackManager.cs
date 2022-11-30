using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;
    [SerializeField] private float distanceBObj;
    [SerializeField] private Transform parent, prevObject;
     void Awake()//there i use singleton
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        distanceBObj = prevObject.localScale.y;
    }

    public void PickUp(GameObject pickedObject,bool needTag=false,string tag=null,bool downOrUp = true)
    {
        if (needTag)
        {
            pickedObject.tag = tag;
        }
        pickedObject.transform.parent = parent;
        Vector3 desPos = prevObject.localPosition;
        desPos.y += downOrUp ? distanceBObj : -distanceBObj;

        pickedObject.transform.localPosition = desPos;
        prevObject = pickedObject.transform;
    }
    public void Stairs(GameObject pickedObject,bool needTag=false,string tag=null,bool downOrUp = true)
    {
        if (needTag)
        {
            pickedObject.tag = tag;

        }
        pickedObject.transform.parent = parent;
        Vector3 desPosition = prevObject.localPosition;
        desPosition.y += downOrUp ? distanceBObj : -distanceBObj;
        desPosition.z += pickedObject.transform.localScale.z;

        pickedObject.transform.localScale = desPosition;
        prevObject = pickedObject.transform;
    }
}
