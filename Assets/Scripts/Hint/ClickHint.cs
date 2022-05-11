using UnityEngine;

public class ClickHint : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) gameObject.SetActive(false);
    }
}
