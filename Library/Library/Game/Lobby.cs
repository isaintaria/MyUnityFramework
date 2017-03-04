
public class Lobby : GameMain
{
    public void Awake()
    {
        UIBase ui = UIManager.Instance.Open("UILobbyMenu");
    }

    public override void OnFocus()
    {
        
    }
}

