using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class OwnershipTransfer : MonoBehaviourPun, IPunOwnershipCallbacks
{
    private void Awake()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDestroy()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        Debug.Log("Transferring Ownership...");

        if (targetView != photonView)
        {
            return;
        }

       
        photonView.TransferOwnership(requestingPlayer);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        if (targetView != photonView)
        {
            return;
        }
        Debug.Log("Ownership Transfered Successfully");
    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {
        Debug.LogError("Ownership Transfer Failed");
    }
}