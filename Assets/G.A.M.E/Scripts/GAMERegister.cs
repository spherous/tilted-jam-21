//  GAMEunlock.cs
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GAMERegister : MonoBehaviour
{
    // Set this to your Game ID assigned by bookletgames.com/game
    public string GameID = "Assigned by bookletgames.com/game";
    // Set this to your Game KEY assigned by bookletgames.com/game
    public string GameKEY = "Assigned by bookletgames.com/game";
    // Set this to your Game API assigned by bookletgames.com/game
    public string GameAPI = "Assigned by bookletgames.com/game";

    public TMPro.TMP_InputField txtEmail;
    public TMPro.TextMeshProUGUI ServerMessage;
    public GameObject Success;
    public GameObject Failed;
    public UnityEngine.UI.Button SubmitButton;
    public float MessageDwell = 5.0f;

    class GAMEData
    {
        // Set this to your Game ID assigned by bookletgames.com/game
        public string GameID;
        // Set this to your Game KEY assigned by bookletgames.com/game
        public string GameKEY;
        // Set this to your Game API assigned by bookletgames.com/game
        public string GameAPI;

        // Set this to your player's e-mail address
        public string PlayerEmail = "player@url.tld";

        // Sets how long the returned message from the server is displayed in seconds.
        public float MessageDwell = 5.0f;
    }

    GAMEData gamedata = new GAMEData();

    // Method 2: Server request
    const string url = "https://bookletgames.com/game/api/register.php";

    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(SubmitButton);
        SubmitButton.onClick.AddListener(delegate {
            OnClickSubmitRequestForUnlock(gamedata, Success, Failed, ServerMessage);
        });
    }

    // Method 2: Server request
    private void OnClickSubmitRequestForUnlock(GAMEData gamedata, GameObject Success, GameObject Failed, TMPro.TextMeshProUGUI ServerMessage)
    {
        gamedata.GameID = GameID;
        gamedata.GameKEY = GameKEY;
        gamedata.GameAPI = GameAPI;
        gamedata.PlayerEmail = txtEmail.text;
        gamedata.MessageDwell = MessageDwell;

        StartCoroutine(ServerRequestForUnlock(gamedata, Success, Failed, ServerMessage));
    }

    // Method 2: Server request
    static IEnumerator ServerRequestForUnlock(GAMEData gamedata, GameObject Success, GameObject Failed, TMPro.TextMeshProUGUI ServerMessage)
    {
        // Setup form responses
        WWWForm form = new WWWForm();

        form.AddField("GameID", gamedata.GameID);
        form.AddField("GameKEY", gamedata.GameKEY);
        form.AddField("GameAPI", gamedata.GameAPI);
        form.AddField("PlayerEmail", gamedata.PlayerEmail);

        // Submit form to our server, then wait
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        Debug.Log("Request sent!");

        yield return www.SendWebRequest();

        Debug.Log("Request completed!");

        // Print results
        if (www.error != null)
        {
            Failed.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            Failed.SetActive(false);
            Debug.Log("WWW Error: " + www.error);
        }
        else if (www.isNetworkError || www.isHttpError)
        {
            Failed.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            Failed.SetActive(false);
            Debug.Log("WWW Error: " + "Unknown");
        }
        else
        {
            ServerMessage.text = www.downloadHandler.text;
            Success.SetActive(true);
            yield return new WaitForSeconds(gamedata.MessageDwell);
            Success.SetActive(false);

            Debug.Log("WWW Success!: " + www.responseCode.ToString() + " " + www.downloadHandler.text );
        }

    }

}
