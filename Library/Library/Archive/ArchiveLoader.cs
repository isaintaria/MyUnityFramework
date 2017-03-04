using UnityEngine;
using System.Collections;

public delegate void DownloadStart(string fileName);
public delegate void DownloadProgress(float progress);

public class ArchiveLoader
{
    public DownloadStart DownloadStart;

    private AssetBundleManifest m_manifest;

    private static string m_downloadUrl = "http://dfvrcenter.iptime.org:1204/Android/";

    public void Initialize(System.Action action = null)
    {
        Init(action);
    }

    public void LoadAssetBundles(DownloadProgress progress, System.Action action = null)
    {
        Load(progress, action);
    }

    //메니페스트파일 하나를 받는과정 
    private IEnumerator Init(System.Action action)
    {
        while (false == Caching.ready)
        {
            yield return null;
        }

        WWW www = new WWW(string.Format("{0}{1}", m_downloadUrl, "AssetBundles"));

        while (false == www.isDone)
        {
            
            //진행상황 체크
            yield return null;
        }

        if (false == string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("에셋번들 다운로드중 문제가 발생하였습니다." + www.error);
            www.Dispose();
            www = null;
            yield break;
        }

        m_manifest = www.assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

        www.Dispose();
        www = null;

        if (null != action)
        {
            action();
        }
    }

    //실질적인 에셋번들 파일들을 받는과정
    private IEnumerator Load(DownloadProgress progress, System.Action action)
    {
        while (false == Caching.ready)
        {
            yield return null;
        }

        string[] assetNames = m_manifest.GetAllAssetBundles();

        for(int i = 0; i < assetNames.Length; ++i)
        {
            WWW www = WWW.LoadFromCacheOrDownload(string.Format("{0}{1}", m_downloadUrl, assetNames[i]), m_manifest.GetAssetBundleHash(assetNames[i]));
            DownloadStart(assetNames[i]);

            while (false == www.isDone)
            {
                //진행상황 체크
                if (null != progress)
                {
                    progress(www.progress);
                }
                yield return null;
            }

            progress(1.0f);

            if (false == string.IsNullOrEmpty(www.error))
            {
                Debug.LogError("에셋번들 다운로드중 문제가 발생하였습니다." + www.error);
                www.Dispose();
                www = null;
                yield break;
            }

            AssetArchive.Instance.Add(assetNames[i], www.assetBundle);

            www.Dispose();
            www = null;

            yield return new WaitForSeconds(0.5f);
        }

        if (null != action)
        {
            action();
        }
    }
}

