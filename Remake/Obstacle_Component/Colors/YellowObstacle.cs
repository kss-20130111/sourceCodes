using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowObstacle : ObstacleClass,ICollision//,ICanHpDecrease
{
    //Playerと衝突時に呼び出される
    public void CollisionBehavior()
    {
        //音とパーティクルの再生
        if (colMuteki)
        {
            //無敵
            MutekiSound();
        }
        else if  (colYellow)
        {
            //正解時
            Collect();
        }
        else if (!colYellow)
        {
            //失敗時
            Failed();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerYellow")
        {
            //黄同士は正解
            colYellow = true;
        }
        else if (other.gameObject.tag == "PlayerRed" ||
                other.gameObject.tag == "PlayerBlue")
        {
            //違う色は失敗
            colYellow = false;
            //Player側の衝突時の処理実行
            IMuteki muteki = other.gameObject.GetComponent<IMuteki>();
            muteki.MutekiOn();
        }
        else if (other.gameObject.tag == "MutekiNow")
        {
            //無敵状態のPlayerと衝突したとき
            colMuteki = true;
        }
    }
}
