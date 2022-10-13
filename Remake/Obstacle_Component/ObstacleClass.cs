using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class ObstacleClass : MonoBehaviour
{
    GameObject playerManager;
    PlayerHpController playerHpController;
    //各パーティクル取得
    [SerializeField] GameObject collectParticle;
    [SerializeField] GameObject missedParticle;
    //パーティクル発生位置取得
    protected GameObject parent_Map;
    protected Transform parent_Map_transform;
    //当たったプレイヤーの色を判別する
    public bool colRed;
    public bool colBlue;
    public bool colYellow;
    public bool colMuteki;

    private void Start()
    {
        playerManager = GameObject.Find("PlayerManager");
        playerHpController = playerManager.GetComponent<PlayerHpController>();
        //パーティクル発生位置用の親オブジェクト初期化
        parent_Map = GameObject.Find("MapObject");
        parent_Map_transform = parent_Map.transform;
    }

    public void Collect()
    {
        //成功時のサウンドを再生
        SEManager.Instance.Play(SEPath.COLLECT_SOUND);
        //Obstacleの位置でパーティクルを再生
        Instantiate(collectParticle, transform.position + Vector3.down, Quaternion.identity,parent_Map_transform);
        //正解したらObstacleを消す
        Destroy(gameObject);
    }

    public void Failed()
    {
        playerHpController.HpDecrease();   
        //サウンドの再生
        SEManager.Instance.Play(SEPath.FAILED_SOUND);
        //Obstacleの位置でパーティクルを再生
        Instantiate(missedParticle, transform.position + Vector3.down, Quaternion.identity, parent_Map_transform);
    }
    public void MutekiSound()
    {
        //サウンドの再生
        SEManager.Instance.Play(SEPath.MUTEKI_SOUND);
    }
}
