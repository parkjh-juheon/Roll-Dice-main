using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Unit playerUnit; // �ν����� ���� or Start()���� �ڵ� �����

    private void Start()
    {
        // Start���� PlayerData �� Unit �ڵ� ����
        if (playerUnit == null)
        {
            playerUnit = FindObjectOfType<Unit>();
        }
    }

    public void ChangeToScene(string sceneName)
    {
        if (playerUnit != null)
        {
            // Restart ������ Title ������ �� �� �ʱ�ȭ
            if (sceneName == "Title") // Restart ��ư Ŭ�� ��
            {
                PlayerData.Instance.currentHP = PlayerData.Instance.maxHP;
                PlayerData.Instance.SaveHP();
            }
            else
            {
                playerUnit.SaveHP(); // �Ϲ����� �� �̵��� ���� ü�� ����
            }
        }

        SceneManager.LoadScene(sceneName);
    }

    // Option UI�� Restart ��ư�� ������ �Լ� (�� ��Ȯ�� ���)
    public void RestartGame()
    {
        if (playerUnit != null)
        {
            PlayerData.Instance.currentHP = PlayerData.Instance.maxHP;
            PlayerData.Instance.SaveHP();
        }

        SceneManager.LoadScene("Title"); // Restart �� Title�� �̵�
    }
}
