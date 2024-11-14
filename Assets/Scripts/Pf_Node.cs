using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pf_Node : MonoBehaviour
{
    [SerializeField] private List<Pf_Node> _neighbors = new();
    [SerializeField] private Grid _grid = default;
    private int _x = 0, _y = 0;

    public bool isBlocked = false;

    public List<Pf_Node> GetNeighbors()
    {
        if (_neighbors.Count != 0) return _neighbors;
        Pf_Node neighbor = _grid.GetNode(_x, _y - 1);  //Up.

        if (neighbor) _neighbors.Add(neighbor);
        neighbor = _grid.GetNode(_x + 1, _y);          //Right.

        if (neighbor) _neighbors.Add(neighbor);
        neighbor = _grid.GetNode(_x, _y + 1);          //Down.

        if (neighbor) _neighbors.Add(neighbor);
        neighbor = _grid.GetNode(_x - 1, _y);          //Left.
        
        if (neighbor) _neighbors.Add(neighbor);


        return _neighbors;
    }

    public void Initialize(int x, int y, Grid grid)
    {
        _x = x;
        _y = y;
        _grid = grid;
    }
}
