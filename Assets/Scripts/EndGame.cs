using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Button EndButton;
    // Start is called before the first frame update
    void Start()
    {
        EndButton.onClick.AddListener(End);
    }
    private void End()
    {
        Application.Quit();
    }
}
