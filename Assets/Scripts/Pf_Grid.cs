using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Pf_Grid : MonoBehaviour
{
    public GameObject[] nodes;
    [SerializeField] private int _width = 0, _height = 0;
    //[SerializeField] private float _offset = 0;
    [SerializeField] private float _distance = 0;
    [SerializeField] private GameObject _prefab = default;


    [ContextMenu("Create Grid")]
    private void CreateGrid()
    {
        nodes = new GameObject[_width * _height];
        Action setAllNeighbors = () => { };

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                GameObject prefab = Instantiate(_prefab,
                    transform.position + new Vector3(x, 0, y) * _distance, Quaternion.identity,
                    transform);
                nodes[x * _width + y] = prefab;
                prefab.GetComponent<Pf_Node>().Initialize(x, y, this);
                setAllNeighbors += () => prefab.GetComponent<Pf_Node>().GetNeighbors();
            }
        }
        setAllNeighbors?.Invoke();

    }

    public Pf_Node GetNode(int x, int y)
    {
        if (x < 0 || x > _width - 1 || y < 0 || y > _height - 1) return null;

        Pf_Node node = nodes[x * _width + y].GetComponent<Pf_Node>();
        if (node != null) return node;
        else return null;
    }

    public void ResetNodesColors()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i] != null)
            {
                Pf_Node node = nodes[i].GetComponent<Pf_Node>();

                if (node != null)
                {
                    if (node.isBlocked) continue;
                    GameManager.instance.PaintGameObject(nodes[i], Color.red);
                }
            }

        }
    }
}
