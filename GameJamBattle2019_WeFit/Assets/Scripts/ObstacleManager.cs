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
        RandomPowers = true;
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
        if(timer < 0 && RandomPowers)
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
            PatternData p = new PatternData(PatternHolder.example);
            StartCoroutine(PlayPattern(p));
        }
    }

    void GenerateObstacle(bool top, int i)
    {
        GameObject g = Instantiate(powerUpPrefab, tubeGroup.GetTube(top, i).transform.position, new Quaternion());
        g.GetComponent<PowerScript>().speed = speed;
    }
    void GenerateObstacle( int i)
    {
        GameObject g = Instantiate(powerUpPrefab, tubeGroup.GetTube( i).transform.position, new Quaternion());
        g.GetComponent<PowerScript>().speed = speed;
    }

    bool RandomPowers;
    float patternTimer;
    IEnumerator PlayPattern(PatternData pattern)
    {
        patternTimer = 0f;
        RandomPowers = false;
        foreach (float f in pattern.patterns.Keys)
        {
         while(patternTimer < f)
            {
                patternTimer += Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }   
         foreach(int i in pattern.patterns[f])
            {
                GenerateObstacle(i);
            }
        }
     //   RandomPowers = true;
    }
}
