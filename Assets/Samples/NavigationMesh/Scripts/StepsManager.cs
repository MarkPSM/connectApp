using UnityEngine;
using UnityEngine.UI;

public class StepsManager : MonoBehaviour
{
    private CanvasManager canvasManager;

    [Header("Sliders")]
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;

    [Header("Steps")]
    public GameObject step2;
    public GameObject step3;
    public GameObject step4;

    private void Start()
    {
        canvasManager = FindFirstObjectByType<CanvasManager>();
    }

    private void FixedUpdate()
    {
        if (canvasManager != null && canvasManager.currentStep == 2)
        {
            slider1.value += 1.2f * Time.deltaTime;
            Image step2Image = step2.GetComponent<Image>();
            if (step2Image != null)
            {
                Color currentColor = step2Image.color;
                currentColor += new Color(1f, 1f, 1f, 1f) * Time.deltaTime;
                step2Image.color = currentColor;
            }
        }
        if (canvasManager != null && canvasManager.currentStep == 3)
        {
            slider2.value += 1.2f * Time.deltaTime;
            Image step3Image = step3.GetComponent<Image>();
            if (step3Image != null)
            {
                Color currentColor = step3Image.color;
                currentColor += new Color(1f, 1f, 1f, 1f) * Time.deltaTime;
                step3Image.color = currentColor;
            }
        }
        if (canvasManager != null && canvasManager.currentStep == 4)
        {
            slider3.value += 1.2f * Time.deltaTime;
            Image step4Image = step4.GetComponent<Image>();
            if (step4Image != null)
            {
                Color currentColor = step4Image.color;
                currentColor += new Color(1f, 1f, 1f, 1f) * Time.deltaTime;
                step4Image.color = currentColor;
            }
        }
    }
}
