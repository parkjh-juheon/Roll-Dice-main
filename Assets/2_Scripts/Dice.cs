using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour
{
    [Header("�ֻ��� ��������Ʈ ����")]
    public Sprite[] diceFaces; // 0 ~ 5: 1~6 ��������Ʈ
    public SpriteRenderer spriteRenderer;

    [Header("�ִϸ��̼� ����")]
    public float rollDuration = 1.0f; // ������ ��ü �ð�
    public float rollInterval = 0.1f; // ���� �ٲ�� �ӵ�

    public int CurrentValue { get; private set; } = 1;
    private bool isRolling = false;

    // �ܺο��� ȣ���Ͽ� ���� ����
    public void RollDice()
    {
        if (!isRolling)
            StartCoroutine(RollDiceRoutine());
    }

    private IEnumerator RollDiceRoutine()
    {
        isRolling = true;

        float elapsed = 0f;
        while (elapsed < rollDuration)
        {
            int randIndex = Random.Range(0, diceFaces.Length);
            spriteRenderer.sprite = diceFaces[randIndex];
            elapsed += rollInterval;
            yield return new WaitForSeconds(rollInterval);
        }

        // ���� ��� ����
        CurrentValue = Random.Range(1, 7);
        spriteRenderer.sprite = diceFaces[CurrentValue - 1];

        isRolling = false;
    }

    public bool IsRolling()
    {
        return isRolling;
    }

    public void ResetDice()
    {
        // ���� �� �ʱ� ��(1)�� ����
        CurrentValue = 1;
        spriteRenderer.sprite = diceFaces[0];
    }
}


