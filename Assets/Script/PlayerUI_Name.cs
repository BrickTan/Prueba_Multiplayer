using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

#pragma warning disable 649

public class PlayerUI_Name : Photon.Pun.MonoBehaviourPun
{
    
    [SerializeField] private Vector3 screenOffset = new Vector3(0f, 30f, 0f);

   
    [SerializeField] private Text playerNameText;

    PlayerController target;

    float characterControllerHeight;

    Transform targetTransform;

    Renderer targetRenderer;

    Canvas _canvasGroup;

    Vector3 targetPosition;


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
