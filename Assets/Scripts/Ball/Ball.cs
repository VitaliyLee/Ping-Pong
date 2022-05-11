using UnityEngine.Events;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    [SerializeField] private LevelsData levelsData;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [HideInInspector] public UnityEvent ballFailedReflect;

    private Rigidbody2D rigidbody2D;
    private BallMovement ballMovement;

    private LevelSettings ballSettings;
    private Animator effect;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        ballMovement = GetComponent<BallMovement>();

        SelectSettings();

        SetBallParameters();

        BallPooller.Warm(effect, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallFell(collision.CompareTag("DeathZone"));
        collision.GetComponent<Score>().AddScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D hitPoint in collision.contacts)
        {
            BallPooller.SetPosition(hitPoint.point);
        }
    }

    private void SelectSettings()
    {
        ballSettings = levelsData.levelSettingsList[LevelNumber.lastLevelNumber - 1];
    }

    private void BallFell(bool isFell)
    {
        if (isFell)
        {
            ballFailedReflect.Invoke();
            rigidbody2D.velocity = Vector2.zero;
            ballMovement.timeToStart = ballMovement.rememberTime;
        }
    }

    private void SetBallParameters()
    {
        spriteRenderer.sprite = ballSettings.ballSprite;

        ballMovement.SetParameters(ballSettings.boostPercent, ballSettings.startPower);

        effect = ballSettings.hitEffect;
    }
}
