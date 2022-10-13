using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStatus : MonoBehaviour
{
    //キャラ選択時のposition用GameObject取得
    [SerializeField] protected GameObject SelectedPos1;
    [SerializeField] protected GameObject SelectedPos2;

    //各色プレイヤー用の抽象メソッド
    public abstract void InitialPos();

    public abstract void SetSelect1();

    public abstract void SetSelect2();
}
