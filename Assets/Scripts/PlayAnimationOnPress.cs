using UnityEngine;

public class PlayAnimationOnPress : MonoBehaviour {

    public Animation animation;

    private void OnMouseDown()
    {
        animation.Stop();
        animation.Play("Spin", PlayMode.StopSameLayer);   
    }
}
