using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStoring : MonoBehaviour
{
    public int score;
    private PlayerManager player;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        player = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            score = player.score;
    }
}
