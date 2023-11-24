using System;
using Photon.Pun;
using UnityEngine;

public class ObjectModifier : MonoBehaviourPunCallbacks
{
    public PhotonView photonView;

    public void ApplyModifiers(Color randomColor, Vector3 randomScaleV3)
    {
        photonView.RPC("ApplyColor", RpcTarget.All,
            new Tuple<float, float, float>(randomColor.r, randomColor.g, randomColor.b));
        photonView.RPC("ApplyScale", RpcTarget.All, randomScaleV3);
    }

    [PunRPC]
    public void ApplyScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    [PunRPC]
    public void ApplyColor(Tuple<float, float, float> colorV3)
    {
        Renderer renderer = GetComponent<MeshRenderer>();
        renderer.material.color = new Color(colorV3.Item1, colorV3.Item2, colorV3.Item3);
    }
}