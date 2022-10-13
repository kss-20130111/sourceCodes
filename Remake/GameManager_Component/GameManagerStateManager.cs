using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerStateManager : MonoBehaviour
{
    //ゲームステート
    public enum State 
    {
        Start,
        Playing,
        Clear,
        GameOver,
        Finish
    }
    //ステート
    public State state;
    //PlayerManager取得
    private GameObject playerManager;
    private PlayerHpController _playerHpController;
    //GameManager取得
    private GameManager _gameManager;
    //GameClearArea取得
    private GameObject gameClearArea;
    private GameClearArea _gameClearArea;
    //GameFinishArea取得
    private GameObject gameFinishArea;
    private GameFinishArea _gameFinishArea;
    //状態代入用bool
    public bool isStart;
    public bool isPlaying;
    public bool isPlayingEnd;
    public bool isGameClear;
    public bool isGameOver;
    public bool isGameFinish;

    private void Start()
    {
        //PlayerManager初期化
        playerManager = GameObject.Find("PlayerManager");
        _playerHpController = playerManager.GetComponent<PlayerHpController>();
        //GameManager初期化
        _gameManager = this.GetComponent<GameManager>();
        //GameClearArea初期化
        gameClearArea = GameObject.Find("GoalAreaCollider");
        _gameClearArea = gameClearArea.GetComponent<GameClearArea>();
        //GameFinishArea初期化
        gameFinishArea = GameObject.Find("GameFinishCollider");
        _gameFinishArea = gameFinishArea.GetComponent<GameFinishArea>();
        //ステートをStartにする
        state = State.Start;
    }

    private void Update()
    {
        //ステートチェック
        StateCheck();
        //ステートを変更
        StateSet();
    }

    void StateCheck()
    {
        //各オブジェクトから状態を代入
        isStart = _gameManager.isStart;
        isPlaying = _gameManager.isPlaying;
        isPlayingEnd = _gameClearArea.isPlayingEnd;
        isGameClear = _gameClearArea.isGameClear;
        isGameOver = _playerHpController.isGameOver;
        isGameFinish = _gameFinishArea.isGameFinish;
    }
    void StateSet()
    {
        //状態ごとにステートを変化させる
        if(isStart)
        {
            state = State.Start;
        }
        if(isPlaying)
        {
            state = State.Playing;
        }
        if(isPlayingEnd && isGameClear)
        {
            state = State.Clear;
        }
        if(isGameOver)
        {
            state = State.GameOver;
        }
        if(isGameFinish)
        {
            state = State.Finish;
        }
    }
}
