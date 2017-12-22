using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainOfResponsibility : MonoBehaviour {

	// Use this for initialization
	void Start () {
		IHandler handle2 = new Handler2 ();
		IHandler handle1 = new Handler1 (handle2);
		handle1.HandleRequest (20);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public abstract class IHandler{
	protected IHandler mNextHandler = null;
	public IHandler(IHandler nextHandler){
		this.mNextHandler = nextHandler;
	}

	public virtual void HandleRequest(int cost){
		if (mNextHandler != null) {
			mNextHandler.HandleRequest (cost);
		}
	}
}

public class Handler1 : IHandler{
	public Handler1(IHandler handler):base(handler){
	}

	public override void HandleRequest (int cost)
	{
		if (cost > 10)
			base.HandleRequest (cost);
		else
			Debug.Log ("handler1");
	}

}

public class Handler2 : IHandler{
	public Handler2():base(null){
	}

	public override void HandleRequest (int cost)
	{
		Debug.Log ("handler2");
	}

}