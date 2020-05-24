using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject coin;
    public float x_span_amplitude = 50;
    public float y_span_amplitude = 50;
    public float z_span_amplitude = 0;
    public int NumberOfClouds = 75;
    public int NumberOfCoins = 50;

    // Start is called before the first frame update
    void Start()
    {
        z_span_amplitude = 0;
        for (int i = 0; i < NumberOfClouds; i++)
        {
            // Instantiate at position (0, 0, 0) and zero rotation.
            Instantiate(prefab, new Vector3((Random.value - 0.5f ) * 2 * x_span_amplitude,
                                            (Random.value - 0.5f) * 2 * y_span_amplitude,
                                            (Random.value - 0.5f) * 2 * z_span_amplitude), Quaternion.identity);
        }
        for (int i = 0; i < NumberOfCoins; i++)
        {
            // Instantiate at position (0, 0, 0) and zero rotation.
            Instantiate(coin, new Vector3((Random.value - 0.5f) * 2 * x_span_amplitude,
                                            (Random.value - 0.5f) * 2 * y_span_amplitude,
                                            (Random.value - 0.5f) * 2 * z_span_amplitude), Quaternion.Euler(-90,0,0));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
