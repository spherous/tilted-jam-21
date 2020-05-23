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
    }
}