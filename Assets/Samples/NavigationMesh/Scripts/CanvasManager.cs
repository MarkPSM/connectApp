using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelAuthorization;
    public GameObject panelPlay;
    public GameObject panelContinue;
    public GameObject panelBlueprint;
    public GameObject panelCPDPathYes;
    public GameObject panelChat;
    public GameObject panelPicture;
    public GameObject panelPreview;
    public GameObject panelPins;

    [Header("Buttons")]
    public GameObject btnChat;

    private ChatManagerIA chatManagerIA;

    private void Start()
    {
        panelAuthorization.SetActive(true);
        panelPlay.SetActive(false);
        panelContinue.SetActive(false);
        panelBlueprint.SetActive(false);
        panelCPDPathYes.SetActive(false);
        panelChat.SetActive(false);
        panelPicture.SetActive(false);
        panelPreview.SetActive(false);
        panelPins.SetActive(false);

        btnChat.SetActive(false);
        ChatManagerIA chatManagerIA = FindFirstObjectByType<ChatManagerIA>();
    }

    public void ConfirmPermission()
    {
        panelAuthorization.SetActive(false);
        panelPlay.SetActive(true);
    }

    public void Play()
    {
        panelPlay.SetActive(false);

        panelContinue.SetActive(true);
        btnChat.SetActive(true);
    }

    public void Continue()
    {
        panelContinue.SetActive(false);
        panelBlueprint.SetActive(true);
    }

    public void OpenChat()
    {
        panelChat.SetActive(true);
        btnChat.gameObject.SetActive(false);
    }

    public void CloseChat()
    {
        if (chatManagerIA != null)
        {
            chatManagerIA.ApagarMensagens();
        }
        btnChat.gameObject.SetActive(true);
        panelChat.SetActive(false);
    }

    public void No()
    {
        Debug.Log("Continue without blueprint");
    }

    public void Yes()
    {
        Debug.Log("Continue with blueprint");
        panelCPDPathYes.SetActive(true);
    }
}
