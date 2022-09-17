using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePaddleController : MonoBehaviour
{
    public ScalePaddleManager manager;
    public Collider2D ball;
    public Collider2D leftpaddle;
    public Collider2D rightpaddle;
    public float magnitude;
    public float spawnDelay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            leftpaddle.GetComponent<PaddleController>().ActivateScalePaddle(magnitude);

            rightpaddle.GetComponent<PaddleController>().ActivateScalePaddle(magnitude);
            manager.RemoveScalePaddle(gameObject);
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
            manager.RemoveScalePaddle(gameObject);
        }
    }
}
