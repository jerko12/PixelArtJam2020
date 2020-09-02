using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("destroy");
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
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
}
