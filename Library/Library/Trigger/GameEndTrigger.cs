

using UnityEngine;

public class GameEndTrigger : TriggerBase
{
    public AudioSource GetObjectSource;
    private bool isRooted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isRooted)
            return;
        GetObjectSource.Play();
        GameManager.Instance.ChangeScene("qweqwe");
    }

}

