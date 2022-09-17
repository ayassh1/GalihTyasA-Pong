using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleController : MonoBehaviour
{

    public PUPaddleManager manager;
    public Collider2D ball;
    public Collider2D leftpaddle;
    public Collider2D rightpaddle;
    public float magnitude;
    public float spawnDelay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            leftpaddle.GetComponent<PaddleController>().ActivatePUPaddle(magnitude);
            
            rightpaddle.GetComponent<PaddleController>().ActivatePUPaddle(magnitude);
            
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
