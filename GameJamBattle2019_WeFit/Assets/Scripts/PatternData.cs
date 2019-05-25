using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPattern", menuName = "Scriptable Object")]
public class PatternData : ScriptableObject
{
    [SerializeField]
    HashSet<float, List<int>>();
}
