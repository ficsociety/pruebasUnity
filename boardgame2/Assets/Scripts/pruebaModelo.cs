using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;
using UnityEditor;

public class pruebaModelo : MonoBehaviour
{
    public GameObject empty;
    // Use this for initialization
    void Start()
    {
        string url = "file:///C://Users//anieb//Downloads//Unity//dragon";
        StartCoroutine(GetAssetBundle(url));
    }

    IEnumerator GetAssetBundle(String url)
    {
        WWW www = new WWW(url);
        while (!www.isDone)
            yield return null;
        AssetBundle testbundle = www.assetBundle;
        if (testbundle != null)
        {
            GameObject dragon = testbundle.LoadAsset("Dragon_Baked_Actions_fbx_7.4_binary") as GameObject;
            //dragon.AddComponent<Rigidbody>("Animation");
            //dragon.transform.SetParent(empty.transform.parent);
            //dragon.transform.localScale = new Vector3(100.03f, 100.03f, 100.03f);
            //dragon.transform.SetPositionAndRotation(empty.transform.position, empty.transform.rotation);
            GameObject newGameObject = Instantiate(dragon, empty.transform.position, empty.transform.rotation);
            //Instantiate(dragon, empty.transform.position, empty.transform.rotation,empty.transform.parent);
            //dragon.transform.localScale += new Vector3(1, 1, 1);
            newGameObject.transform.SetParent(empty.transform.parent);
            DestroyImmediate(empty);

        }
        else
        {
            Debug.LogError("Asset Bundle is NULL");
        }
    }
}