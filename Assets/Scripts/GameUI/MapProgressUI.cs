using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가


public class MapProgressUI : MonoBehaviour
{
    [SerializeField] private Slider progressSlider;

    private void OnEnable()
    {
        MapProgress.OnProgressChanged += UpdateProgressSlider;
    }

    private void OnDisable()
    {
        MapProgress.OnProgressChanged -= UpdateProgressSlider;
    }

    private void UpdateProgressSlider(float percentage)
    {
        if (progressSlider != null)
        {
            progressSlider.value = percentage;
        }
    }
}
