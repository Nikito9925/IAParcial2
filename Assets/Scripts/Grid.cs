using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private GameObject[,] _grid = default;
    [SerializeField] private int _width = 0, _height = 0;
    [SerializeField] private float _offset = 0;
    [SerializeField] private float _distance = 0;
    [SerializeField] private GameObject _prefab = default;


    [ContextMenu("Create Grid")]
    private void CreateGrid()
    {
        _grid = new GameObject[_width, _height];

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                GameObject prefab = Instantiate(_prefab,
                    transform.position + new Vector3(x, 0, y) * _distance, Quaternion.identity, transform);
                _grid[x, y] = prefab;
                prefab.GetComponent<Pf_Node>().Initialize(x, y, this);
                prefab.GetComponent<Pf_Node>().GetNeighbors();
            }
        }
    }

    public Pf_Node GetNode(int x, int y)
    {
        if (x < 0 || x > _width - 1 || y < 0 || y > _height - 1) return null;

        return _grid[x, y].GetComponent<Pf_Node>();
    }
}
