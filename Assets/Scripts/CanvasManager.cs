using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

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
    public GameObject btnSteps;

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

        btnChat.SetActive(false);
        btnSteps.SetActive(false);

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

        panelContinue.SetActive(true);
        btnChat.SetActive(true);
        btnSteps.SetActive(true);
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
        
        if(panelSteps.activeSelf == true)
        {
            panelSteps.SetActive(false);
            btnSteps.gameObject.SetActive(true);
        }
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

    public void OpenSteps()
    {
        panelSteps.SetActive(true);
        btnSteps.gameObject.SetActive(false);

        if (panelChat.activeSelf == true)
        {
            panelChat.SetActive(false);
            btnChat.gameObject.SetActive(true);
        }
    }

    public void CloseSteps()
    {
        btnSteps.gameObject.SetActive(true);
        panelSteps.SetActive(false);
    }

    public void No ()
    {
        Debug.Log("Continue without blueprint");
        hasBlueprint = false;
        panelRoomNum.SetActive(true);
    }

    public void Yes()
    {
        Debug.Log("Continue with blueprint");
        hasBlueprint = true;
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