using Photon.Pun;
using UnityEngine;

public class ObjectModifier : MonoBehaviourPunCallbacks
{
    public void ApplyModifiers(Vector3 randomScaleV3)
    {
        photonView.RPC("ApplyScale", RpcTarget.All, randomScaleV3);
    }

    [PunRPC]
    public void ApplyScale(Vector3 scale)
    {
        transform.localScale = scale;
    }
}