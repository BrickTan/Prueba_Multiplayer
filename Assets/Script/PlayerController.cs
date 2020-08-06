using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

#pragma warning disable 649

public class PlayerController : MonoBehaviourPunCallbacks
{
   
    public static GameObject LocalPlayerInstance;

   
    [SerializeField]
    private GameObject playerUiPrefab;



    public void Awake()
    {
        if (photonView.IsMine)
        {
            LocalPlayerInstance = gameObject;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (this.playerUiPrefab != null)
        {
            GameObject _uiGo = Instantiate(this.playerUiPrefab);
            _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
        }
        else
        {
            Debug.LogWarning("<Color=Red><b>Missing</b></Color> PlayerUiPrefab reference on player Prefab.", this);
        }

    }

    void CalledOnLevelWasLoaded(int level)
    {
       
        GameObject _uiGo = Instantiate(this.playerUiPrefab);
        _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
    }


}
