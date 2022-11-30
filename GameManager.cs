using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject wing;
    public Vector3 random;

    void Start()
    {
        StartCoroutine(createwing());
    }

  IEnumerator createwing()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            for(int i = 0; i < 20; i++)
            {
                Vector3 win = new Vector3(Random.Range(-random.x, random.x), random.y, Random.Range(-random.z, random.z));
                Instantiate(wing, win, Quaternion.identity);
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(2);
        }
    }
}
