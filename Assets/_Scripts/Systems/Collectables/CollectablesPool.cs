using System.Collections.Generic;
using UnityEngine;

public class CollectablesPool : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private int size = 10;
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<GameObject> collectables = new();

    [Space]
    [SerializeField] private float minProv = 1;
    [SerializeField] private float maxProv = 5;

    private float timer = 0;

    private void Awake()
    {
        for (int i = 0; i < size; i++)
        {
            GameObject ob = Instantiate(prefab, transform);
            collectables.Add(ob);
            ob.SetActive(false);
        }
    }

    private void Start()
    {
        timer = Random.Range(minProv, maxProv);
    }

    private void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                timer = Random.Range(minProv, maxProv);

                InitCoin();
            }

            for (int i = 0; i < size; i++)
            {
                if (collectables[i].activeSelf)
                {
                    collectables[i].transform.position -= speed * Time.deltaTime * transform.up;
                    if (collectables[i].transform.position.y <= -3.3f)
                    {
                        collectables[i].SetActive(false);
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }

    private void InitCoin()
    {
        for (int i = 0; i < size; i++)
        {
            if (!collectables[i].activeSelf)
            {
                collectables[i].transform.localPosition = new Vector2(Random.Range(-4.5f, 4.5f), 3.3f);
                collectables[i].SetActive(true);
                break;
            }
            else
            {
                continue;
            }
        }
    }
}