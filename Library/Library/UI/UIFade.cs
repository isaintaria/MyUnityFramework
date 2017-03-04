using System;
public class UIFade : UIBase
{
    //화면이 다 어두워졌을때 불려지는 콜백
    public Action m_openCallBack;
    //화면이 다시 밝아졌을때 불려지는 콜백
    public Action m_closeCallBack;

    protected override void OpenComplete()
    {
        if (null != m_openCallBack)
        {
            m_openCallBack();
        }
        Restore();
    }

    protected override void CloseComplete()
    {
        if(null != m_closeCallBack)
        {
            m_closeCallBack();
        }

        m_openCallBack = null;
        m_closeCallBack = null;
    }
}
