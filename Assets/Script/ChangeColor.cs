using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ChangeColor : MonoBehaviour
{
    public Material[] skinSoccerBall;
    Renderer rendSkin;


    public void Start()
    {
        RefreshSkin();
    }

    [PunRPC]
    public void RefreshSkin()
    {
        PlayerPrefs.SetInt("WichSkin", WichSkin);
        rendSkin = GetComponent<Renderer>();
        rendSkin.enabled = true;
        rendSkin.sharedMaterial = skinSoccerBall[WichSkin];
    }

    public static int WichSkin
    {
        get
        {
            return PlayerPrefs.GetInt("WichSkin"); // ToLoad
        }
        set
        {
            PlayerPrefs.SetInt("WichSkin", value); //ToSave
        }

    }


 
    public void IndexSkins(int ID)
    {
        WichSkin = ID;
        

        if (ID == 0)
        {
            RefreshSkin();
        }
        else if (ID == 1)
        {
            RefreshSkin();
        }
        else if (ID == 2)
        {
            RefreshSkin();
        }

        PlayerPrefs.SetInt("Wichlevel", WichSkin);

    }
}
