using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongPaddleManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxLongPaddleAmount;
    public int spawnInterval;
    public Vector2 longPaddleAreaMin;
    public Vector2 longPaddleAreaMax;
    public List<GameObject> longPaddleTemplateList;

    private List<GameObject> longPaddleList;
    private float timer;

    private void Start()
    {
        longPaddleList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnInterval)
        {
            GenerateRandomLongPaddle();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomLongPaddle()
    {
        GenerateRandomLongPaddle(new Vector2(Random.Range(longPaddleAreaMin.x, longPaddleAreaMax.x),
            Random.Range(longPaddleAreaMin.y, longPaddleAreaMax.y)));
    }

    public void GenerateRandomLongPaddle(Vector2 position)
    {
        if(longPaddleList.Count >= maxLongPaddleAmount)
        {
            return;
        }
        
        if (position.x < longPaddleAreaMin.x ||
            position.x > longPaddleAreaMax.x ||
            position.y < longPaddleAreaMin.y ||
            position.y > longPaddleAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, longPaddleTemplateList.Count);

        GameObject longPaddle = Instantiate(longPaddleTemplateList[randomIndex],
            new Vector3(position.x, position.y, longPaddleTemplateList[randomIndex].transform.position.z),
            Quaternion.identity, spawnArea);
        longPaddle.SetActive(true);

        longPaddleList.Add(longPaddle);
    }

    public void RemoveLongPaddle(GameObject longPaddle)
    {
        longPaddleList.Remove(longPaddle);
        Destroy(longPaddle);
    }

    public void RemoveAllLongPaddle()
    {
        while(longPaddleList.Count > 0)
        {
            RemoveLongPaddle(longPaddleList[0]);
        }
    }
}
