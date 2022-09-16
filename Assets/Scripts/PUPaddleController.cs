using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleController : MonoBehaviour
{
    
    public PUPaddleManager manager;
    public Collider2D ball;
    public float magnitude;
    public float spawnDelay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
            manager.RemovePowerUpPaddle(gameObject);
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
            manager.RemovePowerUpPaddle(gameObject);
        }
    }



}
