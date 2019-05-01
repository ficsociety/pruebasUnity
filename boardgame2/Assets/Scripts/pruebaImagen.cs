using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PruebaImagen : MonoBehaviour
{
    public Image imageToDisplay;
    string url = "https://i.imgur.com/fprCDiN.jpg";

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

            Sprite sprite = Sprite.Create(texture,
                new Rect(0, 0, texture.width, texture.height), Vector2.zero);

            imageToDisplay.sprite = sprite;
        }
    }
}