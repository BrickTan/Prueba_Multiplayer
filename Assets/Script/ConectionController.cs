using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649

public class ConectionController : MonoBehaviourPunCallbacks
{

  
    [SerializeField] private Text feedbackText;
    [SerializeField] private GameObject controlPanel;
    [SerializeField] private byte maxPlayersPerRoom = 15;
    [SerializeField] private byte minPlayersPerRoom = 1;
    [SerializeField] private GameObject loaderAnime;

    string gameVersion = "1";


    bool isConnecting;


    

     public void ConnectToServer()
     {
         if (JoinGame.canJoin)
         {
             isConnecting = true;

             controlPanel.SetActive(false);

             if (loaderAnime != null)
             {
                 loaderAnime.SetActive(true);
             }

             if (PhotonNetwork.IsConnected)
             {
                feedbackText.text = "Joining Room...";
                
                 PhotonNetwork.JoinRandomRoom();
             }
             else
             {

                feedbackText.text = "Connecting...";

                 PhotonNetwork.ConnectUsingSettings();
                 PhotonNetwork.GameVersion = this.gameVersion;
             }
         }
         else
         {
            feedbackText.text = "Selecciona un color"; 
         }
         // we want to make sure the log is clear everytime we connect, we might have several failed attempted if connection failed.
         feedbackText.text = "";

         // keep track of the will to join a room, because when we come back from the game we will get a callback that we are connected, so we need to know what to do then

     }

     public override void OnConnected()
     {
         base.OnConnected();
     }

     public override void OnConnectedToMaster()
     {
        
         if (isConnecting)
         {
            feedbackText.text = "Connecting...";
             PhotonNetwork.JoinRandomRoom();
         }
     }

     public override void OnJoinRandomFailed(short returnCode, string message)
     {
        feedbackText.text = "<Color=Red>OnJoinRandomFailed</Color>: Creating a new Room";
         
         PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayersPerRoom });
     }

     public override void OnDisconnected(DisconnectCause cause)
     {
        feedbackText.text = "<Color=Red>OnDisconnected</Color> " + cause;
        
         loaderAnime.SetActive(false);

         isConnecting = false;
         controlPanel.SetActive(true);
     }

     public override void OnJoinedRoom()
     {
        feedbackText.text = "<Color=Green>OnJoinedRoom</Color> with " + PhotonNetwork.CurrentRoom.PlayerCount + " Player(s)";
        PhotonNetwork.LoadLevel("SampleScene");
         
     }


}
