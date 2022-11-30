using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class bothScript : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 firstPos = new Vector3(0, 0, 0);
   public Vector3 random;
    public static bothScript instance;
    public float movementDelay=0.25f;
    public List<GameObject> cubes = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(new Vector3(Random.Range(-random.x, random.x), random.y, random.z));
        if (Input.GetButton("Fire1"))
        {
            MoveListElement();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrgin();
        }
    }
    public void StackCub(GameObject other,int index)
    {
        other.transform.parent = transform;
        Vector3 yeniPos = cubes[index].transform.localPosition;
        yeniPos.z += 1;
        other.transform.localPosition = yeniPos;
        cubes.Add(other);
        StartCoroutine(makeObjectBigger());
    }
    private IEnumerator makeObjectBigger()
    {
        for(int i = cubes.Count - 1; i > 0; i--)
        {
            Vector3 scale = new Vector3(1, 1, 1);
            cubes[i].transform.DOScale(scale,0.1f).OnComplete(()=>
                cubes[i].transform.DOScale(new Vector3(1,1,1),0.1f));
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void MoveListElement()
    {
        for(int a = 1; a < cubes.Count; a++)
        {
            Vector3 posi = cubes[a].transform.localPosition;
            posi.x = cubes[a - 1].transform.localPosition.x;
            cubes[a].transform.DOLocalMove(posi, movementDelay);
        }

    }
    private void MoveOrgin()
    {
        for(int z = 1; z < cubes.Count; z++)
        {
            Vector3 posi = cubes[z].transform.localPosition;
            posi.x = cubes[0].transform.localPosition.x;
            cubes[z].transform.DOLocalMove(posi, 0.70F);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            transform.position = firstPos;
        }
    }
}
