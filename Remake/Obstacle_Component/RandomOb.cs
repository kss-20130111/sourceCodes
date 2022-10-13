using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOb : MonoBehaviour
{
    //ランダムの範囲（オブジェクトの種類）
    [SerializeField] int min;
    [SerializeField] int max;
    //ランダム用int
    int randomNum;

    //生成位置(X軸はエディターで設定)
    public int[] pos = new int[] { };
    public GameObject[] randomObstacle = new GameObject[] { };

    void Start()
    {
        //ランダムにオブジェクトを生成
        RandomObSpawn();
    }

    private void RandomObSpawn()
    {
        //Obstacle生成
        //生成位置(Y軸は固定）
        Vector3 Pos = new Vector3(0, 2, 0);
        //指定されたPosの中にランダムで選ばれたObstacleを入れる
        foreach (int num in pos)
        {
            Pos.x = num;

            randomNum = Random.Range(min, max);

            //生成位置・角度の調整
            if (randomObstacle[randomNum].tag == "ObstacleRed" ||
                randomObstacle[randomNum].tag == "ObstacleBlue" ||
                randomObstacle[randomNum].tag == "ObstacleYellow")
            {
                Instantiate(randomObstacle[randomNum], Pos, Quaternion.Euler(0, 0, -90),this.transform);
            }
            else if (randomObstacle[randomNum].tag == "SquatOb")
            {
                Instantiate(randomObstacle[randomNum], new Vector3(Pos.x,Pos.y - 2.2f,Pos.z), Quaternion.identity, this.transform);
            }
            else if(randomObstacle[randomNum].tag == "ColorChangeOb")
            {
                Instantiate(randomObstacle[randomNum], Pos, Quaternion.Euler(0, 0, -90),this.transform);
            }
            else
            {
                Instantiate(randomObstacle[randomNum], Pos, Quaternion.identity, this.transform);
            }
        }
    }
}
