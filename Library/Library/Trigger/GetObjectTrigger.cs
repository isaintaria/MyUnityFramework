using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GetObjectTrigger : TriggerBase
{
    public AudioSource getSoundSource;
    private bool isRooted = false;

    internal override void OnInitialize(params object[] parameters)
    {
        base.OnInitialize(parameters);
    }

    private void OnEnable()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isRooted)
            return;
        Debug.Log("아이템 냠냠냠");
        if (getSoundSource == null)
        {
            Debug.Log( Owner.name + " 오디오 없음 NULL 이에욤");   
        }
        isRooted = true;       
    }

    public void Update()
    {
        if( isRooted )
        {
            isRooted = false;
            getSoundSource.Play();
            GetComponent<MeshRenderer>().enabled = false;         
            StartCoroutine(ItemGet());            
        }
    }

    private IEnumerator ItemGet()
    {                
        while( getSoundSource.isPlaying )
        {
            yield return null;
        }        
        Restore();
    }
}





