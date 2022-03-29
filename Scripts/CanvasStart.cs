using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class CanvasStart : MonoBehaviour
{
    [SerializeField]
    GameObject RController;

    GameManage gameManager;

    public AudioClip metal_sliding_door_close_01a;
    public AudioClip AISound;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(AISound, transform.position);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManage>(); //シーンの切り替え処理で使用
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            AudioSource.PlayClipAtPoint(metal_sliding_door_close_01a, transform.position);
            gameManager.NextStage();
        }
    }
}
