using UnityEngine;

public class PCQuitInput : MonoBehaviour {

    public bool UsingPC;

	// Use this for initialization
	void Start ()
    {
        if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
        {
            UsingPC = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!UsingPC)
            return;
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
	}
}
