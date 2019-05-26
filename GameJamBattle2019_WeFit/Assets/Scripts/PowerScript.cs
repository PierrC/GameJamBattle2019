using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public float speed;
    [RangeAttribute(-1,4)]
    public int instrumentNum;

    // Start is called before the first frame update
    void Start()
    {
        speedVector = new Vector3(0, 0, speed);
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
    }
}
