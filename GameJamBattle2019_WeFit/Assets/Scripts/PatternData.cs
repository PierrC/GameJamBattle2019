
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewPattern", menuName = "Scriptable Object/Pattern")]
public class PatternData
{

    public SortedList<float, int[]> patterns;
    
    public PatternData(SortedList<float, int[]> pairs)
    {
        patterns = pairs;
    }
}


