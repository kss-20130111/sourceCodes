using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    //ステート参照用GameManager取得
    private GameObject gameManager;
    private GameManagerStateManager gameManagerStateManager;
    //マップオブジェクト取得
    private GameObject map;
    //マップのスクロールスピード
    [SerializeField] float mapSpeed;

    void Start()
    {
        //GameManager初期化
        gameManager = GameObject.Find("GameManager");
        gameManagerStateManager = gameManager.GetComponent<GameManagerStateManager>();
        //マップオブジェクト初期化
        map = GameObject.Find("MapObject");
    }

    void Update()
    {
        //カウントダウン終了後、マップをスクロールさせる
        if (gameManagerStateManager.state == GameManagerStateManager.State.Playing)
        {
            map.transform.position += transform.right * -mapSpeed * Time.deltaTime;
        }
        //演出のためゴール後はマップのスクロールを止め、プレイヤーだけ右に移動させる
        else if (gameManagerStateManager.state == GameManagerStateManager.State.Clear)
        {
            mapSpeed = 0;
        }
    }
}
