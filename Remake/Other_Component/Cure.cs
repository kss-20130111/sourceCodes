using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class Cure : MonoBehaviour,ICollision
{
    //PlayerManager取得
    PlayerHpController playerHpController;
    void Start()
    {
        //PlayerManager初期化
        playerHpController = GameObject.Find("PlayerManager").GetComponent<PlayerHpController>();
    }
    public void CollisionBehavior()
    {
        //体力を増加処理呼び出し
        playerHpController.HpIncrease();
        //回復サウンドの再生
        SEManager.Instance.Play(SEPath.KAIFUKU);
        //Cureオブジェクトを消す
        Destroy(this.gameObject);
    }
}
