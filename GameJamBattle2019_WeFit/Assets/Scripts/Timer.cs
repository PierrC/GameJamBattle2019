using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float totalTime;
    private float actualTime;

    // Start is called before the first frame update
    void Start()
    {
        actualTime = 0;
    }



    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime;
        if(actualTime > totalTime)
        {
            SceneManager.LoadScene("VictoryScreen");
        }
    }
}
