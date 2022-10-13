using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    //rayの長さ
    [SerializeField] float distance;
    //接地をチェックするフラグ
    public bool isGrounded;
    //rayの発生位置用GameObject取得
    [SerializeField] private GameObject playerBody;

    void Update()
    {
        //接地しているかチェック実行
        GroundCheck();
    }

    public void GroundCheck()
    {
        //接地判定を代入
        isGrounded = CheckGrounded();
    }

    //接地判定
    public bool CheckGrounded()
    {
        //Groundレイヤーを返す
        int layermask = 1 << 9;
        //rayの初期位置と向き
        var ray = new Ray(new Vector3(playerBody.transform.position.x, playerBody.transform.position.y, playerBody.transform.position.z), Vector3.down);

        return Physics.Raycast(ray, distance, layermask);
    }
}
