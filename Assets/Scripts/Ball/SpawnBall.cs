using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Transform restartTransform;
    [HideInInspector] public Ball spawnedBall;

    private static SpawnBall instance;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        spawnedBall = Instantiate(ball, transform, false);
        spawnedBall.ballFailedReflect.AddListener(ResetTransform);
    }

    public static SpawnBall GetInstance()
    {
        return instance;
    }

    public void MuteBall()
    {
        spawnedBall.gameObject.SetActive(!spawnedBall.gameObject.active);
    }

    private void ResetTransform()
    {
        spawnedBall.transform.position = new Vector2(restartTransform.position.x,
            restartTransform.position.y);
    }
}
