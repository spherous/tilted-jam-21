using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LookAlive lookAlive = this.GetComponent<LookAlive>();

        float rot_freq = 0.05f;

        lookAlive.rot_freq.y = Random.value * rot_freq;

        float pos_freq = 0.05f;

        lookAlive.pos_freq.x = Random.value * pos_freq;
        lookAlive.pos_freq.y = Random.value * pos_freq;
        lookAlive.pos_freq.z = Random.value * pos_freq;

        float amplitude = 5.0f;
        float amplitude_min = 0;

        lookAlive.pos_amplitude.x = (Random.value * amplitude) + amplitude_min;
        lookAlive.pos_amplitude.y = (Random.value * amplitude) + amplitude_min;
        lookAlive.pos_amplitude.z = (Random.value * amplitude) + amplitude_min;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
