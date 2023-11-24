using Photon.Pun;
using UnityEngine;

public class ObjectModifier : MonoBehaviourPunCallbacks
{
    public void ApplyModifiers(Vector3 scale)
    {
        photonView.RPC("ApplyScale", RpcTarget.All, scale);
    }

    [PunRPC]
    public void ApplyScale(Vector3 scale)
    {
        transform.localScale = scale;
    }
}