using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<int> instruments;
    public int maxLife;

    private List<bool> instrumentsMax;

    // Start is called before the first frame update
    void Start()
    {
        instrumentsMax = new List<bool>();
        for(int i = 0; i < instruments.Count; i++)
        {
            instrumentsMax.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < instruments.Count; i++)
        {
            if(instruments[i] == maxLife && !instrumentsMax[i])
            {
                
            }
        }
    }
}
