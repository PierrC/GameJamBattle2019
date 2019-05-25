
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewPattern", menuName = "Scriptable Object/Pattern")]
public class PatternData
{

    public Dictionary<float, int[]> patterns;
    
    public PatternData(Dictionary<float, int[]> pairs)
    {
        patterns = pairs;
    }
}


