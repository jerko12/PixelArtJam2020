using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("destroy");
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(this);
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position -= transform.right * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameManager.game.scene.LoadMainMenu();
        }
        if (collision.transform.CompareTag("PlayerBullet"))
        {
            health--;
        }
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
}
