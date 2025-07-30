using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가


public class MapProgressUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider progressSlider;

    private void Start()
    {
        if (progressSlider == null)
        {
            Debug.LogError("MapProgressUI: 슬라이더 레퍼런스가 없습니다.");
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
