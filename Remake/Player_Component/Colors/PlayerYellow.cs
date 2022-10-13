using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYellow : PlayerStatus
{
    [SerializeField] protected GameObject startPos3;
    [SerializeField] public GameObject playerYellowBody;
    private GameObject YellowUI;

    private void Awake()
    {
        YellowUI = GameObject.Find("PlayerYellowView");
    }

    public override void InitialPos()
    {
        transform.position = startPos3.transform.position;
        YellowUI.SetActive(true);
    }

    public override void SetSelect1()
    {
        transform.position = SelectedPos1.transform.position;
        YellowUI.SetActive(false);
    }

    public override void SetSelect2()
    {
        transform.position = SelectedPos2.transform.position;
        YellowUI.SetActive(false);
    }
}
