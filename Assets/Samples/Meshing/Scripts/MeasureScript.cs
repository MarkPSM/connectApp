using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MeasureScript : MonoBehaviour
{
    [Header("AR")]
    public ARRaycastManager ARRaycastManager;

    [Header("Measurement Control")]
    private bool canMeasure = true;

    [Header("Dots Management")]
    private List<GameObject> dots = new List<GameObject>();
    private List<GameObject> totalDots = new List<GameObject>();

    [Header("Line Renderer")]
    public GameObject dotPrefab;
    public Material lineMaterial;
    public TextMeshPro textPrefab;
    private LineRenderer line;
    private TextMeshPro measureText;
    private List<GameObject> measureTexts = new List<GameObject>();

    [Header("UI Elements")]
    public GameObject aim;
    public GameObject tutorial;
    public GameObject header;
    public GameObject footer;
    public GameObject btnReload;

    [Header("Results")]
    public float distance;
    public List<float> distances = new List<float>();

    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.startWidth = 0.005f;
        line.endWidth = 0.005f;
        line.useWorldSpace = true;
        line.material = lineMaterial;
        line.material.color = Color.green;
        line.positionCount = 0;

        btnReload.SetActive(false);
        footer.SetActive(false);

    }

    private void FixedUpdate()
    {
        if (canMeasure == false) return;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 aimPosition = new Vector2(Screen.width / 2, Screen.height / 2);
            Debug.Log("Mouse click detected at position: " + aimPosition);

            header.SetActive(false);
            btnReload.SetActive(true);
            tutorial.SetActive(false);

            if (Physics.Raycast(Camera.main.ScreenPointToRay(aimPosition), out RaycastHit hit))
            {
                OnTouch(hit.point);
            }
        }
#else
    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    {
        Vector2 aimPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        header.SetActive(false);
        btnReload.SetActive(true);
        tutorial.SetActive(false);

        if (ARRaycastManager.Raycast(aimPosition, hits, TrackableType.Planes | TrackableType.FeaturePoint
))
{
    Pose hitPose = hits[0].pose;
    OnTouch(hitPose.position);
}
    }
#endif

        if (dots.Count == 1)
        {
            UpdateMeasurement();
        }
    }

    void OnTouch(Vector3 position)
    {
        var dot = Instantiate(dotPrefab, position, Quaternion.identity);
        dots.Add(dot);

        if (dots.Count == 2)
        {
            FinalizeMeasurement();
            footer.SetActive(true);
        }
    }

    void UpdateMeasurement()
    {
        Vector3 dot1 = dots[0].transform.position; 
        Vector3 cameraPos = Camera.main.transform.position;

        //// Decide se trava X ou Y
        //Vector3 dir = cameraPos - dot1;

        //float absX = Mathf.Abs(dir.x);
        //float absY = Mathf.Abs(dir.y);
        //float absZ = Mathf.Abs(dir.z);

        //if (absX > absY && absX > absZ)
        //    cameraPos = new Vector3(cameraPos.x, dot1.y, dot1.z); // Linha no X
        //else if (absY > absX && absY > absZ)
        //    cameraPos = new Vector3(dot1.x, cameraPos.y, dot1.z); // Linha no Y
        //else 
        //    cameraPos = new Vector3(dot1.x, dot1.y, cameraPos.z); // Linha no Z

        line.positionCount = 2;
        line.SetPosition(0, dot1);

        Vector2 aimPosition = new Vector2(Screen.width / 2, Screen.height / 2);

        float distance = 0f;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(aimPosition), out RaycastHit hit))
        {
            line.SetPosition(1, hit.point);
            distance = Vector3.Distance(dot1, hit.point); 
        }

        UpdateText(distance, (dot1 + cameraPos) / 2);
    }


    void UpdateText(float distance, Vector3 position)
    {
        if (measureText == null)
        {
            measureText = Instantiate(textPrefab, position, Quaternion.identity);
        }

        measureText.transform.position = Vector3.Lerp(measureText.transform.position, Camera.main.transform.position, -0.5f);

        measureText.text = $"{distance:F2}m";
        measureText.transform.LookAt(Camera.main.transform.position);
        measureText.transform.Rotate(0, 180, 0);
    }

    void FinalizeMeasurement()
    {
        Vector3 dot1 = dots[0].transform.position;
        Vector3 dot2 = dots[1].transform.position;

        //// Aplica snap 90°
        //Vector3 dir = dot2 - dot1;

        //float absX = Mathf.Abs(dir.x);
        //float absY = Mathf.Abs(dir.y);
        //float absZ = Mathf.Abs(dir.z);

        //if (absX > absY && absX > absZ)
        //    dot2 = new Vector3(dot2.x, dot1.y, dot1.z);
        //else if (absY > absX && absY > absZ)
        //    dot2 = new Vector3(dot1.x, dot2.y, dot1.z);
        //else
        //    dot2 = new Vector3(dot1.x, dot1.y, dot2.z);

        distance = Vector3.Distance(dot1, dot2);
        distances.Add(distance);

        line.positionCount = 2;
        line.SetPosition(0, dot1);
        line.SetPosition(1, dot2);

        measureText.transform.position = (dot1 + dot2) / 2 + Vector3.up * 0.02f;
        measureText.text = $"{distance:F2}m";
        measureTexts.Add(measureText.gameObject);

        totalDots.AddRange(dots);
        dots.Clear();
        measureText = null;
    }

    public void ReloadMeasures()
    {
        canMeasure = false;

        foreach (var dot in totalDots)
        {
            Destroy(dot);

            if (dot == null)
                Debug.Log("Destroyed dot");
            else
                Debug.Log("Failed to destroy dot");
        }

        dots.Clear();

        line.positionCount = 0;

        foreach (var text in measureTexts)
        {
            Destroy(text);

            if(text == null)
                Debug.Log("Destroyed measure text");
            else
                Debug.Log("Failed to destroy measure text");
        }
        measureTexts.Clear();
        btnReload.SetActive(false);
        header.SetActive(true);
        footer.SetActive(false);

        distances.Clear();
        distance = 0f;

        canMeasure = true;
    }

    public void SendMeasures()
    {
        canMeasure = false;

        if (distances.Count == 0) return;
        
        if(distances.Count == 1)
        {
            Debug.Log($"Only one measurement: {distances[0]:F2}m (Height)");
            distance = distances[0];
            canMeasure = true;
            ReloadMeasures();
            return;
        }
        else if(distances.Count == 2)
        {
            float height = Mathf.Max(distances[0], distances[1]);
            Debug.Log($"Two measurements: {distances[0]:F2}m, {distances[1]:F2}m (Area)");
            float area = distances[0] * distances[1];
            Debug.Log($"Calculated area: {area:F2}m²");
            canMeasure = true;
            ReloadMeasures();
            return;
        }
        else
        {
            Debug.Log("Multiple measurements detected. Concluding with the first two only.");
            ReloadMeasures();
            return;
        }

    }

}
