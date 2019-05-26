using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLerp : MonoBehaviour
{
    public GameObject objectToFollow;
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, objectToFollow.transform.position,speed);

    }
}
