using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnvironnment : MonoBehaviour
{
    public GameObject distanceCalc;
    public float speed;

    float distance;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        distance = (distanceCalc.transform.position.z - transform.position.z);
        time = GetComponent<Timer>().totalTime;
        initialSpeed = speed;
    }

    float initialSpeed;
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, -speed * Time.deltaTime);
        speed += (2 * (distance - initialSpeed * time)) / Mathf.Pow(time, 2) * Time.deltaTime;

    }
}
