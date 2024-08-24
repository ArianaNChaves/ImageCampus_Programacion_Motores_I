using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds * Time.deltaTime);
        //mandar evento
        SelfDestroy();
    }

    public void StartDestroyCoroutine(float seconds)
    {
        StartCoroutine(DestroyAfter(seconds));
    }
}
