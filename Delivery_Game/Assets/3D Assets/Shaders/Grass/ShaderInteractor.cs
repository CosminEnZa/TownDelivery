using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderInteractor : MonoBehaviour
{
    void Update()
    {
        Shader.SetGlobalVector("_PositionMoving", transform.position);
    }
}
