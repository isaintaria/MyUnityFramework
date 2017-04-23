
using UnityEngine;

public class FXBase : CachedAsset
{
    internal override void OnInitialize(params object[] parameters)
    {
    }

    protected override void OnUse()
    {      
    }

    float lifetime = 2.0f;
    float elapsed = 0.0f;
    public void Update()
    {
        if (elapsed >= lifetime )
        {
            Destroy(this.gameObject);
        }
        elapsed += Time.deltaTime;
    }

    protected override void OnRestore()
    {        
    }
}
