using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;
using UnityEditor;
using Vuforia;

public class pruebaModelo1 : MonoBehaviour, ITrackableEventHandler
{
    public GameObject empty;
    public GameObject newGameObject;
    public TrackableBehaviour mTrackableBehaviour;
    // Use this for initialization
    void Start()
    {
        string url = "file:///C://Users//anieb//Downloads//Unity//dragon";
        StartCoroutine(GetAssetBundle(url));
        //mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    IEnumerator GetAssetBundle(String url)
    {
        var uwr = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return uwr.SendWebRequest();

        // Get an asset from the bundle and instantiate it.
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
        var loadAsset = bundle.LoadAssetAsync<GameObject>("Dragon_Baked_Actions_fbx_7.4_binary");
        yield return loadAsset;

        newGameObject = Instantiate(loadAsset.asset, empty.transform.position, empty.transform.rotation) as GameObject;
        newGameObject.transform.SetParent(empty.transform.parent);
        newGameObject.gameObject.SetActive(false);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
            newGameObject.gameObject.SetActive(true);
        }
    }
}
