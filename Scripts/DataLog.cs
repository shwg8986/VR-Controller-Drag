using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement; //現在のsceneの名前を取得する。



public class DataLog : MonoBehaviour
{
    StreamWriter sw;
    //private FileInfo fi;

    //DateTime date;

    //GameObject Object;

    //Listの宣言
    //private List<string> XList = new List<string>();
    //private List<string> YList = new List<string>();
    //private List<string> ZList = new List<string>();


    void Start()
    {
        //Object = this.gameObject.GetComponent<GameObject>();
        // transformを取得
    }

    void Update()
    {
        Transform Object_T = this.transform;

        // ワールド座標を基準に、座標を取得
        Vector3 Object_P = Object_T.position;
        float x = Object_P.x;
        float y = Object_P.y;
        float z = Object_P.z;

        //文字列に変換
        string strX = x.ToString();
        string strY = y.ToString();
        string strZ = z.ToString();

        //Listに文字を追加
        //XList.Add(strX);
        //YList.Add(strY);
        //ZList.Add(strZ);

        string str;
        string fname = "Controller_1.csv";

        string path = Path.Combine(Application.persistentDataPath, fname);


        sw = new StreamWriter(path, false);



        //sw = fi.AppendText();
        //str = SceneManager.GetActiveScene().name + "," + (Object.transform.position.x) + "," + (Object.transform.position.y) + "," + (Object.transform.position.z) + "," + (Time.time);
        str = SceneManager.GetActiveScene().name + "," + strX + "," + strY + "," + strZ + "," ;
        //str = "111";
        sw.WriteLine(str);
        sw.Flush();
        sw.Close();


      
 
        

    }
}