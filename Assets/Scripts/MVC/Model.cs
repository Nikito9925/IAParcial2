using System.Collections.Generic;
using UnityEngine;

public abstract class Model
{
    public Agent _entity;
    public virtual void Move() { }
    public virtual void SetPath(List<Pf_Node> path) { }

    public virtual void SetPos(Vector3 pos) { }

    public virtual bool FOV() { return false; }

    public virtual bool HasNodes() { return false; }
}
