﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public float speed;
    [RangeAttribute(-1,4)]
    public int instrumentNum;
    public GameObject[] materials;
    // Start is called before the first frame update
    void Start()
    {
        speedVector = new Vector3(0, 0, speed);
        for(int i = 0; i < materials.Length; i++)
        {
            if (i == instrumentNum+1)
                materials[i].SetActive(true);
            else
                materials[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    Vector3 speedVector;
    void Movement()
    {
        transform.position -= speedVector * Time.deltaTime;

        if (transform.position.z < -20)
            GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<PlayerManager>() != null)
        {
            if (this.instrumentNum < 0)
                other.gameObject.GetComponent<PlayerManager>().Delete();
            else
                other.gameObject.GetComponent<PlayerManager>().Collect(instrumentNum);

        }
        GameObject.Destroy(gameObject);
    }
}
