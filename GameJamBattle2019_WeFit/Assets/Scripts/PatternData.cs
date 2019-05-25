using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewPattern", menuName = "Scriptable Object/Pattern")]
public class PatternData : ScriptableObject
{
    [SerializeField]
    public Dictionary<float, List<int>> pattern;
}
