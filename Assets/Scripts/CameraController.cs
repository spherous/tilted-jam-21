using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cCam;
    [SerializeField] private Pirate pirate;

    void Start()
    {
        if(cCam == null)
            cCam = GetComponentInChildren<CinemachineVirtualCamera>();
        if(pirate == null)
            pirate = FindObjectOfType<Pirate>();
        
        if(cCam != null && pirate != null)
            cCam.Follow = pirate.transform;
    }
}