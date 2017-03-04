using UnityEngine;
using System.Collections.Generic;

public class InputManager : MonoSingleTon<InputManager>
{
    private List<CommonInput> m_inputList = new List<CommonInput>();

    private InputManager()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                m_inputList.Add(new ScreenInput());
                break;
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
                m_inputList.Add(new MouseInput());
                m_inputList.Add(new KeyboardInput());
                break;
        }
    }

    public void SetHooker(Hooker func)
    {
        m_inputList.ForEach(rhs => rhs.InputHooker += func);
    }

    public void ClearHooker(Hooker func)
    {
        m_inputList.ForEach(rhs => rhs.InputHooker = null);
    }

    public void Update ()
    {
        m_inputList.ForEach(rhs => rhs.InputUpdate());
	}
}
