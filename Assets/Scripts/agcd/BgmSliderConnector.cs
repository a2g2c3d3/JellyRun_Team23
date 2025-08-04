using UnityEngine;
using UnityEngine.UI;

public class BGMSliderConnector : MonoBehaviour
{
    private void Start()
    {
        var bgm = FindObjectOfType<BGM>();
        var slider = GetComponent<Slider>();

        if (bgm != null && slider != null)
        {
            slider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
            slider.onValueChanged.AddListener(bgm.SetBGMVolume);
            Debug.Log("[로비 슬라이더] BGM 연결됨");
        }
    }
}