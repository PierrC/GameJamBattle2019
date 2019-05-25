using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Tube actualTube;

    private Vector2 position2D;
    private bool moving;
    private bool resetAxis;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.position2D = this.transform.position;
        this.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, this.GetComponent<Rigidbody>().velocity.y, speed);
        if (!moving && Input.GetAxisRaw("Horizontal") != 0 && !resetAxis)
        {
            MoveHorizontal(Input.GetAxisRaw("Horizontal"));
            StartCoroutine(WaitForReset());
        }
        if (!moving && Input.GetButtonDown("Jump"))
        {
            MoveVertical();
        }
        if (!moving && Input.GetAxis("Vertical") != 0)
        {
            MoveVertical(Input.GetAxis("Vertical"));
        }
    }

    private IEnumerator WaitForReset()
    {
        resetAxis = true;
        while (Mathf.Abs(Input.GetAxisRaw("Horizontal")) >= 0.3f)
            yield return null;
        resetAxis = false;
    }

    private void MoveHorizontal(float direction)
    {
        if(direction < 0)
        {
            if(actualTube.left != null)
            {
                moving = true;
                StartCoroutine(MovingTo2(actualTube.left));
            }
        }
        if (direction > 0)
        {
            if (actualTube.right != null)
            {
                moving = true;
                StartCoroutine(MovingTo2(actualTube.right));
            }
        }
    }

    private void MoveVertical()
    {
       moving = true;
       StartCoroutine(MovingTo3(actualTube.opposite));

    }

    private void MoveVertical(float direction)
    {

        if (direction < 0)
        {
            if (FindObjectOfType<TubeGroup>().TopTubes.Contains(actualTube))
            {
                moving = true;
                StartCoroutine(MovingTo3(actualTube.opposite));
            }
        }
        if (direction > 0)
        {
            if (FindObjectOfType<TubeGroup>().BotTubes.Contains(actualTube))
            {
                moving = true;
                StartCoroutine(MovingTo3(actualTube.opposite));
            }
        }


    }



    public float playerSpeed = 5f;

    private IEnumerator MovingTo(Tube tube)
    {
        while (Vector2.Distance(this.position2D,tube.transform.position) > 0.2f)
        {
            this.GetComponent<Rigidbody>().AddForce(playerSpeed * (tube.transform.position - this.transform.position));
            yield return null;
        }
        this.actualTube = tube;
        this.transform.position = new Vector3(actualTube.transform.position.x, actualTube.transform.position.y, this.transform.position.z);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, this.GetComponent<Rigidbody>().velocity.z);
        moving = false;
    }

    private IEnumerator MovingTo2(Tube tube)
    {
        while (Vector2.Distance(this.position2D, tube.transform.position) > 0.2f)
        {
            Vector3 vector3 = (tube.transform.position - transform.position);
            vector3.z = 0;
            transform.position += vector3.normalized * playerSpeed * Time.fixedDeltaTime;
            yield return null;
        }
        this.actualTube = tube;
        this.transform.position = new Vector3(actualTube.transform.position.x, actualTube.transform.position.y, this.transform.position.z);
        yield return new WaitForSeconds(0.02f);
        moving = false;
    }

    private IEnumerator MovingTo3(Tube tube)
    {
        // play depart sound
        while (Vector2.Distance(this.position2D, tube.transform.position) > 0.2f)
        {
            Vector3 vector3 = (tube.transform.position - transform.position);
            vector3.z = 0;
            transform.position += vector3.normalized * playerSpeed * 2 * Time.fixedDeltaTime;
            yield return null;
        }
        this.actualTube = tube;
        // play arrival sound
        this.transform.position = new Vector3(actualTube.transform.position.x, actualTube.transform.position.y, this.transform.position.z);
       //yield return new WaitForSeconds(0.1f);
        moving = false;
    }

}
