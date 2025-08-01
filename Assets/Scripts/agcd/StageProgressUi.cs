using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageProgressUi : MonoBehaviour
{
    [SerializeField] private Slider progressSlider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Color normalColor = Color.green;
    [SerializeField] private Color boosterColor = Color.yellow;

    void Update()
    {
        if (StageManager.Instance == null) return;

        float progress = StageManager.Instance.ElapsedTime / StageManager.Instance.TotalGameTime;
        progressSlider.value = progress; // 0 ~ 1
    }


    //public void FlashBoosterEffect()
    //{
    //    StopAllCoroutines();
    //    StartCoroutine(FlashFillColor());
    //}

    //private IEnumerator FlashFillColor()
    //{
    //    fillImage.color = boosterColor;
    //    yield return new WaitForSeconds(0.5f);
    //    fillImage.color = normalColor;
    //}
}