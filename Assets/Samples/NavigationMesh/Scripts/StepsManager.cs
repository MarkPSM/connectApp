using UnityEngine;
using UnityEngine.UI;

public class StepsManager : MonoBehaviour
{
    private CanvasManager canvasManager;

    [Header("Sliders")]
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;

    private void Start()
    {
        canvasManager = FindFirstObjectByType<CanvasManager>();
    }

    private void FixedUpdate()
    {
        if (canvasManager != null && canvasManager.currentStep == 2)
        {
            slider1.value += 0.2f * Time.deltaTime;
        }
        if (canvasManager != null && canvasManager.currentStep == 3)
        {
            slider2.value += 0.2f * Time.deltaTime;
        }
        if (canvasManager != null && canvasManager.currentStep == 4)
        {
            slider3.value += 0.2f * Time.deltaTime;
        }

    }
}
