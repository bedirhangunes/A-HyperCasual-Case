using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public Text scoreText;
    int score = 0;

    void Start()
    {
        scoreText.text = "Score: " + score;
    }

     void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Untagged")
        {
            score++;
            scoreText.text = "Score: "+score;
            Destroy(gameObject, 1);
        }      
    }
}
