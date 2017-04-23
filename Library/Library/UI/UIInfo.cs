using UnityEngine;
using UnityEngine.UI;

public class UIInfo : UIBase
{
    public InputField input;

    public Toggle toggleHapticOn;
    public Toggle toggleHapticOff;
    public Toggle toggle1st;
    public Toggle toggle3rd;
    public Toggle toggleSceneOn;
    public Toggle toggleSceneOff;
    public Toggle toggleCameraModeVR;
    public Toggle toggleCameraMode;

    public void Start()
    {
        toggleCameraMode.isOn = true;
        toggleHapticOn.isOn = true;
        toggle3rd.isOn = true;
        toggleSceneOff.isOn = true;     
    }

    public void OK()
    {
        EffectManager.Instance.EnabledVulbEffect = toggleHapticOn.isOn;
        IngameManager.Instance.isCamera3rd = !toggle1st.isOn;
        IngameManager.Instance.Moveable = true;
        IngameManager.Instance.isCameraNormalMode = toggleCameraMode.isOn;
        if (!toggleSceneOn.isOn)
            GameManager.Instance.ChangeScene("qweqwe");
        else
            GameManager.Instance.ChangeScene("Scene1");
    }

    protected override void OpenComplete()
    {      
    }
    
    protected override void CloseComplete()
    {
    }

}

