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
    }

    int CalculatePowerValue()
    {
        int r = Random.Range(1, 101);
        List<bool> bools = player.GetComponent<PlayerManager>().instrumentsMax;
        List<int> lives = player.GetComponent<PlayerManager>().instruments;

        int[] spawns = new int[5] { 0, 0, 0, 0, 0 };
        for(int i = 1; i <= lives.Count; i++)
        {
            if (bools[i-1])
                spawns[0] += 15;
            else
                spawns[i] += 15;

            spawns[0] += lives[i-1];
            spawns[i] += (10 - lives[i-1]);
        }

        int total = 0;
        for(int i = 0; i < spawns.Length; i++)
        {
            total += spawns[i];
            if(r < total)
            {
                if(i == 0)
                    Debug.Log("spawns[0]:" + spawns[0] + " spawns[1]:" + spawns[1] + " spawns[2]:" + spawns[2]
                        + " spawns[3]:" + spawns[3] + " spawns[4]:" + spawns[4]);
                return i - 1;
            }
        }
        Debug.Log("spawns[0]:" + spawns[0] + " spawns[1]:" + spawns[1] + " spawns[2]:" + spawns[2]
            + " spawns[3]:" + spawns[3] + " spawns[4]:" + spawns[4]);

        return -1;
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
        g.GetComponent<PowerScript>().instrumentNum = CalculatePowerValue();
    }

    bool RandomPowers;
    float patternTimer;
    IEnumerator PlayPattern(PatternData pattern)
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
            switch (Random.Range(0, 3))
            {
                case 0:
                    foreach (int i in pattern.patterns[f])
                    {
                        GenerateObstacle(i);
                    }
                    break;
                case 1:
                    foreach (int i in pattern.patterns[f])
                    {
                        GenerateObstacles_SphericalSymmetric(i);
                    }
                    break;
                case 2:
                    foreach (int i in pattern.patterns[f])
                    {
                        GenerateObstacles_BilateralSymmetric(i);
                    }
                    break;
            }
        }
          RandomPowers = true;
    }
}
