using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //カメラが追うPlayerManagerを取得
    private GameObject playerManager;
    //ゲームステート用GameManager取得
    private GameObject gameManager;
    private GameManagerStateManager gameManagerStateManager;

    void Start()
    {
        //カメラが追うPlayerManagerを初期化
        playerManager = GameObject.Find("PlayerManager");
        //ゲームステート用GameManager初期化
        gameManager = GameObject.Find("GameManager");
        gameManagerStateManager = gameManager.GetComponent<GameManagerStateManager>();
        //カメラ初期位置
        Vector3 playerManagerPos = playerManager.transform.position;
        transform.position = new Vector3(playerManagerPos.x + 10, playerManagerPos.y + 3, transform.position.z - 5);
    }
    private void Update()
    {
        if (gameManagerStateManager.state == GameManagerStateManager.State.Clear)
        {
            //クリアしたら追いかけるターゲットから外す
            playerManager = null;
        }
    }
    private void LateUpdate()
    {
        if (gameManagerStateManager.state == GameManagerStateManager.State.Start)
        {
            //ゲームがプレイ中の間プレイヤーマネージャーを追い続ける
            Vector3 playerManagerPos = playerManager.transform.position;
            transform.position = new Vector3(playerManagerPos.x + 10, playerManagerPos.y + 3, transform.position.z);
        }
    }
}
