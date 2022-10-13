using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRed : PlayerStatus
{
    [SerializeField] protected GameObject startPos1;
    [SerializeField] public GameObject playerRedBody;
    private GameObject RedUI;

    private void Awake()
    {
        RedUI = GameObject.Find("PlayerRedView");
    }

    public override void InitialPos()
    {
        transform.position = startPos1.transform.position;
        RedUI.SetActive(true);
    }
     
    public override void SetSelect1()
    {
        transform.position = SelectedPos1.transform.position;
        RedUI.SetActive(false);
    }
 
    public override void SetSelect2()
    {
        transform.position = SelectedPos2.transform.position;
        RedUI.SetActive(false);
    }
}
