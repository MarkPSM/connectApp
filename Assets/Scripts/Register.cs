using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Register : MonoBehaviour
{
    private CanvasManager canvasManager;

    [Header("Inputs")]
    [Space(-10)]
    [Tooltip("Name")]
    public TMP_InputField inputName;
    [Tooltip("Role")]
    public TMP_InputField inputRole;
    [Tooltip("Enterprise")]
    public TMP_InputField inputEnterprise;

    private void Start()
    {
        canvasManager = GetComponent<CanvasManager>();
    }

    public void Registering()
    {
        canvasManager.panelContinue.SetActive(true);
        canvasManager.btnChat.SetActive(true);
        canvasManager.btnSteps.SetActive(true);

        canvasManager.panelRegister.SetActive(false);
    }
}
