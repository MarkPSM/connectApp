using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CPDPin : MonoBehaviour
{
    [Header("Title")]
    public TextMeshProUGUI title;

    [Header("Raycast")]
    public GraphicRaycaster raycaster;
    public EventSystem eventSystem;

    [Header("Pins Father")]
    public GameObject pinsFather;

    [Header("Path Pin")]
    public GameObject pinPrefab;
    public TextMeshProUGUI txtPinCount;

    [Header("CPD Pin")]
    public Sprite pinCPD;

    [Header("Buttons")]
    public GameObject btnContinuar;
    public GameObject btnConluir;

    [SerializeField]
    private int currentStep;

    [SerializeField]
    private float clickCooldown = 0.5f;

    [Header("Pins Quantity")]
    public int pinCount = 0;

    private void Start()
    {
        btnConluir.SetActive(false);
        btnContinuar.SetActive(false);

        currentStep = 0;
        title.text = "Clique nas salas de interesse, (da porta de entrada até o CPD)";
    }

    private void FixedUpdate()
    {
        GameObject clicked = UIObjectUnderMouse();

        clickCooldown -= Time.fixedDeltaTime;

#if UNITY_EDITOR
        if (clickCooldown <= 0f && Input.GetMouseButtonDown(0) && clicked != null)
        {
            if (clicked.gameObject.CompareTag("PinArea") && currentStep == 0)
            {
                pinCount++;
                Debug.Log("Pin Count: " + pinCount);
                txtPinCount.text = pinCount.ToString();
                Instantiate(pinPrefab, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0), Quaternion.identity, pinPrefab.transform.parent);
                pinPrefab.transform.SetParent(pinsFather.transform, worldPositionStays: true);
                
                if(btnContinuar.activeSelf == false)
                {
                    btnContinuar.SetActive(true);
                }
            }
            else if (currentStep == 1 && clicked.gameObject.CompareTag("NullPin"))
            {
                clicked.gameObject.GetComponent<Image>().sprite = pinCPD;
                clicked.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "CPD";
                clicked.gameObject.tag = "Raycast Ignore";
                currentStep = 2;

                btnConluir.SetActive(true);
            }
            else
            {
                return;
            }

            clickCooldown = 0.5f;
        }

#else
        if (CanPlacePin && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && clicked != mull && clicked.CompareTag("PinArea")
        {
            pinCPD.SetActive(true);
            pinCPD.transform.position = Input.GetTouch(0).position;

            btnCPD.SetActive(false);
            btnConluir.SetActive(true);
            CanPlacePin = false;
        }

        if(pinCPD.activeSelf && Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary))
        {
            pinCPD.transform.position = Input.GetTouch(0).position;
        }
#endif
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

    public void Continue()
    {
        currentStep = 1;
        btnContinuar.SetActive(false);
        title.text = "Clique no pin do CPD";
    }

    public void Conclude()
    {
        CanvasManager canvasManager = FindFirstObjectByType<CanvasManager>();
        canvasManager.panelPins.SetActive(true);
        canvasManager.panelCPDPathYes.SetActive(false);
    }
}