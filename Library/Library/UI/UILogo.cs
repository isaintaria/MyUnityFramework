using UnityEngine;

public class UILogo : UIBase
{
    protected override void OpenComplete()
    {
        UIManager.Instance.Open("UIPatch");
    }

    protected override void CloseComplete()
    {
    }
}

