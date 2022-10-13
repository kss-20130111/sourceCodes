using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KanKikuchi.AudioManager;

public class GameOverArea : MonoBehaviour,ICollision
{
    //UIオブジェクト
    [SerializeField] GameObject groupUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] Button GameOverRetryButton;
    public void CollisionBehavior()
    {
        //ゲームをストップさせる
        Time.timeScale = 0f;
        //各UI表示・非表示
        groupUI.SetActive(false);
        gameOverUI.SetActive(true);
        //BGMストップ・ゲームオーバーサウンド再生
        BGMManager.Instance.Stop(BGMPath.BGM1);
        SEManager.Instance.Play(SEPath.GAME_OVER_SOUND);
        //ボタンの初期選択
        GameOverRetryButton.Select();
    }
}
