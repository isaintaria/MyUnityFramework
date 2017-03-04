
public class UIPatch : UIBase
{
    
    protected override void OpenComplete()
    {
        ArchiveLoader loader = new ArchiveLoader();
        loader.Initialize(() =>
        {
            loader.DownloadStart = SetFileName;
            loader.LoadAssetBundles(SetProgress, CloseSelf);
        });
    }

    protected override void CloseComplete()
    {
        UIManager.Instance.Open("UITitle");
    }

    private void SetProgress(float value)
    {
        UnityEngine.Debug.Log(value + "% 다운로드함");
    }

    private void SetFileName(string name)
    {
        UnityEngine.Debug.Log(name + " 다운로드 시작함");
    }

    private void CloseSelf()
    {
        UIManager.Instance.Close("UIPatch");
    }
}