using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{
    [Header("Decoration items for spawn randomly")]
    [SerializeField] private List<GameObject> _Decoration_items;

    [Header("Vector of floors")]
    [SerializeField] private List<GameObject> _TileFloors;
    [SerializeField] private int itemsToSpaws;


    [SerializeField] private GameObject _TileFather;


    // Start is called before the first frame update
    void Start()
    {
        GetAllMap();
        itemsToSpaws =  (int)(_TileFloors.Count * 0.15f);
        RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetAllMap()
    {
        if(_TileFather != null)
        {
            foreach (Transform g in _TileFather.transform.GetComponentsInChildren<Transform>())
            {
                _TileFloors.Add(g.gameObject);
            }
        } else {
            Debug.Log("No father GameObject for take the tileSet MAP");
        }
    }


    private void RandomSpawn()
    {
        List<int> oldNums = new List<int>();
        oldNums.Clear();
        int randomNum;

        for(int x= 0; x < _TileFloors.Count * 0.01; x++)
        {
            do
            {
                randomNum = Random.Range(0, _TileFloors.Count);
                Instantiate(_Decoration_items[Random.Range(0, _Decoration_items.Count)], _TileFloors[randomNum].transform.position, Quaternion.identity, transform);

            } while (oldNums.Contains(randomNum));

            oldNums.Add(randomNum);
        }
    }
}
