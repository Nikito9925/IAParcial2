using System.Collections.Generic;
using UnityEngine;

public abstract class Model
{
    public virtual void Move() { }
    public virtual void SetPath(List<Pf_Node> path) { }

    public virtual void SetPos(Vector3 pos) { }
}
