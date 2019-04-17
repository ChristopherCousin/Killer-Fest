using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{
    [Header("Decoration items for spawn randomly")]
    public List<GameObject> _Decoration_items;

    [Header("Vector of floors")]
    public List<GameObject> _TileFloors;
    public int itemsToSpaws;


    public GameObject _TileFather;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform g in _TileFather.transform.GetComponentsInChildren<Transform>())
        {
            _TileFloors.Add(g.gameObject);
        }
         itemsToSpaws =  (int)(_TileFloors.Count * 0.15f);
        RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
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


                Instantiate(_Decoration_items[Random.Range(0, _Decoration_items.Count)], _TileFloors[randomNum].transform.position, Quaternion.identity);
            } while (oldNums.Contains(randomNum));
            oldNums.Add(randomNum);
        }

    }
}
