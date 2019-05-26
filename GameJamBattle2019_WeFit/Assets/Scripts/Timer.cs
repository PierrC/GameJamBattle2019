using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime;
    public Image image;
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
            StartCoroutine(WaitAndFade());
        }
    }

    IEnumerator WaitAndFade()
    {
        float timer = 0f;
        Color c = new Color(0, 0, 0, 0);
        while(timer < 1)
        {
            timer += Time.deltaTime;
            c.a = timer;
            image.color = c;
            yield return null;
        }
        SceneManager.LoadScene("VictoryScreen");
    }
}
