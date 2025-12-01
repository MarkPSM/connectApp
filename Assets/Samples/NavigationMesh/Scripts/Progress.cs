using TMPro;
using UnityEngine;

public class Progress : MonoBehaviour
{
    private CanvasManager canvasManager;

    public TextMeshProUGUI stepNum;

    private void Start()
    {
        canvasManager = FindFirstObjectByType<CanvasManager>();
    }

    private void FixedUpdate()
    {
        stepNum.text = canvasManager.currentStep.ToString();
    }

    public void Continue()
    {
        canvasManager.OpenSteps();

        if(canvasManager.currentStep == 1)
        {
            canvasManager.panelCPDPathYes.SetActive(true);
            canvasManager.currentStep++;
            canvasManager.panelProgress.SetActive(false);
            Debug.Log("Estágio atual: " + canvasManager.currentStep);
            return;
        }
        else if(canvasManager.currentStep == 2)
        {
            canvasManager.panelTutorial.SetActive(true);
            canvasManager.panelMap.SetActive(false);
            canvasManager.panelPins.SetActive(false);
            canvasManager.currentStep++;
            canvasManager.panelProgress.SetActive(false);
            Debug.Log("Estágio atual: " + canvasManager.currentStep);
            return;
        }
        else if(canvasManager.currentStep == 3)
        {
            canvasManager.currentStep++;
            canvasManager.panelProgress.SetActive(false);
            Debug.Log("Estágio atual: " + canvasManager.currentStep);
            return;
        }
        else
        {
            return;
        }


    }
}
