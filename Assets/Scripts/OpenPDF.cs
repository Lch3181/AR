using System.IO;
using UnityEngine;

public class OpenPDF : MonoBehaviour {

    public string fileName;

    private void OnMouseDown()
    {
        switch(Application.platform)
        {
            case RuntimePlatform.IPhonePlayer:
                //Still havent tested for the platform
                Application.OpenURL("file:///" + Application.streamingAssetsPath + "/" + fileName);
                break;

            case RuntimePlatform.Android:
                //Fails to open for some reason
                Application.OpenURL("file:///" + Application.streamingAssetsPath + "/" + fileName);
                break;

            case RuntimePlatform.WindowsPlayer:
                //Does nothing at all
                Application.OpenURL("file:///" + Application.streamingAssetsPath + "/" + fileName);
                break;

            default:
                //Only works during playmode
                Application.OpenURL("file:///"+ Application.streamingAssetsPath + "/"+ fileName);
                break;
        }
    }
}
