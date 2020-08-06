using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun; 

[RequireComponent(typeof(InputField))]

public class PlayerName_Save : MonoBehaviour
{
   
    const string playerNamePrefKey = "PlayerName";

    string defaultName = string.Empty;
    

    void Start()
    {

        InputField _inputField = this.GetComponent<InputField>();

        if (_inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }


        PhotonNetwork.NickName = defaultName;
    }

    public void SetPlayerName(string value)
    {
        Debug.Log(PhotonNetwork.NickName);
        
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player Name is null or empty");
            return;
        }
        PhotonNetwork.NickName = value;

        PlayerPrefs.SetString(playerNamePrefKey, value);
    }

   
}

