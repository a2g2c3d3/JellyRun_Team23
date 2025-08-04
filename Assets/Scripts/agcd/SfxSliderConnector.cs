using UnityEngine;
using UnityEngine.UI;

public class SFXSliderConnector : MonoBehaviour
{
    private void Start()
    {
        var sfx = FindObjectOfType<SFX>();
        var slider = GetComponent<Slider>();

        if (sfx != null && slider != null)
        {
            slider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
            slider.onValueChanged.AddListener(sfx.SetSFXVolume);
            Debug.Log("[�κ� �����̴�] SFX �����");
        }
    }
}