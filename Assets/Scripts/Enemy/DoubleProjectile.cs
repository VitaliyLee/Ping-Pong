using UnityEngine;

public class DoubleProjectile : MonoBehaviour
{
    [SerializeField] private GameObject cloneBall;
    [SerializeField] private float abilityCoolDown;
    private float rememberCoolDown;
    private int counter;

    private void Start()
    {
        rememberCoolDown = abilityCoolDown;
    }

    private void Update()
    {
        abilityCoolDown -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (abilityCoolDown <= 0 && collision.gameObject.CompareTag("Ball"))
        {
            foreach (ContactPoint2D hitPoint in collision.contacts)
            {
                GameObject _ball = Instantiate(cloneBall, hitPoint.point, Quaternion.identity);
                Debug.Log(_ball.name);
                abilityCoolDown = rememberCoolDown;
            }
        }
            
    }
}
