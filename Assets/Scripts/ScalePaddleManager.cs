using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePaddleManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxScalePaddleAmount;
    public int spawnInterval;
    public Vector2 scalePaddleAreaMin;
    public Vector2 scalePaddleAreaMax;
    public List<GameObject> scalePaddleTemplateList;

    private List<GameObject> scalePaddleList;
    private float timer;

    private void Start()
    {
        scalePaddleList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnInterval)
        {
            GenerateRandomScalePaddle();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomScalePaddle()
    {
        GenerateRandomScalePaddle(new Vector2(Random.Range(scalePaddleAreaMin.x, scalePaddleAreaMax.x),
            Random.Range(scalePaddleAreaMin.y, scalePaddleAreaMax.y)));
    }

    public void GenerateRandomScalePaddle(Vector2 position)
    {
        if(scalePaddleList.Count >= maxScalePaddleAmount)
        {
            return;
        }
        
        if (position.x < scalePaddleAreaMin.x ||
            position.x > scalePaddleAreaMax.x ||
            position.y < scalePaddleAreaMin.y ||
            position.y > scalePaddleAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, scalePaddleTemplateList.Count);

        GameObject scalePaddle = Instantiate(scalePaddleTemplateList[randomIndex],
            new Vector3(position.x, position.y, scalePaddleTemplateList[randomIndex].transform.position.z),
            Quaternion.identity, spawnArea);
        scalePaddle.SetActive(true);

        scalePaddleList.Add(scalePaddle);
    }

    public void RemoveScalePaddle(GameObject scalePaddle)
    {
        scalePaddleList.Remove(scalePaddle);
        Destroy(scalePaddle);
    }

    public void RemoveAllScalePaddle()
    {
        while(scalePaddleList.Count > 0)
        {
            RemoveScalePaddle(scalePaddleList[0]);
        }
    }
}
