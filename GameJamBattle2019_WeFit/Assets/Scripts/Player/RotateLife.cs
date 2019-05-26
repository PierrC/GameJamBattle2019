using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLife : MonoBehaviour
{
    public float rotateSpeed;

    public GameObject[] spheres;

    private PlayerManager manager;
    private float maxLife;
    private float maxSizeSphere;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponentInParent<PlayerManager>();
        maxLife = manager.maxLife;
        maxSizeSphere = manager.maxSizeSphere;
    }

    // Update is called once per frame
    void Update()
    {
        // this.gameObject.transform.rotation = Quaternion.Euler(0, 0, this.gameObject.transform.rotation.eulerAngles.z + (rotateSpeed*Time.deltaTime));
       // this.gameObject.transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));

        for(int i = 0; i < spheres.Length; i++)
        {
            spheres[i].transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime * maxSizeSphere * (manager.instruments[i] / maxLife)));
        }
    }
}
