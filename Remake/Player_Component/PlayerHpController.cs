using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpController : MonoBehaviour
{
    //プレイヤーのHP（全色で共通の体力を持つ）
    public int HP;
    //ゲームステートに渡す用bool
    public bool isGameOver;
    //HPUI取得
    private GameObject life1, life2, life3, life4, life5;

    private void Awake()
    {
        //ゲームステートに渡す用bool初期化
        isGameOver = false;
        //HPUI初期化
        life1 = GameObject.Find("Life1");
        life2 = GameObject.Find("Life2");
        life3 = GameObject.Find("Life3");
        life4 = GameObject.Find("Life4");
        life5 = GameObject.Find("Life5");
        //HP初期化
        HP = 5;
    }

    public void HpDecrease()
    {
        //HP減少時の処理
        if (HP > 0)
        {
            //体力を1減らす
            HP -= 1;
            //体力UI操作用メソッド呼び出し
            LifeControl();
            if (HP == 0)
            {
                //体力0でゲームオーバー
                isGameOver = true;
            }
        }
    }

    public void HpIncrease()
    {
        //体力を回復した時の処理
        if (HP < 5)
        {
            //体力を1プラス
            HP += 1;
            //体力UI操作用メソッド呼び出し
            LifeControl();
        }
    }

    public void LifeControl()
    {
        if (HP == 5)
        {
            //HP増加時参照
            life5.SetActive(true);
        }
        else if (HP == 4)
        {
            //HP減少時参照
            life5.SetActive(false);
            //HP増加時参照
            life4.SetActive(true);
        }
        else if (HP == 3)
        {
            //HP減少時参照
            life4.SetActive(false);
            //HP増加時参照
            life3.SetActive(true);
        }
        else if (HP == 2)
        {
            //HP減少時参照
            life3.SetActive(false);
            //HP増加時参照
            life2.SetActive(true);
        }
        else if (HP == 1)
        {
            //HP減少時参照
            life2.SetActive(false);
            //HP増加時参照
            life1.SetActive(true);
        }
        else if (HP == 0)
        {
            //HP減少時参照
            life1.SetActive(false);
        }
    }
}
