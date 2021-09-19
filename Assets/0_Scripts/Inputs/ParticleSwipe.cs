using UnityEngine;

public class ParticleSwipe : MonoBehaviour
{
    public GameObject particle;

    private void Start()
    {
        SwipeManager.instance.OnStartTouch += StartTouch;
        SwipeManager.instance.OnUpdateTouch += UpdateTouch;
        SwipeManager.instance.OnEndTouch += EndTouch;
    }

    void StartTouch(Vector2 position)
    {
        particle.SetActive(true);
        transform.position = position;
    }

    void UpdateTouch(Vector2 position)
    {
        transform.position = position;
    }

    void EndTouch(Vector2 position)
    {
        particle.SetActive(false);
    }
}
