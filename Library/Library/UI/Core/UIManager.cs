using UnityEngine;
using System.Collections.Generic;

public class UIManager : SingleTon<UIManager>
{
    private List<UIBase>    m_uis = new List<UIBase>();
    private Canvas          m_canvas;

    private UIManager()
    {
        m_canvas = Resources.Load<Canvas>("UICanvas");
        m_canvas = GameObject.Instantiate(m_canvas);
        GameObject.DontDestroyOnLoad(m_canvas);

        GameObject eventSystem = Resources.Load("EventSystem") as GameObject;
        eventSystem = GameObject.Instantiate(eventSystem);
        GameObject.DontDestroyOnLoad(eventSystem);
    }

    public UIBase Open(string uiName, params object[] parameters)
    {
        UIBase result = m_uis.Find(rhs => rhs.name == uiName);

        if (result == null)
        {
            result = AssetManager.Instance.UI.Retrieve(uiName, parameters);
            m_uis.Add(result);

            switch (result.m_uiType)
            {
                case UIType.Contents:
                    result.transform.SetParent(m_canvas.transform.FindChild(UIType.Contents.ToString()), false);
                    break;
                case UIType.Popup:
                    result.transform.SetParent(m_canvas.transform.FindChild(UIType.Popup.ToString()), false);
                    break;
                case UIType.Loading:
                    result.transform.SetParent(m_canvas.transform.FindChild(UIType.Loading.ToString()), false);
                    break;
            }


            return result;
        }

        if (AssetState.Waiting == result.AssetState)
        {
            result = AssetManager.Instance.UI.Retrieve(uiName, parameters);
            result.transform.SetAsLastSibling();
            return result;
        }
        else
        {
            Debug.Log("(UIManager.Open) {0}, 이미 열려있습니다.");
            return result;
        }
    }

    public void Close(string uiName)
    {
        UIBase result = m_uis.Find(rhs => rhs.name == uiName);

        if (null == result)
        {
            Debug.Log(string.Format("(UIManager.Close) 닫으려는 {0}, 존재하지 않습니다.", uiName));
            return;
        }

        result.Restore();
    }

    public void ClearUI()
    {
        m_uis.Clear();
    }
}
