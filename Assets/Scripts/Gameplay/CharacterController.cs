using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    [SerializeField]
    private Character _controlledTarget;
    public Character ControlledTarget { get { return _controlledTarget; } }

    // Update is called once per frame
    void Update()
    {
        ProcessInput(_controlledTarget);
    }

    protected abstract void ProcessInput(Character target);
}
