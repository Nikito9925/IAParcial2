using System.Collections.Generic;
using UnityEngine;

public class AgentModel : Model
{
    private Transform _transform;
    private Agent _entity;

    public AgentModel(Transform newTransform, Agent entity)
    {
        _transform = newTransform;
        _entity = entity;
    }
    public override void Move()
    {
        if (_path.Count <= 0) return;

        Vector3 dir = _path[0].transform.position - _transform.position;
        dir.y = 0;
        _transform.forward = dir;

        if (dir.magnitude < 0.25f)
        {
            _path.RemoveAt(0);
            if(_path.Count <= 0)
            {
                _entity.firstPath = !_entity.firstPath;
                _entity.StartPatrol();
            }
        }

        _transform.position += dir.normalized * _speed * Time.deltaTime;
    }

    [SerializeField] private float _speed = 2;
    private List<Pf_Node> _path = new();

    public override void SetPos(Vector3 pos)
    {
        _transform.position = pos;
    }

    public override void SetPath(List<Pf_Node> path)
    {
        if (path.Count <= 0) return;
        _path = path;
    }

    private void FollowPath()
    {
        if (_path.Count <= 0) return;

        Vector3 dir = _path[0].transform.position - _transform.position;
        dir.y = 0;
        _transform.forward = dir;

        if (dir.magnitude < 0.25f)
            _path.RemoveAt(0);

        _transform.position += dir.normalized * _speed * Time.deltaTime;
    }
}
