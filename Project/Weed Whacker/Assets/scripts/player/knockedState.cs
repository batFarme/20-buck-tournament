using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class knockedState : BaseState<playerScript.PlayerStates> // this gives an error for some reason....
{
    
    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override playerScript.PlayerStates GetNextState()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
