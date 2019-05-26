using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject player;
    public TubeGroup tubeGroup;
    public GameObject powerUpPrefab;

    public float obstacleSpeed;

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
        obstacleSpeed += 0.1f * Time.fixedDeltaTime;
        AutomaticInstantiation();
    }

    float timer = 1;
    bool b;
    void AutomaticInstantiation()
    {
        timer -= Time.fixedDeltaTime;
        if (timer < 0 && RandomPowers)
        {
            GenerateObstacle(Random.Range(0, 6));
            timer = 1.0f;
        }
    }

    float GetSpawnDistance()
    {
        int i = (int)(48 / obstacleSpeed);
        return obstacleSpeed * 3 + player.transform.position.z;
    }

    void ManualInstantiation()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PatternData p = new PatternData(PatternHolder.example);
            StartCoroutine(PlayPattern(p));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PatternData p = new PatternData(PatternHolder.example);
            StartCoroutine(PlayPatternInverse(p));
        }
    }

    void GenerateObstacles_SphericalSymmetric(int i)
    {
        GenerateObstacle(5 - i);
    }
    void GenerateObstacles_BilateralSymmetric(int i)
    {
        switch (i)
        {
            case 0:
                GenerateObstacle(2);
                break;
            case 2:
                GenerateObstacle(1);
                break;
            case 3:
                GenerateObstacle(5);
                break;
            case 5:
                GenerateObstacle(3);
                break;
            default:
                GenerateObstacle(i);
                break;
        }
    }

    void GenerateObstacle( int i)
    {
        Vector3 pos = tubeGroup.GetTube(i).transform.position;
        pos.z = GetSpawnDistance();
        GameObject g = Instantiate(powerUpPrefab, pos, new Quaternion());
        g.GetComponent<PowerScript>().speed = obstacleSpeed;
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
    IEnumerator PlayPatternInverse(PatternData pattern)
    {
        patternTimer = 0f;
        RandomPowers = false;
        foreach (float f in pattern.patterns.Keys)
        {
            while (patternTimer < f)
            {
                patternTimer += Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
            foreach (int i in pattern.patterns[f])
            {
                GenerateObstacles_SphericalSymmetric(i);
            }
        }
        //   RandomPowers = true;
    }
}
