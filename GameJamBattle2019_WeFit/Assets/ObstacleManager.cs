using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public TubeGroup tubeGroup;
    public GameObject powerUpPrefab;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GenerateObstacle(false, 1);
        }
    }

    void GenerateObstacle(bool top, int i)
    {
        GameObject g = Instantiate(powerUpPrefab, tubeGroup.GetTube(top, i).transform.position, new Quaternion());
        g.GetComponent<PowerScript>().speed = 10;
    }

}
