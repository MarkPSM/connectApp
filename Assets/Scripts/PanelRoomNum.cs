using TMPro;
using UnityEngine;

public class PanelRoomNum : MonoBehaviour
{
    public int roomNum;
    public TextMeshProUGUI inputField;

    private void FixedUpdate()
    {
        roomNum = int.Parse(inputField.text);
    }

    public void Concluir()
    {
        CanvasManager canvasManager = FindFirstObjectByType<CanvasManager>();

        canvasManager.panelRoomNum.SetActive(false);
        canvasManager.panelProgress.SetActive(true);
    }
}
