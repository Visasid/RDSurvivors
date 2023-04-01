using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterT : MonoBehaviour
{
    [SerializeField] private float afterT;
    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= afterT) Destroy(gameObject);
    }
}
