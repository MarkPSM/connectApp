using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CPDPin : MonoBehaviour
{
    [Header("Raycast")]
    public GraphicRaycaster raycaster;
    public EventSystem eventSystem;

    [Header("CPD Path Canvas")]
    public GameObject btnConluir;
    public GameObject btnCPD;
    public GameObject pinCPD;

    [SerializeField]
    private bool CanPlacePin = false;

    private void Start()
    {
        btnConluir.SetActive(false);
        btnCPD.SetActive(true);
        pinCPD.SetActive(false);
    }

    private void FixedUpdate()
    {
        GameObject clicked = UIObjectUnderMouse();

#if UNITY_EDITOR
        if (CanPlacePin && Input.GetMouseButtonDown(0) && clicked != null && clicked.CompareTag("PinArea"))
        {
            Debug.Log("Comparou");
            pinCPD.SetActive(true);
            pinCPD.transform.position = Input.mousePosition;

            btnCPD.SetActive(false);
            btnConluir.SetActive(true);
            CanPlacePin = false;
        }
        else if (!clicked.CompareTag("PinArea"))
        {
            Debug.Log("Fora da Área");
            return;
        }


        if (pinCPD.activeSelf && Input.GetMouseButton(0))
        {
            pinCPD.transform.position = Input.mousePosition;
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

        if (results.Count > 0)
            return results[0].gameObject;

        return null;
    }

    public void CPDInit()
    {
        CanPlacePin = true;
    }
}
