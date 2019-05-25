using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public Tube left;
    public Tube right;
    public Tube opposite;

    public Vector2 position2D;

    // Start is called before the first frame update
    void Start()
    {
        this.position2D = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
