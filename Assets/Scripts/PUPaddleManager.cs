using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpPaddleAmount;
    public int spawnInterval;
    public Vector2 powerUpPaddleAreaMin;
    public Vector2 powerUpPaddleAreaMax;
    public List<GameObject> powerUpPaddleTemplateList;

    private List<GameObject> powerUpPaddleList;
    private float timer;

    private void Start()
    {
        powerUpPaddleList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            GenerateRandomPowerUpPaddle();
            timer -= spawnInterval;
        }
    }


    public void GenerateRandomPowerUpPaddle()
    {
        GenerateRandomPowerUpPaddle(new Vector2
            (Random.Range(powerUpPaddleAreaMin.x, powerUpPaddleAreaMax.x), Random.Range(powerUpPaddleAreaMin.y, powerUpPaddleAreaMax.y))
            );
    }

    public void GenerateRandomPowerUpPaddle(Vector2 position)
    {
        Debug.Log("Test");

        if (powerUpPaddleList.Count >= maxPowerUpPaddleAmount)
        {
            return;
        }

        if (position.x < powerUpPaddleAreaMin.x ||
            position.x > powerUpPaddleAreaMax.x ||
            position.y < powerUpPaddleAreaMin.y ||
            position.y > powerUpPaddleAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpPaddleTemplateList.Count);

        GameObject powerUpPaddle = Instantiate(powerUpPaddleTemplateList[randomIndex],
            new Vector3(position.x, position.y, powerUpPaddleTemplateList[randomIndex].transform.position.z),
            Quaternion.identity, spawnArea);
        powerUpPaddle.SetActive(true);
        powerUpPaddleList.Add(powerUpPaddle);
    }

    public void RemovePowerUpPaddle(GameObject powerUpPaddle)
    {
        powerUpPaddleList.Remove(powerUpPaddle);
        Destroy(powerUpPaddle);
    }

    public void RemoveAllPowerUpPaddle()
    {
        while (powerUpPaddleList.Count > 0)
        {
            RemovePowerUpPaddle(powerUpPaddleList[0]);
        }
    }

}
