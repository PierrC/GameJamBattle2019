using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLife : MonoBehaviour
{
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // this.gameObject.transform.rotation = Quaternion.Euler(0, 0, this.gameObject.transform.rotation.eulerAngles.z + (rotateSpeed*Time.deltaTime));
        this.gameObject.transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
    }
}
