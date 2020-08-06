using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

#pragma warning disable 649

public class PlayerUI_Name : MonoBehaviour
{
    
    [SerializeField] private Vector3 screenOffset = new Vector3(0f, 30f, 0f);

   
    [SerializeField] private Text playerNameText;

    PlayerController target;

    float characterControllerHeight;

    Transform targetTransform;

    Renderer targetRenderer;

    Canvas _canvasGroup;

    Vector3 targetPosition;

    void Awake()
    {
        _canvasGroup = this.GetComponent<Canvas>();
        Debug.Log(PhotonNetwork.NickName);
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }
    }


    public void SetTarget(PlayerController _target)
    {

        if (_target == null)
        {
            Debug.LogError("<Color=Red><b>Missing</b></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
            return;
        }

      
        this.target = _target;
     
        targetRenderer = this.target.GetComponentInChildren<Renderer>();


        CharacterController _characterController = this.target.GetComponent<CharacterController>();

       
        if (_characterController != null)
        {
            characterControllerHeight = _characterController.height;
        }

        if (playerNameText != null)
        {
            playerNameText.text = this.target.photonView.Owner.NickName;
        }
    }

}
