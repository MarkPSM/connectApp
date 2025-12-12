using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CPDPin : MonoBehaviour
{
    [Header("Title")]
    public GameObject title1;
    public GameObject title2;

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
        title1.SetActive(true);
        title2.SetActive(false);
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

                if (btnContinuar.activeSelf == false)
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
        if (clickCooldown <= 0f && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && clicked != null && clicked.CompareTag("PinArea") && currentStep == 0)
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
        else {
                    return;
        }
        clickCooldown = 0.5f;

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
        title2.SetActive(true);
        title1.SetActive(false);
    }

    public void Conclude()
    {
        CanvasManager canvasManager = FindFirstObjectByType<CanvasManager>();
        canvasManager.panelPins.SetActive(true);
        canvasManager.panelProgress.SetActive(true);
        canvasManager.panelCPDPathYes.SetActive(false);
    }
}