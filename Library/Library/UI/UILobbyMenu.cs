using UnityEngine;

public class UILobbyMenu : UIBase
{
    protected override void OpenComplete()
    {
    }

    protected override void CloseComplete()
    {
    }

    public void Dungeon()
    {
        GameManager.Instance.ChangeScene("Dungeon");
    }

    public void Mail()
    {
        Debug.Log("메일버튼누름");
    }

    public void Option()
    {
        Debug.Log("옵션버튼 누름");
    }
}

