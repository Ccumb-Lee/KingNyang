using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonInit : MonoBehaviourPunCallbacks
{
    public string version = "v1.0";
    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }
    public override void OnConnectedToMaster() //포톤 클라우드에 접속이 잘되면 호출되는 콜백함수
    {
        base.OnConnectedToMaster();
        Debug.Log("Entered Lobby");
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message) //방 입장이 실패했을 때
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("No Room!!");
        PhotonNetwork.CreateRoom("MyRoom", new RoomOptions { MaxPlayers = 2 });

    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Enter Room");
        CreatePlayer();
    }
    void CreatePlayer()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(-12.18f + 10, 8.27f, 28.084f), Quaternion.identity, 0);
    }
}