using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIselect : MonoBehaviour
{
    public Button stageSelect;
    // Start is called before the first frame update
    void Start()
    {
        //ボタンの初期選択
        stageSelect.Select();
    }
}
