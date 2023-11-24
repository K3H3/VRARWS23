using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.XR;

public class OwnershipTransfer : MonoBehaviourPun, IPunOwnershipCallbacks
{
    private InputDevice targetDevice;

    private void Awake()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDestroy()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    private void Update()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.triggerButton,
                out var triggerValue))
        {
            if (triggerValue)
                photonView.RequestOwnership();
        }
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
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
    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {
        Debug.LogError("Ownership Transfer Failed");
    }
}