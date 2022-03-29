using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    GameObject leftController;

    [SerializeField]
    GameObject rightController;

    GameManage gameManager;

    //Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(0.8f, 0.7f, 0.1f, 0.5f);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManage>();

    }

    // Update is called once per frame
    //void Update()
    //{
    //    if ()
    //    {
    //        GetComponent<Renderer>().material.color = transparent2.color;
    //    }
    //}


    //OntriggerStay関数 すり抜けている時
    public void OnTriggerStay(Collider other)
    {

        //CubeButtonがCubeと衝突している場合
        //if (collision.gameObject.name == "Cube")
        //{

        GetComponent<Renderer>().material.color = new Color(0.0f,0.0f, 0.8f, 0.5f);

        //}

        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
        {
            //当たったオブジェクトを消す
            Destroy(other.gameObject);
            gameManager.NextStage();
        }
    }

    //OnTriggerExit関数　すり抜け終わっと滝
    public void OnTriggerExit(Collider other)
    {

        //CubeButtonがCubeと離れた場合
        //if (collision.gameObject.name == "Cube")
        //{

        GetComponent<Renderer>().material.color = new Color(0.8f, 0.7f, 0.1f, 0.5f);

        //}
    }
}
