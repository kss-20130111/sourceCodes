using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KanKikuchi.AudioManager;

public class GameFinishArea : MonoBehaviour, ICollision
{
    //UIオブジェクト
    [SerializeField] GameObject completeUI;
    [SerializeField] GameObject gameClearUI;
    //ステート操作用bool
    public bool isGameFinish;
    public void CollisionBehavior()
    {
        //GameFinishステートへ
        isGameFinish = true;
        //クリア時のUIの表示
        completeUI.SetActive(false);
        gameClearUI.SetActive(true);
        //GameClearSoundの再生
        SEManager.Instance.Play(SEPath.GAME_CLEAR_SOUND);
    }
}
