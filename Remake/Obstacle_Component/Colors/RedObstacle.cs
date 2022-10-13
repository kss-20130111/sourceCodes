using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedObstacle : ObstacleClass,ICollision
{
    //Playerと衝突時に呼び出される
    public void CollisionBehavior()
    {
        //音とパーティクルの再生
        if(colMuteki)
        {
            //無敵
            MutekiSound();
        }
        else if (colRed)
        {
            //正解時
            Collect();
        }
        else if (!colRed)
        {
            //失敗時
            Failed();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerRed")
        {
            //赤同士は正解
            colRed = true;
        }
        else if (other.gameObject.tag == "PlayerBlue" ||
                other.gameObject.tag == "PlayerYellow")
        {
            //違う色は失敗
            colRed = false;
            //Player側の衝突時の処理実行
            IMuteki muteki = other.gameObject.GetComponent<IMuteki>();
            muteki.MutekiOn();
        }
        else if(other.gameObject.tag == "MutekiNow")
        {
            //無敵状態のPlayerと衝突したとき
            colMuteki = true;
        }
    }
}
