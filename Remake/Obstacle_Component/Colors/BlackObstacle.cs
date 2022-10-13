using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackObstacle : ObstacleClass, ICollision
{
    public void CollisionBehavior()
    {
        //黒は失敗のみ
        Failed();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerRed" ||
            other.gameObject.tag == "PlayerBlue"||
            other.gameObject.tag == "PlayerYellow")
        {
            //Player側の衝突時の処理実行
            IMuteki muteki = other.gameObject.GetComponent<IMuteki>();
            muteki.MutekiOn();
        }
    }
}
