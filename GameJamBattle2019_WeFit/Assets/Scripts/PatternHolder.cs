using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PatternHolder
{

    public static SortedList<float, int[]> example = new SortedList<float, int[]>()
    {
        {0.5f, new int [2] {3,4}},
        {1f, new int [0] {}},
        {1.5f, new int [3] {1,2,3}},
        {2f, new int [0] {}},
        {2.5f, new int [3] {1,4,5}},
    };



}
