using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletTime = 2;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("coroutine");
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    IEnumerator coroutine()
    {

        yield return new WaitForSeconds(bulletTime);
        Destroy(gameObject);
    }
}
