using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour,ICollision
{
    //ランダム用int
    private int number;
    //一つ上の親を取得する
    GameObject parentGameObject;
    //ランダムInstance用各色Obstacle
    [SerializeField] GameObject redObstacle;
    [SerializeField] GameObject blueObstacle;
    [SerializeField] GameObject yellowObstacle;

    void Start()
    {
        number = Random.Range(1, 4);
        //Instantiate生成場所用・親オブジェクトの初期化
        parentGameObject = transform.root.gameObject;
    }

    public void CollisionBehavior()
    {
        if (number == 1)
        {
            //1　の場合親オブジェクトの位置に赤Obstacleを生成
            Instantiate(redObstacle, new Vector3(transform.position.x, transform.position.y + 0.45f, transform.position.z),
                Quaternion.Euler(0, 0, -90), parentGameObject.transform);
        }
        else if (number == 2)
        {
            //2の場合親オブジェクトの位置に青Obstacleを生成
            Instantiate(blueObstacle, new Vector3(transform.position.x, transform.position.y + 0.45f, transform.position.z),
                Quaternion.Euler(0,0,-90), parentGameObject.transform);
        }
        else if (number == 3)
        {
            //3の場合親オブジェクトの位置に黄Obstacleを生成
            Instantiate(yellowObstacle, new Vector3(transform.position.x, transform.position.y + 0.45f, transform.position.z),
                Quaternion.Euler(0, 0, -90), parentGameObject.transform);
        }
    }
}
