using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�


public class MapProgressUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider progressSlider;

    private void Start()
    {
        if (progressSlider == null)
        {
            Debug.LogError("MapProgressUI: �����̴� ���۷����� �����ϴ�.");
            enabled = false;
            return;
        }
        progressSlider.value = 0;
    }

    private void OnEnable()
    {
        MapProgress.ProgressChanged += UpdateProgressSlider;
    }

    private void OnDisable()
    {
        MapProgress.ProgressChanged -= UpdateProgressSlider;
    }

    private void UpdateProgressSlider(float percentage)
    {
        if (progressSlider != null)
        {
            progressSlider.value = percentage;
        }
    }
}
