using UnityEngine;
using UnityEngine.UI; // UI ���� ����� ����ϱ� ���� �߰�

public class GameManager : MonoBehaviour
{
    // ���� ��ư�� �Ҵ��� �Լ�
    public void QuitGame()
    {
        // �����Ϳ��� ���� ���� ���� ����� ���ø����̼ǿ��� ���� ���� ���� ����
#if UNITY_EDITOR
        // �����Ϳ��� �÷��� ��带 ����
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ����� ���ø����̼� ����
        Application.Quit();
#endif

        Debug.Log("���� ����!"); // ����� �뵵
    }
}