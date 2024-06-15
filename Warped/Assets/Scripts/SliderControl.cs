using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public Slider slider;
    float sliderValuePrevious;
    string sliderTextPrevious;
    public Text sliderText;
    bool first = true;
    public InputField input;
    SensitivitySaver senseSaver;

    // Start is called before the first frame update
    void Start()
    {
        senseSaver = FindObjectOfType<SensitivitySaver>();
        slider.value = SensitivitySaver.sensitivity;
        sliderText.text = round(slider.value).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (first) {
            sliderText.text = round(slider.value).ToString();
            first = false;
        }

        if (round(slider.value) != sliderValuePrevious){
            sliderText.text = round(slider.value).ToString();
        }

        input.text = "";

        
    }

    public float round(float number) {
        int temp = (int) Mathf.Round(number * 100);
        float answer = temp/100.0f;
        return answer;
    }
}
