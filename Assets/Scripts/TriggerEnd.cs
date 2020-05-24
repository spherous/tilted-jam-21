using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    [SerializeField] private EndGame endUI;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.GetComponent<Pirate>())
        {
            endUI.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        

    }
}
