using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    // ĳ���� ID �Ǵ� �̸��� �����ϴ� �Լ�
    public void SelectCharacter(int characterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        PlayerPrefs.Save();

        // ���� ������ �̵�
        SceneManager.LoadScene("GameScene");
    }
}
