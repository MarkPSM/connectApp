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

        if(canvasManager.currentStep == 1 && canvasManager.hasBlueprint == true)
        {
            canvasManager.panelCPDPathYes.SetActive(true);
            canvasManager.currentStep++;
            canvasManager.panelProgress.SetActive(false);
            Debug.Log("Estágio atual: " + canvasManager.currentStep + "; CPD Path activated");
            return;
        }
        else if (canvasManager.currentStep == 1 && canvasManager.hasBlueprint == false)
        {
            canvasManager.panelTutorial.SetActive(true);
            canvasManager.currentStep++;
            canvasManager.panelProgress.SetActive(false);
            canvasManager.panelBlueprint.SetActive(false);
            Debug.Log("Estágio atual: " + canvasManager.currentStep + "; CPD Path activated");
            return;
        }
        else if(canvasManager.currentStep == 2 && canvasManager.hasBlueprint == true)
        {
            canvasManager.panelTutorial.SetActive(true);
            canvasManager.panelMap.SetActive(false);
            canvasManager.panelPins.SetActive(false);
            canvasManager.panelCPDPathYes.SetActive(false);
            canvasManager.currentStep++;
            canvasManager.panelProgress.SetActive(false);
            Debug.Log("Estágio atual: " + canvasManager.currentStep + "; Picture Area activated");
            return;
        }
        else if (canvasManager.currentStep == 2 && canvasManager.hasBlueprint == false)
        {
            canvasManager.panelRisksNB.SetActive(true);
            canvasManager.panelPicture.SetActive(false);
            canvasManager.panelPreview.SetActive(false);
            canvasManager.panelMeasure.SetActive(false);
            canvasManager.currentStep++;
            canvasManager.panelProgress.SetActive(false);
            Debug.Log("Estágio atual: " + canvasManager.currentStep + "; Picture Area activated");
            return;
        }
        else if(canvasManager.currentStep == 3 && canvasManager.hasBlueprint == true)
        {
            canvasManager.currentStep++;
            canvasManager.panelProgress.SetActive(false);
            canvasManager.panelEnd.SetActive(true);
            Debug.Log("Estágio atual: " + canvasManager.currentStep + "; End activated");
            return;
        }
        else if (canvasManager.currentStep == 3 && canvasManager.hasBlueprint == false)
        {
            canvasManager.panelEnd.SetActive(true);
            canvasManager.panelFilter.SetActive(false);
            canvasManager.currentStep++;
            canvasManager.panelProgress.SetActive(false);
            Debug.Log("Estágio atual: " + canvasManager.currentStep + "; Picture Area activated");
            return;
        }
        else
        {
            return;
        }


    }
}
