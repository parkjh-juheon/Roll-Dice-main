using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject targetPanel; // Ȱ��ȭ�� �г�

    public void ShowPanel()
    {
        targetPanel.SetActive(true); // �г��� Ȱ��ȭ
    }

    public void HidePanel()
    {
        targetPanel.SetActive(false); // �г� ��Ȱ��ȭ
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ���� Ȱ��ȭ ���¸� �������Ѽ� SetActive
            bool isActive = targetPanel.activeSelf;
            targetPanel.SetActive(!isActive);

        }
    }
}