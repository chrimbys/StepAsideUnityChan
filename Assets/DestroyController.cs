using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{

    //カメラのオブジェクト(課題)
    private GameObject MainCamera;


    // Start is called before the first frame update
    void Start()
    {
        //カメラのオブジェクトを取得(課題)
        this.MainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(MainCamera.transform.position.z > this.transform.position.z)
        {
            Destroy(this.gameObject);

        }
    }
}
