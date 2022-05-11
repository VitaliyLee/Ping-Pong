using UnityEngine;

public class FailedReflect : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Transform restartTransform;

    private void Start()
    {
        ball.ballFailedReflect.AddListener(ResetTransform);
    }

    private void ResetTransform()
    {
        ball.transform.position = new Vector2(restartTransform.position.x, 
            restartTransform.position.y);
    }
}
