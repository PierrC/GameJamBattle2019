using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject player;
    public TubeGroup tubeGroup;
    public GameObject powerUpPrefab;

    public float obstacleSpeed;

    public Timer Timer;
    // Start is called before the first frame update
    void Start()
    {
        downTimeTimer = 0f;
        start = true;
        RandomPowers = true;
        harderRand = true;
        StartCoroutine(PlayPattern(PatternHolder.startPattern));
    }

    bool start;
    // Update is called once per frame
    void Update()
    {
        if (RandomPowers)
        {
            AutomaticInstantiation();
        }
        ManualInstantiation();

    }

    int waitingTime;

    private void FixedUpdate()
    {
        obstacleSpeed += 0.1f * Time.fixedDeltaTime;
    }

    float RandomPowerTimer = 1;
    bool harderRand;
    void AutomaticInstantiation()
    {
        RandomPowerTimer -= Time.fixedDeltaTime;

        if (!harderRand)
        {
            if (RandomPowerTimer < 0 && RandomPowers)
            {
                GenerateObstacle(Random.Range(0, 6));
                RandomPowerTimer = 1.0f;
            }
        }
        else
        {
            if (RandomPowerTimer < 0 && RandomPowers)
            {
                int i1 = Random.Range(0, 6);
                int i2 = Random.Range(0, 6);
                while (i2 == i1)
                    i2 = Random.Range(0, 6);

                GenerateObstacle(i1);
                GenerateObstacle(i2);
                RandomPowerTimer = 1.0f;
            }
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
            StartCoroutine(PlayPattern(PatternHolder.P_easy1));
        }
    }

    int CalculatePowerValue()
    {
        int r = Random.Range(1, 101);
        List<bool> bools = player.GetComponent<PlayerManager>().instrumentsMax;
        List<int> lives = player.GetComponent<PlayerManager>().instruments;

        int[] spawns = new int[5] { 0, 0, 0, 0, 0 };
        for (int i = 1; i <= lives.Count; i++)
        {
            if (bools[i - 1])
                spawns[0] += 15;
            else
                spawns[i] += 15;

            spawns[0] += lives[i - 1] * 10/ player.GetComponent<PlayerManager>().maxLife ;
            spawns[i] +=( (player.GetComponent<PlayerManager>().maxLife - lives[i - 1]) * 10 / player.GetComponent<PlayerManager>().maxLife);
        }

        int total = 0;
        for (int i = 0; i < spawns.Length; i++)
        {
            total += spawns[i];
            if (r < total)
            {
                Debug.Log("Spawns[0]:" + spawns[0] + " Spawns[1]:" + spawns[1] + " Spawns[2]:" + spawns[2] + " Spawns[3]:" + spawns[3] + " Spawns[4]:" + spawns[4]);
                return i - 1;
            }
        }
        Debug.Log("Spawns[0]:" + spawns[0] + " Spawns[1]:" + spawns[1] + " Spawns[2]:" + spawns[2] + " Spawns[3]:" + spawns[3] + " Spawns[4]:" + spawns[4]);
        return -1;
    }

    void GenerateObstacles_SphericalSymmetric(int i)
    {
        if (i == -1)
            i = Random.Range(0, 3);
        if (i == -2)
            i = Random.Range(4, 6);
        if (i == -3)
            i = Random.Range(0, 6);
        GenerateObstacle(5 - i);
    }
    void GenerateObstacles_BilateralSymmetric(int i)
    {
        if (i == -1)
            i = Random.Range(0, 3);
        if (i == -2)
            i = Random.Range(4, 6);
        if (i == -3)
            i = Random.Range(0, 6);
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
    void GenerateObstacle(int i)
    {
        if (i == -1)
            i = Random.Range(0, 3);
        if (i == -2)
            i = Random.Range(4, 6);
        if (i == -3)
            i = Random.Range(0, 6);

        Vector3 pos = tubeGroup.GetTube(i).transform.position;
        pos.z = GetSpawnDistance();
        GameObject g = Instantiate(powerUpPrefab, pos, new Quaternion());
        g.GetComponent<PowerScript>().speed = obstacleSpeed;
        g.GetComponent<PowerScript>().instrumentNum = CalculatePowerValue();
    }

    bool RandomPowers;
    float patternTimer;
    float downTimeTimer;
    IEnumerator StartPattern(PatternData pattern)
    {
        yield return new WaitForSecondsRealtime(1);
        foreach (float f in pattern.patterns.Keys)
        {
            while (patternTimer < f * 2)
            {
                patternTimer += Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }

            foreach (int i in pattern.patterns[f]) { GenerateObstacle(i); }

        }


        StartCoroutine(WaitPattern());
    }


    IEnumerator PlayPattern(PatternData pattern)
    {
        patternTimer = 0f;
        RandomPowers = pattern.allowRandomPower;
        foreach (float f in pattern.patterns.Keys)
        {
            while (patternTimer < f * 2)
            {
                patternTimer += Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
            if (pattern.allowMirrorimages)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        foreach (int i in pattern.patterns[f]) { GenerateObstacle(i); }
                        break;
                    case 1:
                        foreach (int i in pattern.patterns[f]) { GenerateObstacles_SphericalSymmetric(i); }
                        break;
                    case 2:
                        foreach (int i in pattern.patterns[f]) { GenerateObstacles_BilateralSymmetric(i); }
                        break;
                }
            }
            else
            {
                foreach (int i in pattern.patterns[f]) { GenerateObstacle(i); }
            }
        }
        RandomPowers = true;
        StartCoroutine(WaitPattern());
    }

    IEnumerator WaitPattern()
    {

        yield return new WaitForSeconds(Random.Range(5, 11));
        if(Timer.actualTime < 2 * Timer.totalTime / 5)
        {
            StartCoroutine(PlayPattern(
               PatternHolder.easyPatterns[Random.Range(0, PatternHolder.mediumPatterns.Length)])
                );

        }
        else if(Timer.actualTime < 4 * Timer.totalTime / 5)
        {
            StartCoroutine(PlayPattern(
                PatternHolder.mediumPatterns[Random.Range(0, PatternHolder.mediumPatterns.Length)]));
        }
        else
        {
            StartCoroutine(PlayPattern(
                PatternHolder.hardPatterns[Random.Range(0, PatternHolder.hardPatterns.Length)]));
        }

        
    }

}
