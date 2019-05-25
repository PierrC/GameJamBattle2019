using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeGroup : MonoBehaviour
{

    public Tube[] TopTubes = new Tube[3];
    public Tube[] BotTubes = new Tube[3];

    
    public Tube GetTube(int i)
    {
        switch (i)
        {
            case 0:
                return TopTubes[0];
            case 1:
                return TopTubes[1];
            case 2:
                return TopTubes[2];
            case 3:
                return BotTubes[0];
            case 4:
                return BotTubes[1];
            case 5:
                return BotTubes[2];
            default:
                return BotTubes[1];
        }
    }

    public Tube GetTube(bool top, int i)
    {
        if (i > 2 || i < 0)
            i = 1;
        if (top)
            return TopTubes[i];
        else
            return BotTubes[i];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
