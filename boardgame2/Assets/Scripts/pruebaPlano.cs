using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pruebaPlano : MonoBehaviour
{
    public GameObject ThePlane;

    string url = "file:///C://Users//anieb//Pictures//Fondos//egypt_pyramids.jpg";
    void Start()
    {
        StartCoroutine(loadSpriteImageFromUrl(url));
    }

    IEnumerator loadSpriteImageFromUrl(string URL)
    {

        WWW www = new WWW(URL);
        while (!www.isDone)
        {
            Debug.Log("Download image on progress" + www.progress);
            yield return null;
        }

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Download failed");
        }
        else
        {
            Debug.Log("Download succes");
            Texture2D texture = new Texture2D(1, 1);
            www.LoadImageIntoTexture(texture);

            ThePlane.GetComponent<Renderer>().material.SetTexture("_MainTex", texture);
        }
    }
}
