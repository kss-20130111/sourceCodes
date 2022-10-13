using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlue : PlayerStatus
{
    [SerializeField] protected GameObject startPos2;
    [SerializeField] public GameObject playerBlueBody;
    private GameObject BlueUI;

    private void Awake()
    {
        BlueUI = GameObject.Find("PlayerBlueView");
    }

    public override void InitialPos()
    {
        transform.position = startPos2.transform.position;
        BlueUI.SetActive(true);
    }

    public override void SetSelect1()
    {
        transform.position = SelectedPos1.transform.position;
        BlueUI.SetActive(false);
    }

    public override void SetSelect2()
    {
        transform.position = SelectedPos2.transform.position;
        BlueUI.SetActive(false);
    }
}
