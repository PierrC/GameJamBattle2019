
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatternData
{

    public SortedList<float, int[]> patterns;
    public bool allowMirrorimages;
    public bool allowRandomPower;
    
    public PatternData(SortedList<float, int[]> pairs)
    {
        patterns = pairs;
        allowRandomPower = false;
        allowMirrorimages = false;
    }

    public PatternData(SortedList<float, int[]> pairs, bool allowMirror, bool allowRandom)
    {
        patterns = pairs;
        allowMirrorimages = allowMirror;
        allowRandomPower = allowRandom;
    }

}


