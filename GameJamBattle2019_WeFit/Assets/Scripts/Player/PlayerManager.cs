using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator animCamera;
    public Animator animPlayer;

    public List<int> instruments;
    public List<GameObject> spheres;
    public int maxLife;
    public float maxSizeSphere;
    int damages;

    public int score;

    private bool invincible;
    public List<bool> instrumentsMax;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        StartCoroutine(CalculateScore());
        damages = (int)(maxLife / 2f);
        instrumentsMax = new List<bool>();
        for(int i = 0; i < instruments.Count; i++)
        {
            instrumentsMax.Add(false);
        }
        SwitchState();
    }
    
    // Update is called once per frame
    void Update()
    {
        UpdateLife();
        /*if (Input.GetButton("Jump"))
            Delete(0);*/
    }

    int CalculateSCore()
    {
        int t = 0;
        foreach (int i in instruments)
        {
            t += i;
        }
        return t;
    }

    void UpdateLife()
    {
        for (int i = 0; i < instruments.Count; i++)
        {
            float size = maxSizeSphere * ((float)instruments[i] / maxLife);
            spheres[i].transform.localScale = new Vector3(size,size, size);
        }
    }

    public void Collect(int n_instrument)
    {
        AkSoundEngine.PostEvent("HitBallGood", this.gameObject);
        animPlayer.Play("hit", -1, 0f);
        if (instruments[n_instrument] < maxLife)
            instruments[n_instrument]++;
        if (instruments[n_instrument] == maxLife && !instrumentsMax[n_instrument])
        {
            instrumentsMax[n_instrument] = true;
            SwitchState();
        }
    }

    public void SwitchState()
    {
        if (instrumentsMax[0])
        {
            if(instrumentsMax[1])
            {
                if (instrumentsMax[2])
                {
                    if (instrumentsMax[3])
                    {
                        AkSoundEngine.SetState("Layers", "L1andL2andL3andL4");
                    }
                    else
                    {
                        AkSoundEngine.SetState("Layers", "L1andL2andL3");
                    }
                }
                else
                {
                    if (instrumentsMax[3])
                    {
                        AkSoundEngine.SetState("Layers", "L1andL2andL4");
                    }
                    else
                    {
                        AkSoundEngine.SetState("Layers", "L1andL2");
                    }
                }
            }
            else
            {
                if (instrumentsMax[2])
                {
                    if (instrumentsMax[3])
                    {
                        AkSoundEngine.SetState("Layers", "L1andL3andL4");
                    }
                    else
                    {
                        AkSoundEngine.SetState("Layers", "L1andL3");
                    }
                }
                else
                {
                    if (instrumentsMax[3])
                    {
                        AkSoundEngine.SetState("Layers", "L1andL4");
                    }
                    else
                    {
                        AkSoundEngine.SetState("Layers", "L1");
                    }
                }
            }
        }
        else
        {
            if (instrumentsMax[1])
            {
                if (instrumentsMax[2])
                {
                    if (instrumentsMax[3])
                    {
                        AkSoundEngine.SetState("Layers", "L2andL3andL4");
                    }
                    else
                    {
                        AkSoundEngine.SetState("Layers", "L2andL3");
                    }
                }
                else
                {
                    if (instrumentsMax[3])
                    {
                        AkSoundEngine.SetState("Layers", "L2andL4");
                    }
                    else
                    {
                        AkSoundEngine.SetState("Layers", "L2");
                    }
                }
            }
            else
            {
                if (instrumentsMax[2])
                {
                    if (instrumentsMax[3])
                    {
                        AkSoundEngine.SetState("Layers", "L3andL4");
                    }
                    else
                    {
                        AkSoundEngine.SetState("Layers", "L3");
                    }
                }
                else
                {
                    if (instrumentsMax[3])
                    {
                        AkSoundEngine.SetState("Layers", "L4");
                    }
                    else
                    {
                        AkSoundEngine.SetState("Layers", "Drum_00");
                    }
                }
            }
        }
    }

    public void Delete()
    {
        if (!invincible)
        {
            AkSoundEngine.PostEvent("HitBallBad", this.gameObject);
            if (CheckLife())
            {
                int i = Random.Range(0, 4);
                int counter = 0;
                while (instruments[i] == 0)
                {
                    counter++;
                    i = Random.Range(0, 4);
                    if (counter >= 5)
                        break;
                }
                if (counter < 5)
                {
                    instruments[i] -= damages;

                }
                if (instruments[i] <= 0)
                {
                    instruments[i] = 0;
                    instrumentsMax[i] = false;
                    SwitchState();
                }
                // felix
                animCamera.Play("ScreenShake", -1, 0f);
                StartCoroutine(InvincibleState());
            }
        }
    }

    private bool CheckLife()
    {
        foreach (int i in instruments)
        {
            if (i != 0)
                return true;
        }
        return false;
    }

    private int FindTarget()
    {
        int minhealth = 15;
        int target = 0;
        for (int i = 0; i < instruments.Count; i++)
        {
            if (instrumentsMax[i] && instruments[i] < minhealth)
            {
                minhealth = instruments[i];
                target = i;
            }
        }
        return target;
    }

    IEnumerator CalculateScore()
    {

        yield return new WaitForSeconds(1);
        int t = 0;
        foreach (int i in instruments)
        {
            t += i;
        }
        foreach (bool b in instrumentsMax)
        {
            if (b)
                t += 10;
        }
        score += t;

        StartCoroutine(CalculateScore());
    }

    private IEnumerator InvincibleState()
    {
        invincible = true;
        float timer = 0;
        while(timer < 1f)
        {
            timer += Time.deltaTime;
            if(Mathf.PingPong(Time.time * 10, 2)>1)
            {
                foreach (MeshRenderer mesh in this.GetComponentsInChildren<MeshRenderer>())
                    mesh.enabled = false;
                //felix
                RenderSettings.fogDensity = 0.031f;
            }
            else
            {
                foreach (MeshRenderer mesh in this.GetComponentsInChildren<MeshRenderer>())
                    mesh.enabled = true;
                //felix
                RenderSettings.fogDensity = 0.03f;
            }
            yield return null;

        }
        foreach (MeshRenderer mesh in this.GetComponentsInChildren<MeshRenderer>())
            mesh.enabled = true;
        invincible = false;
        //felix
        RenderSettings.fogDensity = 0.03f;
    }
}
