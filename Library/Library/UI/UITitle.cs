using UnityEngine;

public class UITitle : UIBase
{
    public GameObject m_nextText;

    private bool m_isOpenComplete = false;

    protected override void OpenComplete()
    {
        m_isOpenComplete = true;
        m_nextText.SetActive(true);

#warning 임시 테이블 로드 (나중에 적합곳으로 옮기기)
        TableManager.Load();
    }

    protected override void CloseComplete()
    {
    }

    public void GoLobby()
    {
        if(false == m_isOpenComplete)
        {
            return;
        }

        GameManager.Instance.ChangeScene("Lobby");
    }
}