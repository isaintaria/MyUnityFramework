
public class UIOption : UIBase
{
    public void CloseSelf()
    {
        UIManager.Instance.Close("UIOption");
    }

    protected override void CloseComplete()
    {
    }

    protected override void OpenComplete()
    {
    }
}