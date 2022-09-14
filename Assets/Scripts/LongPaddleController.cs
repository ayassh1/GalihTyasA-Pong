using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongPaddleController : MonoBehaviour
{
    public LongPaddleManager manager;
    public Collider2D ball;
    public Collider2D paddle;
    public float magnitude;
    public float spawnDelay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            paddle.GetComponent<PaddleController>().ActivateLP(magnitude);
            Destroy(this.gameObject);
            spawnDelay = 0;
        }

    }

   private void Update()
    {
        if (spawnDelay > 0)
        {
            spawnDelay -= Time.deltaTime;
        }
        else
        {
            manager.RemoveLP(gameObject);
        }
    }
}
