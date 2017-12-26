using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameModifierSettings : MonoBehaviour {

    public SettingsHolder settingsHolder;

    public Toggle acceleratorToggle;
    public Slider acceleratorSlider;
    public InputField acceleratorInputField;

    public Toggle ballSizeToggle;
    public Slider ballSizeSlider;
    public InputField ballSizeInputField;

    public Slider ballCountSlider;
    public InputField ballCountInputField;

    public Slider ballSpeedSlider;
    public InputField ballSpeedInputField;

    public Slider playerSpeedSlider;
    public InputField playerSpeedInputField;

    public Slider scoreSlider;
    public InputField scoreInputField;

    public Slider hitFactorSlider;
    public InputField hitFactorInputField;


    //This class is to hold the enabled/disabled state of gameplay modifiers.

    public void OnEnable()
    {
        acceleratorSlider.value = settingsHolder.acceleratorModifier;
        changeModifierSlider(acceleratorSlider, acceleratorSlider.value, acceleratorInputField);

        ballCountSlider.value = settingsHolder.ballCount;
        changeModifierSlider(ballCountSlider, ballCountSlider.value, ballCountInputField);

        ballSizeSlider.value = settingsHolder.ballSizeModifier;
        changeModifierSlider(ballSizeSlider, ballSizeSlider.value, ballSizeInputField);

        ballSpeedSlider.value = settingsHolder.ballSpeed;
        changeModifierSlider(ballSpeedSlider, ballSpeedSlider.value, ballSpeedInputField);

        playerSpeedSlider.value = settingsHolder.playerSpeed;
        changeModifierSlider(playerSpeedSlider, playerSpeedSlider.value, playerSpeedInputField);

        scoreSlider.value = settingsHolder.scoreLimit;
        changeModifierSlider(scoreSlider, scoreSlider.value, scoreInputField);

        hitFactorSlider.value = settingsHolder.hitFactor;
        changeModifierSlider(hitFactorSlider, hitFactorSlider.value, hitFactorInputField);
    }

    //OnDisable method is used to keep the state of the settings.    
    public void OnDisable()
    {
        //Don't put stuff above this.
        settingsHolder = SettingsHolder.instance;

        settingsHolder.acceleratorOnOff = acceleratorToggle.isOn;
        settingsHolder.ballSizeOnOff = ballSizeToggle.isOn;
    }

    public void Update()
    {
        settingsHolder.acceleratorModifier = acceleratorSlider.value;

        settingsHolder.ballCount = (int)ballCountSlider.value;

        settingsHolder.ballSizeModifier = ballSizeSlider.value;

        settingsHolder.ballSpeed = ballSpeedSlider.value;

        settingsHolder.hitFactor = hitFactorSlider.value;

        settingsHolder.playerSpeed = (int)playerSpeedSlider.value;

        settingsHolder.scoreLimit = (int)scoreSlider.value;
    }

    public void ballCountSettings()
    {
        ballCountSlider.onValueChanged.AddListener(delegate { changeModifierSlider(ballCountSlider, ballCountSlider.value, ballCountInputField); });
        ballCountInputField.onValueChanged.AddListener(delegate { changeModifierInputField(ballCountInputField, ballCountInputField.text, ballCountSlider); });
    }

    public void ballSpeedSettings()
    {
        ballSpeedSlider.onValueChanged.AddListener(delegate { changeModifierSlider(ballSpeedSlider, ballSpeedSlider.value, ballSpeedInputField); });
        ballSpeedInputField.onValueChanged.AddListener(delegate { changeModifierInputField(ballSpeedInputField, ballSpeedInputField.text, ballSpeedSlider); });
    }

    public void hitFactorSettings()
    {
        hitFactorSlider.onValueChanged.AddListener(delegate { changeModifierSlider(hitFactorSlider, hitFactorSlider.value, hitFactorInputField); });
        hitFactorInputField.onValueChanged.AddListener(delegate { changeModifierInputField(hitFactorInputField, hitFactorInputField.text, hitFactorSlider); });
    }

    public void playerSpeedSettings()
    {
        playerSpeedSlider.onValueChanged.AddListener(delegate { changeModifierSlider(playerSpeedSlider, playerSpeedSlider.value, playerSpeedInputField); });
        playerSpeedInputField.onValueChanged.AddListener(delegate { changeModifierInputField(playerSpeedInputField, playerSpeedInputField.text, playerSpeedSlider); });
    }

    public void ScoreLimitSettings()
    {
        scoreSlider.onValueChanged.AddListener(delegate { changeModifierSlider(scoreSlider, scoreSlider.value, scoreInputField); });
        scoreInputField.onValueChanged.AddListener(delegate { changeModifierInputField(scoreInputField, scoreInputField.text, scoreSlider); });
    }

    public void acceleratorMode()
    {
        if (acceleratorToggle.isOn == true)
        {
            settingsHolder.acceleratorOnOff = true;
            acceleratorSlider.interactable = true;
            acceleratorInputField.interactable = true;
        }
        else if (acceleratorToggle.isOn == false)
        {
            settingsHolder.acceleratorOnOff = false;
            acceleratorSlider.interactable = false;
            acceleratorInputField.interactable = false;
        }

        acceleratorSlider.onValueChanged.AddListener(delegate { changeModifierSlider(acceleratorSlider, acceleratorSlider.value, acceleratorInputField); });
        acceleratorInputField.onValueChanged.AddListener(delegate { changeModifierInputField(acceleratorInputField, acceleratorInputField.text, acceleratorSlider); });
    }

    public void BallSizeMode()
    {
        if (ballSizeToggle.isOn == true)
        {
            settingsHolder.ballSizeOnOff = true;
            ballSizeSlider.interactable = true;
            ballSizeInputField.interactable = true;
        }
        else if (ballSizeToggle.isOn == false)
        {
            settingsHolder.ballSizeOnOff = false;
            ballSizeSlider.interactable = false;
            ballSizeInputField.interactable = false;
        }

        ballSizeSlider.onValueChanged.AddListener(delegate { changeModifierSlider(ballSizeSlider, ballSizeSlider.value, ballSizeInputField); });
        ballSizeInputField.onValueChanged.AddListener(delegate { changeModifierInputField(ballSizeInputField, ballSizeInputField.text, ballSizeSlider); });
    }

    //-------------------------------------------------//
    //-------------------------------------------------//

    //These methods allow a slider to change the display of the input field, and vice versa.
    public void changeModifierSlider(Slider slider, float sliderValue, InputField inputField) //Changes the input field value when the slider value is changed.
    {
        inputField.text = sliderValue.ToString();
    }
    public void changeModifierInputField(InputField inputField, string inputValue, Slider slider) //Changes the slider value when the input field value is changed.
    {
        float value;
        if (!float.TryParse(inputValue, out value))
        {
            value = 0.000F;
        }
        slider.value = value;
    }
}
