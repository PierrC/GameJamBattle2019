﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Tube actualTube;

    private Vector2 position2D;
    private bool moving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.position2D = this.transform.position;
        this.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, this.GetComponent<Rigidbody>().velocity.y, speed);
        if (!moving && Input.GetAxis("Horizontal") != 0)
        {
            MoveHorizontal(Input.GetAxis("Horizontal"));
        }
    }

    private void MoveHorizontal(float direction)
    {
        if(direction < 0)
        {
            if(actualTube.left != null)
            {
                moving = true;
                StartCoroutine(MovingTo(actualTube.left));
            }
        }
        if (direction > 0)
        {
            if (actualTube.right != null)
            {
                moving = true;
                StartCoroutine(MovingTo(actualTube.right));
            }
        }
    }

    private IEnumerator MovingTo(Tube tube)
    {
        while (Vector2.Distance(this.position2D,tube.position2D) > 1)
        {
            this.GetComponent<Rigidbody>().AddForce(tube.position2D - this.position2D);
            yield return null;
        }
        moving = false;
    }
}
