using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternHolder
{
    Dictionary<float, int[]> example = new Dictionary<float, int[]>()
    {
        {0.5f, new int [3] {0,1,5}},
        {1f, new int [3] {0,2,4}},
        {1.5f, new int [3] {1,3,5}},
        {2f, new int [2] {3,4}},
        {2.5f, new int [3] {0,3,5}},
    };



}
