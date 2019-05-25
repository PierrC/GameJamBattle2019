using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConnectCamera : MonoBehaviour
{
    public GameObject attachObject;

    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = this.transform.position - attachObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = attachObject.transform.position + distance;
    }
}
