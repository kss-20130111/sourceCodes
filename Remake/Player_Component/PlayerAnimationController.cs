using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    //プレイヤーのステート取得用PlayerManager取得
    GameObject playerManager;
    //このオブジェクト自身の設置判定を取得
    CheckGround checkGround;
    //ゲームのステート取得用GameManager取得
    GameObject gameManager;
    GameManagerStateManager gameManagerStateManager;
    //このオブジェクト自身のアニメーター取得
    private Animator animator;
    string currentStateName;
    //プレイヤーのアニメーション状態管理フラグ
    public bool isLift;

    private void Start()
    {
        isLift = false;
        //プレイヤーのステート取得用PlayerManager初期化
        playerManager = GameObject.Find("PlayerManager");
        //ゲームのステート取得用GameManager初期化
        gameManager = GameObject.Find("GameManager");
        gameManagerStateManager = gameManager.GetComponent<GameManagerStateManager>();
        //設置判定用CheckGround初期化
        checkGround = this.GetComponent<CheckGround>();
        //アニメーター初期化
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        //Runアニメーション呼び出し
        RunAnim();
        //接地していて、Liftアニメーションが実行されていないとき
        if (checkGround.isGrounded &&
            !isLift)
        {
            //Slide・Jump呼び出し
            Slide();
            Jump();
        }
        if (gameManagerStateManager.state == GameManagerStateManager.State.Clear)
        {
            SlideAniStop();
            LiftAniStop();
            //クリア時にCompleteアニメーション実行
            Complete();
        }
    }
    public void RunAnim()
    {
        //ゲームステートがPlayingの時に再生
        //Clearステートでも再生を続ける
        if (gameManagerStateManager.state == GameManagerStateManager.State.Playing)
        {
            animator.SetBool("isRun", true);
        }
    }

    public void Slide()
    {
        //ステートがPlayingの時だけ再生
        if (gameManagerStateManager.state != GameManagerStateManager.State.Start &&
            gameManagerStateManager.state != GameManagerStateManager.State.Clear)
        {
            //接地時にCtrlキーが押されたら
            if(Input.GetKeyDown(KeyCode.LeftControl) ||
               Input.GetKeyDown(KeyCode.RightControl))
            {
                //スライディングアニメーション再生
                animator.SetBool("isSlide", true);
                animator.SetTrigger("Slide");
            }
        }
    }
    public void SlideAniStop()
    {
        //スライディング終了時のアニメーション遷移
        animator.SetBool("isSlide", false);
    }
    public void Jump()
    {
        //ステートがPlayingの時だけ再生
        if (gameManagerStateManager.state != GameManagerStateManager.State.Start &&
            gameManagerStateManager.state != GameManagerStateManager.State.Clear)
        {
            //Spaceキーでジャンプ
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //Jumpアニメーション再生
                animator.SetBool("isJumpNow", true);
                //Slideアニメーションが再生されていたら止める
                SlideAniStop();
            }
        }
    }
    public void jumpEnd()
    {
       //Jumpアニメーション停止
       animator.SetBool("isJumpNow", false);
    }

    //持ちあげるアニメーション再生
    public void Lift()
    {
       isLift = true;
       //Slideアニメーションが再生されていたら止める
       SlideAniStop();
       //Liftアニメーション再生
       animator.SetBool("isLift", true);
    }
    public void LiftAniStop()
    {
        isLift = false;
        //Liftアニメーション停止
        animator.SetBool("isLift", false);
    }

    public void Complete()
    {
        //Completeアニメーション再生
        animator.SetBool("isCompleteBool",true);
    }
}
