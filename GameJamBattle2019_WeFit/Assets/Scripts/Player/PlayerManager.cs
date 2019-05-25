using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<int> instruments;
    public List<GameObject> spheres;
    public int maxLife;
    public float maxSizeSphere;

    private bool invincible;
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
        UpdateLife();
        /*if (Input.GetButton("Jump"))
            Delete(0);*/
    }

    void UpdateLife()
    {
        for (int i = 0; i < instruments.Count; i++)
        {
            spheres[i].transform.localScale = new Vector3(maxSizeSphere * ((float)instruments[i] / (float)maxLife), maxSizeSphere * ((float)instruments[i] / (float)maxLife), maxSizeSphere * ((float)instruments[i] / (float)maxLife));
        }
    }

    public void Collect(int n_instrument)
    {
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

    public void Delete(int n_instrument)
    {
        if(!invincible)
        {
            if (instruments[n_instrument] > 0 )
                instruments[n_instrument] -= 4;
            if (instruments[n_instrument] < 0)
                instruments[n_instrument] = 0;
            if(instruments[n_instrument] <= 0)
            {
                instrumentsMax[n_instrument] = false;
                SwitchState();
            }
            StartCoroutine(InvincibleState());
        }

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
            }
            else
            {
                foreach (MeshRenderer mesh in this.GetComponentsInChildren<MeshRenderer>())
                    mesh.enabled = true;
            }
            yield return null;

        }
        foreach (MeshRenderer mesh in this.GetComponentsInChildren<MeshRenderer>())
            mesh.enabled = true;
        invincible = false;
    }
}
