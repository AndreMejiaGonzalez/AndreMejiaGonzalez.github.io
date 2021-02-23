using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMove : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private Transform center;
    private MeshRenderer[] meshes;

    [Range(0.0f, 10.0f), SerializeField]
    private float tweenDuration;
    [SerializeField]
    private Ease easeType = Ease.Linear;
    [SerializeField]
    private float tweenTriggerDist;
    [SerializeField]
    private bool isFirst;

    private float distFromPlayer;

    void Start()
    {
        if(isFirst)
        {
            meshes = this.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer mesh in meshes)
            {
                foreach(Material mat in mesh.materials)
                {
                    mat.DOFade(1, 1);
                }
            }
        }
    }

    void Update()
    {
        distFromPlayer = (Vector3.Distance(new Vector3(center.position.x, 0, center.position.z),
        new Vector3(playerPos.position.x, 0, playerPos.position.z)));
        tweenMotion();
    }

    void tweenMotion()
    {
        if(distFromPlayer <= tweenTriggerDist)
        {
            if(!DOTween.IsTweening(this.transform) && this.transform.position.y != -100)
            {
                this.transform.DOMoveY(-100, tweenDuration).SetEase(easeType);
                meshes = this.GetComponentsInChildren<MeshRenderer>();
                Debug.Log(meshes.Length);
                foreach(MeshRenderer mesh in meshes)
                {
                    foreach(Material mat in mesh.materials)
                    {
                        mat.DOFade(1, tweenDuration * 2);
                    }
                }
            }
        } else {
            if(!DOTween.IsTweening(this.transform) && this.transform.position.y != 1000)
            {
                meshes = this.GetComponentsInChildren<MeshRenderer>();
                foreach(MeshRenderer mesh in meshes)
                {
                    foreach(Material mat in mesh.materials)
                    {
                        mat.DOFade(0, tweenDuration * 2);
                    }
                }
                this.transform.DOMoveY(300, tweenDuration).SetEase(easeType);
            }
        }
    }
}