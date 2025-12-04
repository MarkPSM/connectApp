using UnityEngine;

public class RisksNB : MonoBehaviour
{
    [Header("Risks Cards")]
    public GameObject cardHeat;
    public GameObject cardCold;
    public GameObject cardPest;
    public GameObject cardInfra;
    public GameObject cardNature;
    public GameObject cardMagnetic;
    public GameObject cardFall;
    public GameObject cardRoom;
    public GameObject cardChemestry;
    public GameObject cardHumidity;

    private void Start()
    {
        cardHeat.SetActive(false);
        cardCold.SetActive(false);
        cardPest.SetActive(false);
        cardInfra.SetActive(false);
        cardNature.SetActive(false);
        cardMagnetic.SetActive(false);
        cardFall.SetActive(false);
        cardRoom.SetActive(false);
        cardChemestry.SetActive(false);
        cardHumidity.SetActive(false);
    }

    public void SelectHeatPin()
    {
        cardHeat.SetActive(true);
        cardHeat.SetActive(false);
        cardCold.SetActive(false);
        cardPest.SetActive(false);
        cardInfra.SetActive(false);
        cardNature.SetActive(false);
        cardMagnetic.SetActive(false);
        cardFall.SetActive(false);
        cardRoom.SetActive(false);
        cardChemestry.SetActive(false);
        cardHumidity.SetActive(false);
    }

    public void SelectColdPin()
    {
        cardCold.SetActive(true);
    }

    public void SelectPestPin()
    {
        cardPest.SetActive(true);
    }

    public void SelectInfraPin()
    {
        cardInfra.SetActive(true);
    }

    public void SelectNaturePin()
    {
        cardNature.SetActive(true);
    }

    public void SelectMagneticPin()
    {
        cardMagnetic.SetActive(true);
    }

    public void SelectFallPin()
    {
        cardFall.SetActive(true);
    }

    public void SelectRoomPin()
    {
        cardRoom.SetActive(true);
    }

    public void SelectChemestryPin()
    {
        cardChemestry.SetActive(true);
    }

    public void SelectHumidityPin()
    {
        cardHumidity.SetActive(true);
    }

    public void CloseCards()
    {
        cardHeat.SetActive(false);
        cardCold.SetActive(false);
        cardPest.SetActive(false);
        cardInfra.SetActive(false);
        cardNature.SetActive(false);
        cardMagnetic.SetActive(false);
        cardFall.SetActive(false);
        cardRoom.SetActive(false);
        cardChemestry.SetActive(false);
        cardHumidity.SetActive(false);
    }

    public void Concluir()
    {
        CanvasManager canvasManager = FindFirstObjectByType<CanvasManager>();
        canvasManager.panelFilter.SetActive(true);
        canvasManager.panelRisksNB.SetActive(false);
    }
}
