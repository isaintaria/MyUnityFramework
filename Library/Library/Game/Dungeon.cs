
public class Dungeon : GameMain
{
    public void Awake()
    {
        TableManager.Load();
        LocalData.Load();
        IngameManager.Instance.Init();
        UIManager.Instance.Open("UIDungeon");
    }

    public override void OnFocus()
    {
        
    }
}
