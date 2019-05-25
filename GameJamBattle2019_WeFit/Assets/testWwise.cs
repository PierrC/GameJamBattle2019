using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWwise : MonoBehaviour
{
    uint eventWwise;

    // Start is called before the first frame update
    void Start()
    {
        eventWwise = AkSoundEngine.PostEvent("Test", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            AkSoundEngine.StopPlayingID(eventWwise);
             
    }
}
