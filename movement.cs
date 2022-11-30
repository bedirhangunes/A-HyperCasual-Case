using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class movement : MonoBehaviour
{
    public float swipeSpeed;
    public float moveSpeed;
    private Camera cam;
    public Text scText;
    NavMeshAgent agent;
    int score = 0;
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        scText.text = "Score: " + score;
    }

    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            Move();
        }
        if (score > 0 && score < 5)
        {
            agent.SetDestination(new Vector3(0f, 0f, 400f));
        }
    }
    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;
        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            GameObject firstCube = atmRush.instance.cubes[0];//ilk eleman
            Vector3 hitVector = hit.point;
            hitVector.y = firstCube.transform.localPosition.y;
            hitVector.z = firstCube.transform.localPosition.z;
            firstCube.transform.localPosition = Vector3.MoveTowards(firstCube.transform.localPosition, hitVector, Time.deltaTime*swipeSpeed);
          
        }
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            
        }
    }

}
