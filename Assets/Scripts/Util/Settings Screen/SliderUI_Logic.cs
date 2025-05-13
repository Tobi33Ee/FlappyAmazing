using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderUI_Logic : MonoBehaviour
{
    private string percentageText;
    private float percentage;

    [SerializeField] private TextMeshProUGUI percentageLabel;
    [SerializeField] private Slider mySlider;

    void Awake()
    {
        float sliderValue = 1.0f; // Standardwert, falls keine Einstellung vorhanden

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            sliderValue = PlayerPrefs.GetFloat("musicVolume");
        }
        if (PlayerPrefs.HasKey("effectVolume"))
        {
            sliderValue = PlayerPrefs.GetFloat("effectVolume");
        }

        mySlider.value = sliderValue;
        updatePercentage(sliderValue);
    }

    public void updatePercentage(float sliderFloat)
    {
        // sliderFloat = 0 - 1
        percentage = sliderFloat * 100f;
        percentageText = percentage.ToString("000") + " %";
        percentageLabel.text = percentageText;
    }
}
