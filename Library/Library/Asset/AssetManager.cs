using UnityEngine;
using System.Collections.Generic;

public enum AssetType
{
    UI,
    Image,
    Character,
}

public class AssetManager : SingleTon<AssetManager>
{
    private Dictionary<AssetType, AssetFactory> m_assetFactoryList = new Dictionary<AssetType, AssetFactory>();

    private AssetManager()
    {
        m_assetFactoryList[AssetType.UI]        = new GameObjectFactory<UIBase>("ui");
        m_assetFactoryList[AssetType.Image]     = new ArtAssetFactory<Sprite>("image");
        m_assetFactoryList[AssetType.Character] = new GameObjectFactory<CharacterBase>("character");
    }

    public GameObjectFactory<UIBase> UI
    {
        get { return m_assetFactoryList[AssetType.UI] as GameObjectFactory<UIBase>; }
    }

    public GameObjectFactory<CharacterBase> Character
    {
        get { return m_assetFactoryList[AssetType.Character] as GameObjectFactory<CharacterBase>; }
    }

    public ArtAssetFactory<Sprite> Image
    {
        get { return m_assetFactoryList[AssetType.Image] as ArtAssetFactory<Sprite>; }
    }
}
