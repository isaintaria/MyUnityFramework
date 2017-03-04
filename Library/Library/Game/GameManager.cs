using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoSingleTon<GameManager>
{
    private UILoading   m_loading;

    public void ChangeScene(string name)
    {
        if (true == string.IsNullOrEmpty(name))
        {
            return;
        }
        
        //화면에 있는거 다 없애버린다 
        AssetManager.Instance.DestroyAll();
        //UI에서 관리하는 레이어들을 클리어해준다.
        UIManager.Instance.ClearUI();

        #region fade
        UIFade ui = UIManager.Instance.Open("UIFade") as UIFade;
        ui.m_openCallBack = () =>
        {
            m_loading = UIManager.Instance.Open("UILoading") as UILoading;
        };
        ui.m_closeCallBack = () =>
        {
            StartCoroutine(StartChangeScene(name));
        };
        #endregion

    }

    private IEnumerator StartChangeScene(string name)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);

        while (false == asyncOperation.isDone)
        {
            m_loading.Progress(asyncOperation.progress);
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
        
        m_loading.Progress(1.0f);

        #region fade
        UIFade ui = UIManager.Instance.Open("UIFade") as UIFade;
        ui.m_openCallBack = () =>
        {
            UIManager.Instance.Close("UILoading");
        };
        ui.m_closeCallBack = () =>
        {
            GameMain gameMain = GameObject.Find(SceneManager.GetActiveScene().name).GetComponent<GameMain>();
            gameMain.OnFocus();
        };
        #endregion
    }
}
