using UnityEngine;
using UnityEngine.UI;

public class BGMVolumeController : MonoBehaviour
{
    public AudioSource bgmSource;   // BGM AudioSource
    public Slider volumeSlider;     // UI Slider

    void Start()
    {
        // �����̴� �� ����� VolumeUpdate �Լ� ȣ��
        volumeSlider.onValueChanged.AddListener(VolumeUpdate);

        // �����̴� �ʱⰪ ���� (���� ����� ����)
        volumeSlider.value = bgmSource.volume;
    }

    void VolumeUpdate(float value)
    {
        bgmSource.volume = value;
    }
}
