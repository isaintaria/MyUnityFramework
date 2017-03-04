using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public enum UIType
{
    Contents,
    Popup,
    Loading,
}

public abstract class UIBase : CachedAsset
{
    public UIType m_uiType;

    protected abstract void OpenComplete();
    protected abstract void CloseComplete();

    private List<UIElement> m_elementList = new List<UIElement>();

    public void Awake()
    {
        m_elementList.AddRange(transform.GetComponentsInChildren<UIElement>());
    }

    internal override void OnInitialize(params object[] parameters)
    {
    }

    protected override void OnUse()
    {
        gameObject.SetActive(true);
        float openTime = 0.0f;

        for (int i = 0; i < m_elementList.Count; ++i)
        {
            float animationTime = m_elementList[i].OpenAnimation();

            openTime = openTime < animationTime ? animationTime : openTime;
        }

        StartCoroutine(Open(openTime));
    }

    protected override void OnRestore()
    {
        float closeTime = 0.0f;

        for (int i = 0; i < m_elementList.Count; ++i)
        {
            float animationTime = m_elementList[i].CloseAnimation();

            closeTime = closeTime < animationTime ? animationTime : closeTime;
        }

        StartCoroutine(Close(closeTime));
    }

    private IEnumerator Open(float openTime)
    {
        yield return new WaitForSeconds(openTime);
        OpenComplete();
    }

    private IEnumerator Close(float closeTime)
    {
        yield return new WaitForSeconds(closeTime);
        CloseComplete();
        gameObject.SetActive(false);
    }
}

