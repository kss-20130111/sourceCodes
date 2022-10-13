using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KanKikuchi.AudioManager;

public class GameClearArea : MonoBehaviour, ICollision
{
    //UI操作用GameManager取得
    GameObject gameManager;
    GameManager gameManagerScript;
    //UIオブジェクト
    [SerializeField] GameObject groupUI;
    [SerializeField] GameObject completeUI;
    //ステート操作用bool
    public bool isPlayingEnd;
    public bool isGameClear;
    void Start()
    {
        //UI操作用GameManager初期化
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }
    public void CollisionBehavior()
    {
        //Clearステートへ
        isPlayingEnd = true;
        isGameClear = true;
        //ゴールラインに到達したら呼び出し
        //各UI表示・非表示
        groupUI.SetActive(false);
        completeUI.SetActive(true);
        //BGMを止めフィニッシュサウンドを再生
        SEManager.Instance.Play(SEPath.FINISH_SOUND);
        BGMManager.Instance.Stop(BGMPath.BGM1);
    }
}
