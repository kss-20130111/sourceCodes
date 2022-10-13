using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision:MonoBehaviour,IMuteki
{
    //PlayerManager取得
    [SerializeField] GameObject playerManager;
    PlayerHpController playerHpController;
    //無敵処理用マテリアル・ボディの取得
    [SerializeField] private Material mutekiMaterial;
    [SerializeField] private GameObject playerBody;
    //現在のマテリアル取得
    protected Material initialMaterial;
    //無敵処理用現在のtag取得
    private string nowTag;
    public float MutekiDelay;
    //衝突時のinterface用
    GameObject hit;
    ICollision collision;
    //ダメージフラグ
    public bool isDamage;
    void Awake()
    {
        isDamage = false;
    }
    void Start()
    {
        MutekiDelay = 2.0f;
        //現在のtagで初期化
        nowTag = gameObject.tag;
        //現在のマテリアルで初期化
        initialMaterial = playerBody.GetComponent<Renderer>().sharedMaterial;
        //PlayerManager初期化
        playerHpController = playerManager.GetComponent<PlayerHpController>();
    }
    public void MutekiOn()
    {
        //tagとマテリアルを無敵時のものに変更
        gameObject.tag = "MutekiNow";
        playerBody.GetComponent<Renderer>().sharedMaterial = mutekiMaterial;
        //2秒後に無敵解除
        Invoke("MutekiOff", MutekiDelay);
    }
    public void MutekiOff()
    {
        //tagとマテリアルを変更前に戻す
        gameObject.tag = nowTag;
        playerBody.GetComponent<Renderer>().sharedMaterial = initialMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        //衝突したオブジェクトのICollisionインターフェースを実行
        hit = other.gameObject;
        collision = hit.GetComponent<ICollision>();

        collision.CollisionBehavior();
    }
}
