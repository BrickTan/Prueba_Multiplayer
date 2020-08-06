using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

#pragma warning disable 649

public class GameController : MonoBehaviourPunCallbacks
{

    static public GameController Instance;
    private GameObject instance;

    [SerializeField] private GameObject playerPrefab;


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(507.4481f, 5.269f, -1930.56f), Quaternion.identity, 0);
    }

    public void LeaveRoom()
    {
        Application.Quit();
    }

}
