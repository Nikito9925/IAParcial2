using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AgentModel : Model
{
    private Transform _transform;
    private Agent _entity;

    private Collider[] cols;

    private float _radius;
    private float _angle;

    private string _playerMask = "Player";
    private string _obstacleMask = "Collision";

    public AgentModel(Transform newTransform, Agent entity, float radius, float angle)
    {
        _transform = newTransform;
        _entity = entity;

        _radius = radius;
        _angle = angle;
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

    public override bool FOV()
    {
        cols = new Collider[10];
        Physics.OverlapSphereNonAlloc(_transform.position, _radius, cols, LayerMask.GetMask(_playerMask));
        bool seePlayer = false;
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i] == null) continue;

            Vector3 dirToCol = (cols[i].transform.position - _transform.position);
            dirToCol = new Vector3(dirToCol.x, 0, dirToCol.z).normalized;

            if (Vector3.Angle(dirToCol, _transform.forward) > _angle / 2)
            {
                break;
            }

            if(!Physics.Raycast(_transform.position, dirToCol.normalized, Vector3.Distance(cols[i].transform.position, _transform.position), LayerMask.GetMask(_obstacleMask)))
            {
                seePlayer = true;
            }
        }

        return seePlayer;
    }

    
}
