using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutAfter : MonoBehaviour
{
    [SerializeField] private float time;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime, transform.localScale.y - Time.deltaTime, transform.localScale.z - Time.deltaTime);
            if (transform.localScale.x <= 0) Destroy(gameObject);
        }
    }
}
