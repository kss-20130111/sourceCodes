using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFinish : MonoBehaviour
{
    //ステート取得用GameManager取得
    private GameObject gameManger;
    private GameManagerStateManager gameManagerStateManager;
    //クリア後演出のためのプレイヤーの移動スピード
    [SerializeField] float finishSpeed;

    private void Start()
    {
        //ステート取得用GameManager取得初期化
        gameManger = GameObject.Find("GameManager");
        gameManagerStateManager = gameManger.GetComponent<GameManagerStateManager>();
    }

    void Update()
    {
        ClearMoveFinish();
    }
    void ClearMoveFinish()
    {
        if (gameManagerStateManager.state == GameManagerStateManager.State.Clear)
        {
            //クリアしたらPlayerManagerごと動かす
            transform.position += transform.right * finishSpeed * Time.deltaTime;
        }
    }
}
