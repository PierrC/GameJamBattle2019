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

    }

    void UpdateLife()
    {
        for (int i = 0; i < instruments.Count; i++)
        {
            spheres[i].transform.localScale = new Vector3(maxSizeSphere * ((float)instruments[i] / (float)maxLife), maxSizeSphere * ((float)instruments[i] / (float)maxLife), maxSizeSphere * ((float)instruments[i] / (float)maxLife));
            if (instruments[i] == maxLife && !instrumentsMax[i])
            {

            }
        }
    }

    public void Collect(int n_instrument)
    {
        if (instruments[n_instrument] < maxLife)
            instruments[n_instrument]++;
    }

    public void Delete(int n_instrument)
    {
        if(!invincible)
        {
            if (instruments[n_instrument] > 0 )
                instruments[n_instrument] -= 4;
            if (instruments[n_instrument] < 0)
                instruments[n_instrument] = 0;
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
