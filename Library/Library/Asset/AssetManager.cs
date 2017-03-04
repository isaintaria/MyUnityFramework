using UnityEngine;
using System.Collections.Generic;

public enum AssetType
{
    UI,
    Image,
    Character,
    Table,
    Trigger,
    FX,
}

public class AssetManager : SingleTon<AssetManager>
{
    private Dictionary<AssetType, AssetFactory> m_assetFactoryList = new Dictionary<AssetType, AssetFactory>();

    private AssetManager()
    {
        m_assetFactoryList[AssetType.UI]        = new GameObjectFactory<UIBase>("ui");
        m_assetFactoryList[AssetType.Image]     = new ArtAssetFactory<Sprite>("image");
        m_assetFactoryList[AssetType.Character] = new GameObjectFactory<CharacterBase>("character");
        m_assetFactoryList[AssetType.Table]     = new ArtAssetFactory<TextAsset>("table");
        m_assetFactoryList[AssetType.Trigger]   = new GameObjectFactory<TriggerBase>("trigger");
        m_assetFactoryList[AssetType.FX]        = new GameObjectFactory<FXBase>("fx");
    }

    public GameObjectFactory<UIBase> UI
    {
        get { return m_assetFactoryList[AssetType.UI] as GameObjectFactory<UIBase>; }
    }

    public GameObjectFactory<CharacterBase> Character
    {
        get { return m_assetFactoryList[AssetType.Character] as GameObjectFactory<CharacterBase>; }
    }

    public GameObjectFactory<TriggerBase> Trigger
    {
        get { return m_assetFactoryList[AssetType.Trigger] as GameObjectFactory<TriggerBase>; }
    }

    public GameObjectFactory<FXBase> FX
    {
        get { return m_assetFactoryList[AssetType.FX] as GameObjectFactory<FXBase>; }
    }

    public ArtAssetFactory<Sprite> Image
    {
        get { return m_assetFactoryList[AssetType.Image] as ArtAssetFactory<Sprite>; }
    }

    public ArtAssetFactory<TextAsset> Table
    {
        get { return m_assetFactoryList[AssetType.Table] as ArtAssetFactory<TextAsset>; }
    }

    public void DestroyAll()
    {
        UI.DestroyAllAsset();
        Image.DestroyAllAsset();
        Character.DestroyAllAsset();
        Trigger.DestroyAllAsset();
        FX.DestroyAllAsset();
    }
}
