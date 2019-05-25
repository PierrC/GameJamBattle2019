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
        if (!moving && Input.GetButtonDown("Jump"))
        {
            MoveVertical();
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

    private void MoveVertical()
    {
       moving = true;
       StartCoroutine(MovingTo(actualTube.opposite));

    }

    public float playerSpeed = 5f;

    private IEnumerator MovingTo(Tube tube)
    {
        while (Vector2.Distance(this.position2D,tube.position2D) > 0.1f)
        {
            this.GetComponent<Rigidbody>().AddForce(playerSpeed * (tube.position2D - this.position2D));
            yield return null;
        }
        this.actualTube = tube;
        this.transform.position = new Vector3(actualTube.position2D.x, actualTube.position2D.y, this.transform.position.z);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, this.GetComponent<Rigidbody>().velocity.z);
        moving = false;
    }
}
