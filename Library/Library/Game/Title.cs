using UnityEngine;

public class Title : GameMain
{
    public void Awake()
    {
        UIBase ui = UIManager.Instance.Open("UIInfo");
    }

    public override void OnFocus()
    {

    }
}