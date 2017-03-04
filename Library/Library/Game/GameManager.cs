using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingleTon<GameManager>
{
    public void ChangeScene(string name)
    {
        // 페이드 인아웃
        // 현재 씬에 존재하는 모든 오브젝트 삭제
        // 가비지콜렉션 호출
        // 로딩UI 띄우기
    }

    private IEnumerator StartChangeScene(string name)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);

        while (asyncOperation.isDone)
        {
            //asyncOperation.progress;
        }

        yield return new WaitForEndOfFrame();
    }


}
