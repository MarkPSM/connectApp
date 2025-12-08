using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelRoomNum : MonoBehaviour
{
    public int roomNum;
    public TMP_InputField inputField;

    private void Update()
    {
        if (int.TryParse(inputField.text, out int num))
        {
            roomNum = num;
            Debug.Log("Número da sala definido para: " + roomNum);
        }
        else
        {
            Debug.LogWarning("Input is not a valid room number.");
        }
        Debug.Log("Número da sala definido para: " + roomNum);
    }

    public void Concluir()
    {
        CanvasManager canvasManager = FindFirstObjectByType<CanvasManager>();

        canvasManager.panelRoomNum.SetActive(false);
        canvasManager.panelProgress.SetActive(true);
    }
}
