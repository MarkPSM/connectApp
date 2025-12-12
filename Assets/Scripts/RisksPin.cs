using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RisksPin : MonoBehaviour
{
    [Header("Raycast")]
    public GraphicRaycaster raycaster;
    public EventSystem eventSystem;

    [Header("Pins Father")]
    public GameObject pinsFather;

    [Header("Risk Pins Sprites")]
    public Sprite pinHeat;
    public Sprite pinCold;
    public Sprite pinPest;
    public Sprite pinInfra;
    public Sprite pinNature;
    public Sprite pinMagnetic;
    public Sprite pinFall;
    public Sprite pinRoom;
    public Sprite pinChemestry;
    public Sprite pinHumidity;

    [SerializeField]
    private bool canPlacePins;
    private Sprite actualPin;

    [Header("Risk Cards")]
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

        pinsFather.SetActive(true);
    }

    private void FixedUpdate()
    {
        GameObject clicked = UIObjectUnderMouse();

        if (canPlacePins && Input.GetMouseButtonDown(0) && clicked != null && clicked.gameObject.CompareTag("NullPin"))
        {
            clicked.gameObject.GetComponent<Image>().sprite = actualPin;
            clicked.gameObject.tag = "Raycast Ignore";
        }
    }

    private GameObject UIObjectUnderMouse()
    {
        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(eventData, results);

        foreach (var r in results)
        {
            if (!r.gameObject.CompareTag("Raycast Ignore"))
            {
                return r.gameObject;
            }
        }

        return null;
    }

    public void SelectHeatPin()
    {
        actualPin = pinHeat;
        cardHeat.SetActive(true);
        canPlacePins = true;

        pinsFather.SetActive(false);
    }

    public void SelectColdPin()
    {
        actualPin = pinCold;
        cardCold.SetActive(true);
        canPlacePins = true;

        pinsFather.SetActive(false);
    }

    public void SelectPestPin()
    {
        actualPin = pinPest;
        cardPest.SetActive(true);
        canPlacePins = true;

        pinsFather.SetActive(false);
    }

    public void SelectInfraPin()
    {
        actualPin = pinInfra;
        cardInfra.SetActive(true);
        canPlacePins = true;

        pinsFather.SetActive(false);
    }

    public void SelectNaturePin()
    {
        actualPin = pinNature;
        cardNature.SetActive(true);
        canPlacePins = true;

        pinsFather.SetActive(false);
    }

    public void SelectMagneticPin()
    {
        actualPin = pinMagnetic;
        cardMagnetic.SetActive(true);
        canPlacePins = true;

        pinsFather.SetActive(false);
    }

    public void SelectFallPin()
    {
        actualPin = pinFall;
        cardFall.SetActive(true);
        canPlacePins = true;

        pinsFather.SetActive(false);
    }

    public void SelectRoomPin()
    {
        actualPin = pinRoom;
        cardRoom.SetActive(true);
        canPlacePins = true;

        pinsFather.SetActive(false);
    }

    public void SelectChemestryPin()
    {
        actualPin = pinChemestry;
        cardChemestry.SetActive(true);
        canPlacePins = true;

        pinsFather.SetActive(false);
    }

    public void SelectHumidityPin()
    {
        actualPin = pinHumidity;
        cardHumidity.SetActive(true);
        canPlacePins = true;

        pinsFather.SetActive(false);
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
        canPlacePins = false;

        pinsFather.SetActive(true);
    }

    public void Concluir()
    {
        CanvasManager canvasManager = FindFirstObjectByType<CanvasManager>();
        canvasManager.panelProgress.SetActive(true);
    }
}
