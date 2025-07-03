// GameInitializer.cs ��� ���� ��ũ��Ʈ ����
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public GameObject playerDataPrefab; // PlayerData ������ ����

    void Awake()
    {
        if (PlayerData.Instance == null)
        {
            Instantiate(playerDataPrefab);
        }
    }
}
