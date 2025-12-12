using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class CanvasManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelAuthorization;
    public GameObject panelPlay;
    public GameObject panelRegister;
    public GameObject panelContinue;
    public GameObject panelBlueprint;
    public GameObject panelCPDPathYes;
    public GameObject panelChat;
    public GameObject panelPicture;
    public GameObject panelPreview;
    public GameObject panelPins;
    public GameObject panelTutorial;
    public GameObject panelSteps;
    public GameObject panelProgress;
    public GameObject panelMap;
    public GameObject panelMeasure;
    public GameObject panelEnd;
    public GameObject panelRoomNum;
    public GameObject panelFilter;
    public GameObject panelRisksNB;

    [Header("Buttons")]
    public GameObject btnChat;
    public GameObject bgChat;
    public GameObject bgChatSelected;
    public GameObject btnSteps;
    public GameObject bgSteps;
    public GameObject bgStepsSelected;

    private ChatManagerIA chatManagerIA;

    [Header("Steps")]
    public int currentStep = 1;

    [Header("Blueprint")]
    public bool hasBlueprint;

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
        panelTutorial.SetActive(false);
        panelSteps.SetActive(false);
        panelProgress.SetActive(false);
        panelMap.SetActive(false);
        panelMeasure.SetActive(false);
        panelEnd.SetActive(false);
        panelRoomNum.SetActive(false);
        panelFilter.SetActive(false);
        panelRisksNB.SetActive(false);
        panelRegister.SetActive(false);

        btnChat.SetActive(false);
        btnSteps.SetActive(false);

        bgChatSelected.SetActive(false);
        bgStepsSelected.SetActive(false);

        chatManagerIA = FindFirstObjectByType<ChatManagerIA>();
    }

    public void ConfirmPermission()
    {
        panelAuthorization.SetActive(false);
        panelPlay.SetActive(true);
    }

    public void Play()
    {
        panelPlay.SetActive(false);
        panelRegister.SetActive(true);
    }

    public void Register()
    {
        panelRegister.SetActive(false);
        panelContinue.SetActive(true);
    }

    public void Continue()
    {
        panelContinue.SetActive(false);
        panelBlueprint.SetActive(true);
    }

    public void OpenChat()
    {
        panelChat.SetActive(true);

        bgChat.SetActive(false);
        bgChatSelected.SetActive(true);
    }

    public void CloseChat()
    {
        if (chatManagerIA != null)
        {
            chatManagerIA.ApagarMensagens();
        }

        bgChat.SetActive(true);
        bgChatSelected.SetActive(false);
        panelChat.SetActive(false);
    }

    public void OpenSteps()
    {
        panelSteps.SetActive(true);

        bgSteps.SetActive(false);
        bgStepsSelected.SetActive(true);
    }

    public void CloseSteps()
    {
        panelSteps.SetActive(false);

        bgSteps.SetActive(true);
        bgStepsSelected.SetActive(false);
    }

    public void No()
    {
        Debug.Log("Continue without blueprint");
        panelBlueprint.SetActive(false);
        hasBlueprint = false;
        panelRoomNum.SetActive(true);
    }

    public void Yes()
    {
        Debug.Log("Continue with blueprint");
        hasBlueprint = true;
        panelBlueprint.SetActive(false);
        panelPicture.SetActive(true);
    }

    public void SkipTutorial()
    {
        panelTutorial.SetActive(false);
        panelPicture.SetActive(true);
    }

    public void Fechar()
    {
        Application.Quit();
    }

    public void FilterOK()
    {
        panelFilter.SetActive(false);
        panelProgress.SetActive(true);
    }
}