using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Pirate pirate;

    void Start()
    {
        pirate = FindObjectOfType<Pirate>();
    }

    void Update()
    {
        pirate?.Move(Input.GetAxis("Horizontal"));
        if(Input.GetKeyDown(KeyCode.Space))
            pirate?.Jump();
    }
}