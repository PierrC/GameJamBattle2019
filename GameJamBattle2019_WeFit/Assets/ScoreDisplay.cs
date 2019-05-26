using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreStoring score = FindObjectOfType<ScoreStoring>();
        if (score !=null && !done)
        {
            this.GetComponent<Text>().text = "Your score : " + score.score;
        }
    }
}
