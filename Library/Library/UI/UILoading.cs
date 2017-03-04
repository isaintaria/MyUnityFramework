using UnityEngine.UI;

public class UILoading : UIBase
{
    public Slider m_silder;

    protected override void OpenComplete()
    {
    }

    protected override void CloseComplete()
    {
    }

    public void Progress(float value)
    {
        m_silder.value = value;
    }
}

