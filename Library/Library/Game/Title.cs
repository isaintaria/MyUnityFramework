using UnityEngine;

public class Title : GameMain
{
    public void Awake()
    {
        LocalData.Load();

        LocalData.Instance.Nickname = "현우";
        LocalData.Instance.Level = 1;
        LocalData.Instance.Gold = 10000;
        LocalData.Save();
        UIManager.Instance.Open("UILogo");
        
    }

    public override void OnFocus()
    {

    }
}