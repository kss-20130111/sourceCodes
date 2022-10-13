using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using KanKikuchi.AudioManager;


public class GameManager : MonoBehaviour
{
    //PlayerManager取得
    private GameObject playerManager;
    PlayerHpController playerHpController;
    //ゲームステート用StateManager取得
    GameManagerStateManager gameManagerStateManager;
    //GameStart
    private float gameStartDelay;
    //UI関係
    public int sceneIndex;
    public GameObject pauseMenuUI;
    public GameObject groupUI;
    public GameObject gameOverUI;
    //ボタンのオブジェクト
    public GameObject PauseRetry;
    public GameObject GameOverRetry;
    public GameObject GameClearNext;
    //ボタン
    public Button PauseRetryButton;
    public Button GameOverRetryButton;
    public Button GameClearNextButton;
    //スタート前カウントダウン
    float countDown;
    public GameObject count3ImageUI;
    public GameObject count2ImageUI;
    public GameObject count1ImageUI;
    public GameObject StartImageUI;
    //カウントbool
    public bool isStart;
    public bool isPlaying;
    public bool isStartSound;
    public bool isCountSound;
   
    void Start()
    {
        //PlayerManager初期化
        playerManager = GameObject.Find("PlayerManager");
        playerHpController = playerManager.GetComponent<PlayerHpController>();
        //ゲームスタート時のDelay
        gameStartDelay = 1.0f;
        //UI関係初期化
        Time.timeScale = 1.0f;
        //カウントダウン関係初期化
        countDown = 3.0f;
        isStart = true;
        isPlaying = false;
        isStartSound = false;
        isCountSound = false;
        //ボタンのUI初期化
        PauseRetryButton = PauseRetry.GetComponent<Button>();
        GameOverRetryButton = GameOverRetry.GetComponent<Button>();
        //ゲームステート用StateManager初期化
        gameManagerStateManager = GetComponent<GameManagerStateManager>();
    }
    
    void Update()
    {
        if(gameManagerStateManager.state == GameManagerStateManager.State.GameOver)
        {
            //ゲームオーバーステートに入ったらGameOver呼び出し
            GameOver();
        }
        //開始前のカウントダウン
        if (countDown >= 0)
        {
            if (isStartSound == false)
            {
                //カウントダウンのサウンドの再生
                isStartSound = true;
                SEManager.Instance.Play(SEPath.COUNT_DOWN_SOUND);
            }
            
            //カウントダウンを減らす
            countDown -= Time.deltaTime;
            
            if(countDown > 1 && countDown <= 2)
            {
                //カウント2の時
                count3ImageUI.SetActive(false);
                count2ImageUI.SetActive(true);
                if (isCountSound == false)
                {
                    //カウントダウンのサウンドの再生
                    isCountSound = true;
                    SEManager.Instance.Play(SEPath.COUNT_DOWN_SOUND);
                }
            }

            if(countDown > 0 && countDown <= 1)
            {
                //カウント1の時
                count2ImageUI.SetActive(false);
                count1ImageUI.SetActive(true);
                if (isCountSound == true)
                {
                    //カウントダウンのサウンドの再生
                    isCountSound = false;
                    SEManager.Instance.Play(SEPath.COUNT_DOWN_SOUND);
                }
            }

            if(countDown <= 0)
            {
                //カウント0の時
                count1ImageUI.SetActive(false);
                StartImageUI.SetActive(true);
                if (isStartSound == true)
                {
                    //スタートサウンドの再生
                    isStartSound = false;
                    SEManager.Instance.Play(SEPath.START_SOUND);
                }
                //時間差でBGMを再生
                Invoke("GameStart", 1f);
            }
        }

        //ゲームがプレイ中の時Escキーでポーズ画面へ
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1f &&
            gameManagerStateManager.state == GameManagerStateManager.State.Playing)
        {
            PauseMenuOn();
        }
        //もう一度Escキーでポーズ画面から戻る
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenuUI.activeSelf)
        {
            PauseMenuOff();
        }
    }

    void GameStart()
    {
        //BGMの再生
        BGMManager.Instance.Play(BGMPath.BGM1);
        //スタート演出オフ
        StartImageUI.SetActive(false);
        isStart = false;
        isPlaying = true;
    }
    public void GameOver()
    {
        //HPControllerのisGameOverをfalse
        playerHpController.isGameOver = false;
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
    public void PauseMenuOn()
    {
        //timeScaleを0にする
        Time.timeScale = 0f;
        //サウンドとUIを操作
        SEManager.Instance.Play(SEPath.UI);
        BGMManager.Instance.Pause(BGMPath.BGM1);
        pauseMenuUI.SetActive(true);
        //ボタンの初期選択
        PauseRetryButton.Select();
    }
    public void PauseMenuOff()
    {
        //timeScaleを1にする
        Time.timeScale = 1f;
        //サウンドとUIを操作
        SEManager.Instance.Play(SEPath.UI);
        BGMManager.Instance.UnPause(BGMPath.BGM1);
        pauseMenuUI.SetActive(false);
    }
    public void NextStage()
    {
        //次のステージへ
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneIndex++;
        SceneManager.LoadScene(sceneIndex);
    }
    
    public void RetryStage()
    {
        //同じステージのやり直し
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void TitleStage()
    {
        //タイトルステージ画面へ
        SceneManager.LoadScene("Title");
    }
    public void StageSelect()
    {
        //ステージセレクト画面へ
        SceneManager.LoadScene("StageSelect");
    }
    public void scene1()
    {
        SceneManager.LoadScene("1Stage");
    }
    public void scene2()
    {
        SceneManager.LoadScene("2Stage");
    }
    public void scene3()
    {
        SceneManager.LoadScene("3Stage");
    }
    public void sceneEx4()
    {
        SceneManager.LoadScene("Ex4Stage");
    }
    public void scene5()
    {
        SceneManager.LoadScene("5Stage");
    }
    public void scene6()
    {
        SceneManager.LoadScene("6Stage");
    }
    public void scene7()
    {
        SceneManager.LoadScene("7Stage");
    }
    public void scene8()
    {
        SceneManager.LoadScene("8Stage");
    }
    public void scene9()
    {
        SceneManager.LoadScene("9Stage");
    }
    public void scene10()
    {
        SceneManager.LoadScene("10Stage");
    }
    public void scene11()
    {
        SceneManager.LoadScene("11Stage");
    }
    public void sceneEx12()
    {
        SceneManager.LoadScene("Ex12Stage");
    }
    public void scene13()
    {
        SceneManager.LoadScene("13Stage");
    }
    public void scene14()
    {
        SceneManager.LoadScene("14Stage");
    }
    public void sceneEx15()
    {
        SceneManager.LoadScene("Ex15Stage");
    }
}
