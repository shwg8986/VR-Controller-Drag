using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Rayhit : MonoBehaviour
{
    [SerializeField]
    GameObject RController;
    [SerializeField]
    GameObject LController;

    [SerializeField]
    GameObject NowController;

    [SerializeField]
    GameObject Object;

    Color ObjectColor;

    LineRenderer lineRenderer;

    Vector3 hitPosR;
    Vector3 tmpPosR;

    Vector3 hitPosL;
    Vector3 tmpPosL;

    Vector3 hitPos;
    Vector3 tmpPos;

    public AudioClip SoundGet;
    public AudioClip SoundRelease;

    float lazerDistanceR = 5f;
    float lazerStartPointDistanceR = 0.1f;
    float lineWidthR = 0.01f;

    float lazerDistanceL = 5f;
    float lazerStartPointDistanceL = 0.1f;
    float lineWidthL = 0.01f;

    float lazerDistance = 5f;
    float lazerStartPointDistance = 0.1f;
    float lineWidth = 0.01f;


    bool isFirst = true; // 最初の一回を判定するフラグ

    //Vector3 def;//回転
    Vector3 defParentF;
    Vector3 defObject;


    void Awake()
    {
        defObject = Object.transform.localRotation.eulerAngles;
    }


    void Reset()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;

    }

    void Start()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;

        ObjectColor = Object.GetComponent<Renderer>().material.color;//最初のオブジェクトの色を取得

        //def = Object.transform.localRotation.eulerAngles;//回転

    }


    void Update()
    {

        OnRay();

        //Vector3 _parent = Object.transform.parent.transform.localRotation.eulerAngles;
        //修正箇所
        //Object.transform.localRotation = Quaternion.Euler(defObject - _parent);
        //Object.transform.localRotation = Quaternion.Euler(0, 0, 0);
        Object.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void OnRay()
    {

        //汎用
        Vector3 direction = NowController.transform.forward * lazerDistance;
        Vector3 rayStartPosition = NowController.transform.forward * lazerStartPointDistance;
        Vector3 pos = NowController.transform.position;
        RaycastHit hit;
        Ray ray = new Ray(pos + rayStartPosition, NowController.transform.forward);

        lineRenderer.SetPosition(0, pos + rayStartPosition);



        if (Physics.Raycast(ray, out hit, lazerDistance))
        {
            hitPos = hit.point;
            lineRenderer.SetPosition(1, hitPos);
        }
        else
        {
            lineRenderer.SetPosition(1, pos + direction);

        }

        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.1f);




        //オブジェクトの色変更

        //オブジェクト判定に使う用途
        //右
        Vector3 directionR = RController.transform.forward * lazerDistanceR;
        Vector3 rayStartPositionR = RController.transform.forward * lazerStartPointDistanceR;
        Vector3 posR = RController.transform.position;
        RaycastHit hitR;
        Ray rayR = new Ray(posR + rayStartPositionR, RController.transform.forward);


        //左
        Vector3 directionL = LController.transform.forward * lazerDistanceL;
        Vector3 rayStartPositionL = LController.transform.forward * lazerStartPointDistanceL;
        Vector3 posL = LController.transform.position;
        RaycastHit hitL;
        Ray rayL = new Ray(posL + rayStartPositionL, LController.transform.forward);


        //Rayがオブジェクトに衝突した時の処理
        if (Physics.Raycast(rayR, out hitR, lazerDistanceR) || Physics.Raycast(ray, out hit, lazerDistance))
        {
            if ((hitR.collider.tag == "Object")|| (hit.collider.tag == "Object"))
            {
                Object.GetComponent<Renderer>().material.color = new Color(0.2f, 0.2f, 1.0f, 1.0f); //オブジェクト色を変える   
            }
        }

        else
        {
            Object.GetComponent<Renderer>().material.color = ObjectColor; //オブジェクト色を戻す
        }


        //またはrayの衝突が外れたら以下処理


        //Nowコントローラー

        //レイに当たった物体をつかむ処理　
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) || OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(NowController.transform.position, NowController.transform.forward, 4.0f);
            foreach (var ahit in hits)
            {
                if (ahit.collider.tag == "Object")
                {
                    ahit.collider.transform.parent = NowController.transform;

                    AudioSource.PlayClipAtPoint(SoundGet, transform.position); //サウンド
                    //Object.GetComponent<Renderer>().material.color = new Color(0.1f, 0.6f, 0.75f, 1.0f); //オブジェクトの色を水色に変える
                }
            }
        }

        //色を変える用
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(NowController.transform.position, NowController.transform.forward, 4.0f);
            foreach (var ahit in hits)
            {
                if (ahit.collider.tag == "Object")
                {
                    Object.GetComponent<Renderer>().material.color = new Color(0.1f, 0.6f, 0.75f, 1.0f); //オブジェクトの色を水色に変える
                }
            }
        }

            //物体を離す処理
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger)|| OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        {

            for (int i = 0; i < NowController.transform.childCount; i++)
            {
                var child = NowController.transform.GetChild(i);
                if (child.tag == "Object")
                {
                    child.parent = null;
                    AudioSource.PlayClipAtPoint(SoundRelease, transform.position);//サウンド
                }
            }
        }

    }


}