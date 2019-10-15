using UnityEngine;

public class EnableObjectOnPress : MonoBehaviour {

    public GameObject objectToEnable;

    private void OnMouseDown()
    {
        if(!objectToEnable.activeSelf)
        {
            objectToEnable.SetActive(true);
        }
    }
}
