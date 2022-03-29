﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRay : MonoBehaviour
{

    [SerializeField]
    GameObject RController;


    [SerializeField]
    GameObject Object;

    GameManage gameManager;

    Vector3 hitPosR;
    Vector3 tmpPosR;

    float lazerDistanceR = 5f;
    float lazerStartPointDistanceR = 0.1f;
    float lineWidthR = 0.01f;



    //Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material.color = new Color(0.0f, 0.4f, 0.0f, 0.6f);//ターゲット色の設定
        gameManager = GameObject.Find("GameManager").GetComponent<GameManage>(); //シーンの切り替え処理で使用
    }


    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            gameManager.NextStage();

        }
    }


    //OntriggerStay関数 (ターゲットの中を何かがすり抜けている時に呼び出される関数)
    public void OnTriggerStay(Collider other)
    {
        //右コントローラから発するrayをセットアップするための処理
        Vector3 directionR = RController.transform.forward * lazerDistanceR;
        Vector3 rayStartPositionR = RController.transform.forward * lazerStartPointDistanceR;
        Vector3 posR = RController.transform.position;
        RaycastHit hitR;
        Ray rayR = new Ray(posR + rayStartPositionR, RController.transform.forward);


        if (Physics.Raycast(rayR, out hitR, lazerDistanceR)) {//もしRayが何かの物体にHitしている時
            if ((other.CompareTag("Object")) && (hitR.collider.tag == "Target")) //もしターゲットの中をすり抜けている物体のタグが"Object"の時、かつrayが"Target"にHitしている時
            {
                this.GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 0.0f, 0.3f); //色を薄い緑の透明色に変える=つまりドラッグ完了可能であることをユーザにフィードバック
                                                                                                  
                if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger)) // 右のハンドトリガーを離したら
                {
                    Destroy(other.gameObject); //ドラッグ完了ということでオブジェクトを消去
                    gameManager.NextStage(); //次のシーン(条件)に遷移する
                }
            }
            else
            {
                this.GetComponent<Renderer>().material.color = new Color(0.0f, 0.4f, 0.0f, 0.6f);//ターゲットの色を元に戻す(濃い緑色に変える)
            }
        }
    }

    //OnTriggerExit関数　すり抜け終わった時
    public void OnTriggerExit(Collider other)
    {

        ////右
        //Vector3 directionR = RController.transform.forward * lazerDistanceR;
        //Vector3 rayStartPositionR = RController.transform.forward * lazerStartPointDistanceR;
        //Vector3 posR = RController.transform.position;
        //RaycastHit hitR;
        //Ray rayR = new Ray(posR + rayStartPositionR, RController.transform.forward);


        //CubeButtonがCubeと離れた場合
        if ((other.CompareTag("Object")))
        {
            this.GetComponent<Renderer>().material.color = new Color(0.0f, 0.4f, 0.0f, 0.6f); //元の色に戻す
        }


    }

    //またはrayの衝突が外れたら以下処理

}