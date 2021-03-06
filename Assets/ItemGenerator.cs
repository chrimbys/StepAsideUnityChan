using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    public GameObject CarPrefab;

    public GameObject CoinPrefab;

    public GameObject ConePrefab;

    private int startPos = 80;

    private int firstPos = 125;

    private int goalPos = 345;

    private float posRange = 3.4f;

    GameObject Unitychan;

    List<GameObject> list = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        //unityちゃんのオブジェクトを取得
        this.Unitychan = GameObject.Find("unitychan");


        //45先までアイテムを生成
        for (int i = startPos; i < firstPos; i += 15)
        {

            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(ConePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                    list.Add(cone);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(CoinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        list.Add(coin);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(CarPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        list.Add(car);

                    }

                }
            }


        }





    }

    



    // Update is called once per frame
    void Update()
    {

        GameObject obj = list[list.Count - 1];

        if (obj.transform.position.z < goalPos)
        {

            if (obj.transform.position.z - Unitychan.transform.position.z < 45)
            {


                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(ConePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, obj.transform.position.z + 15);
                        list.Add(cone);
                    }
                }
                else
                {
                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置:30%車配置:10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(CoinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, (obj.transform.position.z + 15 + offsetZ));
                            list.Add(coin);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(CarPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, (obj.transform.position.z + 15 + offsetZ));
                            list.Add(car);

                        }

                    }
                }




            }

        }
    }
}