using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unit : MonoBehaviour
{
    [Header("�⺻ ���� ����")]
    public string unitName = "Player";
    public int maxHP = 20;
    public bool IsDead => CurrentHP <= 0;

    [Header("UI ���")]
    public TextMeshProUGUI hpText;

    [Header("�ֻ��� ���� ����")]
    public Transform[] attackSlots;
    public Transform[] defenseSlots;
    public Transform[] hitSlots;

    [Header("�ִϸ��̼�")]
    public Animator animator;

    [Header("�ǰ� ����Ʈ")]
    public GameObject hitEffectPrefab;
    public Transform hitEffectPoint;

    [Header("ȸ�� ����Ʈ")]
    public GameObject healEffectPrefab;
    public Transform healEffectPoint; 


    private void Awake()
    {
        LoadHP();
        UpdateHPUI();
    }

    public int CurrentHP
    {
        get => PlayerData.Instance.currentHP;
        set
        {
            PlayerData.Instance.currentHP = Mathf.Clamp(value, 0, maxHP);
            UpdateHPUI();
        }
    }

    public void UpdateHPUI()
    {
        if (hpText != null)
            hpText.text = $"{CurrentHP}/{maxHP}";
    }

    public void TakeDamage(int damage)
    {
        int prevHP = CurrentHP;
        CurrentHP -= damage;

        if (damage > 0 && CurrentHP < prevHP)
        {
            if (animator != null)
                animator.SetTrigger("Hit");

            if (CameraShake.Instance != null)
                CameraShake.Instance.ShakeCamera();

            if (hitEffectPrefab != null && hitEffectPoint != null)
            {
                GameObject effect = Instantiate(hitEffectPrefab, hitEffectPoint.position, Quaternion.identity);
                var ps = effect.GetComponent<ParticleSystem>();
                if (ps != null) ps.Play();
                Destroy(effect, 2f);
            }
        }

        if (unitName == "Player" && CurrentHP <= 0)
        {
            Debug.Log("Game Over!");
            if (animator != null)
                animator.SetTrigger("Death");

            StartCoroutine(LoadGameOverSceneWithDelay(1.5f));
        }
    }

    public void Heal(int amount)
    {
        int prevHP = CurrentHP;
        CurrentHP += amount;

        if (healEffectPrefab != null && healEffectPoint != null)
        {
            GameObject effect = Instantiate(healEffectPrefab, healEffectPoint.position, Quaternion.identity);
            ParticleSystem ps = effect.GetComponentInChildren<ParticleSystem>();
            if (ps != null)
            {
                Debug.Log(" ȸ�� ����Ʈ: ParticleSystem ã��, ��� ����");
                ps.Play();
            }
            else
            {
                Debug.LogWarning(" ȸ�� ����Ʈ: ParticleSystem ã�� ����");
            }
            Destroy(effect, 2f);
        }

    }


    public void SaveHP()
    {
        PlayerData.Instance.SaveHP();
    }

    public void LoadHP()
    {
        if (unitName == "Player")
        {
            PlayerData.Instance.LoadHP();
        }
        else
        {
            PlayerData.Instance.currentHP = maxHP;
        }
    }

    private System.Collections.IEnumerator LoadGameOverSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }
}
