using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    private CinemachineCamera vcam;
    private CinemachineBasicMultiChannelPerlin noise;

    [Header("����ũ ����")]
    public float shakeDuration = 0.3f;
    public float shakeAmplitude = 2.0f;
    public float shakeFrequency = 2.0f;

    private float shakeTimer;
    private Vector3 mainCamOriginalPosition; // ���� ī�޶� ��ġ �����
    private Transform mainCamTransform;      // ���� ī�޶� Transform ����

    void Awake()
    {
        Instance = this;
        vcam = GetComponent<CinemachineCamera>();
        if (vcam != null)
        {
            noise = vcam.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
        }
        if (noise == null)
        {
            Debug.LogError("CinemachineBasicMultiChannelPerlin ������Ʈ�� ã�� �� �����ϴ�.");
        }

        // ���� ī�޶� Transform ã��
        if (Camera.main != null)
        {
            mainCamTransform = Camera.main.transform;
            mainCamOriginalPosition = mainCamTransform.position;
        }
        else
        {
            Debug.LogError("Main Camera�� ã�� �� �����ϴ�.");
        }
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            if (shakeTimer <= 0f)
            {
                StopShake();
            }
        }
    }
    public void StopShake()
    {
        if (noise == null) return;
        noise.AmplitudeGain = 0f;
        noise.FrequencyGain = 0f;

        // ���� ī�޶� ��ġ ����
        if (mainCamTransform != null)
            mainCamTransform.position = mainCamOriginalPosition;
    }

    internal void ShakeCamera()
    {
        if (noise == null) return;

        // ���� �� ���� ī�޶� ��ġ ����
        if (mainCamTransform != null)
            mainCamOriginalPosition = mainCamTransform.position;

        noise.AmplitudeGain = shakeAmplitude;
        noise.FrequencyGain = shakeFrequency;
        shakeTimer = shakeDuration;
    }

}
