using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateModeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Context context = new Context ();
		context.SetState (new StateA(context));
		Debug.Log(context.Request());
		context.SetState (new StateB (context));
		Debug.Log(context.Request());
	}

	// Update is called once per frame
	void Update () {

	}
}


public abstract class IState {
	protected Context mContext = null;

	public IState(Context theContext){
		mContext = theContext;
	}

	public abstract string Handle ();
}

public class StateA : IState{
	public StateA(Context theContext) : base(theContext){
	}

	public override string Handle(){
		return "StateA";
	}
}

public class StateB : IState{
	public StateB(Context theContext) : base(theContext){
	}

	public override string Handle(){
		return "StateB";
	}
}



public class Context
{
	IState mState = null;

	public string Request(){
		return mState.Handle ();
	}

	public void SetState(IState state){
		this.mState = state;
	}
}

