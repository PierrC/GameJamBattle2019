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
        b = false;
    }

    // Update is called once per frame
    void Update()
    {
        ManualInstantiation();
        
    }

    private void FixedUpdate()
    {
        speed += 0.1f * Time.fixedDeltaTime;
        AutomaticInstantiation();
    }

    float timer = 1;
    bool b;
    void AutomaticInstantiation()
    {
        timer -= Time.fixedDeltaTime;
        if(timer < 0)
        {
            GenerateObstacle(b, Random.Range(0, 3));
            b = !b;
            timer = 1.0f;
        }
    }
    
    void ManualInstantiation()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GenerateObstacle(true, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GenerateObstacle(true, 1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GenerateObstacle(true, 2);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GenerateObstacle(false, 0);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            GenerateObstacle(false, 1);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            GenerateObstacle(false, 2);
        }
    }

    void GenerateObstacle(bool top, int i)
    {
        GameObject g = Instantiate(powerUpPrefab, tubeGroup.GetTube(top, i).transform.position, new Quaternion());
        g.GetComponent<PowerScript>().speed = speed;
    }
}
