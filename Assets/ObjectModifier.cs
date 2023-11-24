using System;
using Photon.Pun;
using UnityEngine;

public class ObjectModifier : MonoBehaviourPunCallbacks
{
    public PhotonView photonView;

    public void ApplyModifiers(Color randomColor, Vector3 randomScaleV3)
    {
        photonView.RPC("ApplyColor", RpcTarget.All, randomColor);
        photonView.RPC("ApplyScale", RpcTarget.All, randomScaleV3);
    }

    [PunRPC]
    public void ApplyScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    [PunRPC]
    public void ApplyColor(Color randomColor)
    {
        Renderer renderer = GetComponent<MeshRenderer>();
        renderer.material.color = randomColor;
    }
}