using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pf_Agent : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    private List<Pf_Node> _path = new();

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    public void SetPath(List<Pf_Node> path)
    {
        if (path.Count <= 0) return;
        _path = path;
    }

    private void FollowPath()
    {
        if (_path.Count <= 0) return;

        Vector3 dir = _path[0].transform.position - transform.position;
        dir.y = 0;
        transform.forward = dir;

        if (dir.magnitude < 0.25f)
        _path.RemoveAt(0);

        transform.position += dir.normalized * _speed * Time.deltaTime;
    }

    private void Update()
    {
        FollowPath();
    }
}
