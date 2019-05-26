using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime;
    public Image image;
    public float actualTime;
    public PlayerManager player;

    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        actualTime = 0;
        player = FindObjectOfType<PlayerManager>();
    }



    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime;
        if(actualTime > (totalTime-1) && !done)
        {
            StartCoroutine(WaitAndFade());
            player.animPlayer.Play("endPlayer");
            done = true;
        }
    }

    IEnumerator WaitAndFade()
    {
        float timer = 0f;
        Color c = new Color(0, 0, 0, 0);
        while(timer < 2f)
        {
            timer += Time.deltaTime;
            c.a = timer/2;
            image.color = c;
            yield return null;
        }
        SceneManager.LoadScene("VictoryScreen");
    }
}
