using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //各色ステート
    public enum Colors
    {
        Red,
        Blue,
        Yellow,
        Muteki
    }
    //ステート用enum
    public Colors colors;
    //ゲームステート用GameManager取得
    private GameObject gameManager;
    GameManagerStateManager gameManagerStateManager;
    //各色プレイヤー取得
    GameObject playerRed;
    GameObject playerBlue;
    GameObject playerYellow;
    //各色プレイヤースクリプト取得
    PlayerRed playerRedScript;
    PlayerBlue playerBlueScript;
    PlayerYellow playerYellowScript;
    //各色プレイヤーのPlayerAnimationController取得
    PlayerAnimationController PAC_Red;
    PlayerAnimationController PAC_Blue;
    PlayerAnimationController PAC_Yellow;
    //PlayerCollision用オブジェクト取得
    [SerializeField] GameObject playerRedBody;
    [SerializeField] GameObject playerBlueBody;
    [SerializeField] GameObject playerYellowBody;
    //各色プレイヤーのPlayerCollision取得
    PlayerCollision redCollision;
    PlayerCollision blueCollision;
    PlayerCollision yellowCollision;
    //各色プレイヤーのCheckGround取得
    CheckGround redCheckGround;
    CheckGround blueCheckGround;
    CheckGround yellowCheckGround;

    //このオブジェクトのPlayerDataManagerを取得
    //PlayerDataManager playerDataManager;
    //キーチェック用bool
    bool keyQ;
    bool keyW;
    bool keyE;
    bool keyQUp;
    bool keyWUp;
    bool keyEUp;   
 
    void Start()
    {
        //キーチェック用bool初期化
        keyQ = true;
        keyW = false;
        keyE = false;
        keyQUp = false;
        keyWUp = false;
        keyEUp = false;
        //各色ステート用enum初期化
        colors = Colors.Red;
        //ゲームステート用GameManager初期化
        gameManager = GameObject.Find("GameManager");
        gameManagerStateManager = gameManager.GetComponent<GameManagerStateManager>();
        //各色プレイヤー初期化
        playerRed = GameObject.Find("PlayerRed");
        playerBlue = GameObject.Find("PlayerBlue");
        playerYellow = GameObject.Find("PlayerYellow");
        //各色プレイヤースクリプト初期化
        playerRedScript = playerRed.GetComponent<PlayerRed>();
        playerBlueScript = playerBlue.GetComponent<PlayerBlue>();
        playerYellowScript = playerYellow.GetComponent<PlayerYellow>();
        //各色プレイヤーのPlayerAnimationController初期化
        PAC_Red = playerRed.GetComponent<PlayerAnimationController>();
        PAC_Blue = playerBlue.GetComponent<PlayerAnimationController>();
        PAC_Yellow = playerYellow.GetComponent<PlayerAnimationController>();
        //各色プレイヤーのPlayerCollision初期化
        redCollision = playerRedBody.GetComponent<PlayerCollision>();
        blueCollision = playerBlueBody.GetComponent<PlayerCollision>();
        yellowCollision = playerYellowBody.GetComponent<PlayerCollision>();
        //各色プレイヤーのCheckGround初期化
        redCheckGround = playerRed.GetComponent<CheckGround>();
        blueCheckGround = playerBlue.GetComponent<CheckGround>();
        yellowCheckGround = playerYellow.GetComponent<CheckGround>();

        //初期位置の設定(RedだけSetSelect（前に出しておく))
        playerRedScript.SetSelect1();
        playerBlueScript.InitialPos();
        playerYellowScript.InitialPos();
    }

    // Update is called once per frame
    void Update()
    {
        //キーチェック呼び出し
        KeyCheck_Down();
        KeyCheck_Up();
        //現在のColorステート判定
        NowColor();

        switch (colors)
        {
            case Colors.Red:
                {
                    //色切り替え時のpositionの設定
                    playerRedScript.SetSelect1();
                    playerBlueScript.InitialPos();
                    playerYellowScript.InitialPos();
                    //他の色のLiftアニメーションを止める
                    LiftAnimStop();
                    //色切り替えをしたら無敵をオフにする
                    MutekiStop();
                    //赤のLift処理を実行
                    RedLift();
                }
                break;
            case Colors.Blue:
                {
                    //色切り替え時のpositionの設定
                    playerRedScript.InitialPos();
                    playerBlueScript.SetSelect1();
                    playerYellowScript.InitialPos();
                    //他の色のLiftアニメーションを止める
                    LiftAnimStop();
                    //色切り替えをしたら無敵をオフにする
                    MutekiStop();
                    //赤のLift処理を実行
                    BlueLift();
                }
                break;
            case Colors.Yellow:
                {
                    //色切り替え時のpositionの設定
                    playerRedScript.InitialPos();
                    playerBlueScript.InitialPos();
                    playerYellowScript.SetSelect1();
                    //他の色のLiftアニメーションを止める
                    LiftAnimStop();
                    //色切り替えをしたら無敵をオフにする
                    MutekiStop();
                    //赤のLift処理を実行
                    YellowLift();
                }
                break;
        }
    }
    void RedLift()
    {
        if (gameManagerStateManager.state != GameManagerStateManager.State.Start &&
            gameManagerStateManager.state != GameManagerStateManager.State.Clear)
        {
            if (keyQ && keyW && !keyE)
            {
                //その他のアニメーションを止める
                SlideAnimStop();
                //赤が青を持ち上げる
                PAC_Red.Lift();
                playerBlueScript.SetSelect2();
            }
            else if (keyWUp)
            {
                //キーを離したら赤のLiftアニメーションを止める
                PAC_Red.LiftAniStop();
            }
            if (keyQ && keyE )//&& !keyW)
            {
                //その他のアニメーションを止める
                SlideAnimStop();
                //赤が黄を持ち上げる
                PAC_Red.Lift();
                playerYellowScript.SetSelect2();
            }
            else if (keyEUp)
            {
                //キーを離したら赤のLiftアニメーションを止める
                PAC_Red.LiftAniStop();
            }
        }
    }
    void BlueLift()
    {
        if (gameManagerStateManager.state != GameManagerStateManager.State.Start &&
            gameManagerStateManager.state != GameManagerStateManager.State.Clear)
        {
            if (keyW && keyQ && !keyE)
            {
                //その他のアニメーションを止める
                SlideAnimStop();
                //青が赤を持ち上げる
                PAC_Blue.Lift();
                playerRedScript.SetSelect2();
            }
            else if (keyQUp)
            {
                //キーを離したら青のLiftアニメーションを止める
                PAC_Blue.LiftAniStop();
            }
            if (keyW && keyE )//&& !keyQ)
            {
                //その他のアニメーションを止める
                SlideAnimStop();
                //青が黄を持ち上げる
                PAC_Blue.Lift();
                playerYellowScript.SetSelect2();
            }
            else if (keyEUp)
            {
                //キーを離したら青のLiftアニメーションを止める
                PAC_Blue.LiftAniStop();
            }
        }
    }
    void YellowLift()
    {
        if (gameManagerStateManager.state != GameManagerStateManager.State.Start &&
            gameManagerStateManager.state != GameManagerStateManager.State.Clear)
        {
            if (keyE && keyQ && !keyW)
            {
                //その他のアニメーションを止める
                SlideAnimStop();
                //黄が赤を持ち上げる
                PAC_Yellow.Lift();
                playerRedScript.SetSelect2();
            }
            else if (keyQUp)
            {
                //キーを離したら黄のLiftアニメーションを止める
                PAC_Yellow.LiftAniStop();
            }
            if (keyE && keyW)// && !keyQ)
            {
                //その他のアニメーションを止める
                SlideAnimStop();
                //黄が青を持ち上げる
                PAC_Yellow.Lift();
                playerBlueScript.SetSelect2();
            }
            else if (keyWUp)
            {
                //キーを離したら黄のLiftアニメーションを止める
                PAC_Yellow.LiftAniStop();
            }
        }
    }
    void KeyCheck_Down()
    {
        //Q・W・Eのキー入力をチェック
        keyQ = Input.GetKey(KeyCode.Q);
        keyW = Input.GetKey(KeyCode.W);
        keyE = Input.GetKey(KeyCode.E);
    }
    void KeyCheck_Up()
    {
        //Q・W・Eのキーアップをチェック
        keyQUp = Input.GetKeyUp(KeyCode.Q);
        keyWUp = Input.GetKeyUp(KeyCode.W);
        keyEUp = Input.GetKeyUp(KeyCode.E);
    }

    void NowColor()
    {
        //Colorステート切り替え
        if (gameManagerStateManager.state != GameManagerStateManager.State.Start &&
            gameManagerStateManager.state != GameManagerStateManager.State.Clear)
        {
            if (redCheckGround || blueCheckGround || yellowCheckGround)
            {
                if (keyQ && !keyW && !keyE)
                {
                    //Qキーで赤へ
                    colors = Colors.Red;
                }
                else if (!keyQ && keyW && !keyE)
                {
                    //Wキーで青へ
                    colors = Colors.Blue;
                }
                else if (!keyQ && !keyW && keyE)
                {
                    //Eキーで黄へ
                    colors = Colors.Yellow;
                }
            }
        }
    }
    void SlideAnimStop()
    {
        //Slideアニメーションを止める
        PAC_Red.SlideAniStop();
        PAC_Blue.SlideAniStop();
        PAC_Yellow.SlideAniStop();
    }
    void MutekiStop()
    {
        if(colors == Colors.Red)
        {
            //赤以外の無敵を消す
            blueCollision.MutekiOff();
            yellowCollision.MutekiOff();
        }
        if(colors == Colors.Blue)
        {
            //青以外の無敵を消す
            redCollision.MutekiOff();
            yellowCollision.MutekiOff();
        }
        if(colors == Colors.Yellow)
        {
            //黄以外の無敵を消す
            redCollision.MutekiOff();
            blueCollision.MutekiOff();
        }
    }
    void LiftAnimStop()
    {
        if(colors == Colors.Red)
        {
            //赤以外のLiftアニメーションを止める
            PAC_Blue.LiftAniStop();
            PAC_Yellow.LiftAniStop();
        }
        if (colors == Colors.Blue)
        {
            //青以外のLiftアニメーションを止める
            PAC_Red.LiftAniStop();
            PAC_Yellow.LiftAniStop();
        }
        if (colors == Colors.Yellow)
        {
            //黄以外のLiftアニメーションを止める
            PAC_Red.LiftAniStop();
            PAC_Blue.LiftAniStop();
        }
    }
}
