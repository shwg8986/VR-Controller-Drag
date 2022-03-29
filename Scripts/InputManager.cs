using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField]
    GameObject rightController;
    [SerializeField]
    GameObject leftController;
    [SerializeField]
    LineRenderer RightRayObject;
    [SerializeField]
    LineRenderer LeftRayObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //物体をつかむ処理 右
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            RaycastHit[] hits;
            hits = Physics.SphereCastAll(rightController.transform.position, 0.01f, Vector3.forward);
            foreach (var hit in hits)
            {
                if (hit.collider.tag == "Cube")
                {
                    hit.collider.transform.parent = rightController.transform;
                    break;
                }
            }
        }
        　
        //物体を離す処理　右
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
        {
            for (int i = 0; i < rightController.transform.childCount; i++)
            {
                var child = rightController.transform.GetChild(i);
                if (child.tag == "Cube")
                {
                    child.parent = null;
                }
            }
        }

        //物体をつかむ処理　左
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            RaycastHit[] hits;
            hits = Physics.SphereCastAll(leftController.transform.position, 0.01f, Vector3.forward);
            foreach (var hit in hits)
            {
                if (hit.collider.tag == "Cube")
                {
                    hit.collider.transform.parent = leftController.transform;
                    break;
                }
            }
        }

        //物体を離す処理　左
        if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        {
            for (int i = 0; i < leftController.transform.childCount; i++)
            {
                var child = leftController.transform.GetChild(i);
                if (child.tag == "Cube")
                {
                    child.parent = null;
                }
            }
        }


        //レイを出す処理　右
        RightRayObject.SetVertexCount(2); //頂点数を2個に設定（始点と終点 右）
        RightRayObject.SetPosition(0, rightController.transform.position); // 0番目の頂点を右手コントローラの位置に設定
        RightRayObject.SetPosition(1, rightController.transform.position + rightController.transform.forward * 1.0f); // 1番目の頂点を右手コントローラの位置から1m先に設定

        //レイを出す処理  左
        LeftRayObject.SetVertexCount(2); //頂点数を2個に設定（始点と終点 右）
        LeftRayObject.SetPosition(0, leftController.transform.position); // 2番目の頂点を左手コントローラの位置に設定
        LeftRayObject.SetPosition(1, leftController.transform.position + leftController.transform.forward * 1.0f); // 3番目の頂点を左手コントローラの位置から1m先に設定


        //rayObject.SetWidth(0.01f, 0.01f); //線の太さを0.01mに設定
        //rayObject.SetWidth(0.01f, 0.01f); //線の太さを0.01mに設定




        //右コントローラー

        //レイに当たった物体をつかむ処理　
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(rightController.transform.position, rightController.transform.forward, 1.0f);
            foreach (var hit in hits)
            {
                if (hit.collider.tag == "Cube")
                {
                    hit.collider.transform.parent = rightController.transform;
                    break;
                }
            }
        }

        //物体を離す処理
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger) || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            for (int i = 0; i < rightController.transform.childCount; i++)
            {
                var child = rightController.transform.GetChild(i);
                if (child.tag == "Cube")
                {
                    child.parent = null;
                }
            }
        }


        //左コントローラー

        //レイに当たった物体をつかむ処理
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger) || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(leftController.transform.position, leftController.transform.forward, 1.0f);
            foreach (var hit in hits)
            {
                if (hit.collider.tag == "Cube")
                {
                    hit.collider.transform.parent = leftController.transform;
                    break;
                }
            }
        }

        //物体を離す処理　左
        if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger) || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            for (int i = 0; i < leftController.transform.childCount; i++)
            {
                var child = leftController.transform.GetChild(i);
                if (child.tag == "Cube")
                {
                    child.parent = null;
                }
            }
        }

    }


}
