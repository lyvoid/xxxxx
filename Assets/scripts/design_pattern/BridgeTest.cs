using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 有点像搭积木
// 双方都不依赖与实现，而依赖于接口，因此用户和功能可以随意组合
// 在不通角色与技能之间的时候可以使用到
public class BridgeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		IClient client = new Client1 ();
		IFunction function = new Function2 ();
		client.SetFunction (function);
		function.SetClient (client);
		client.mStr = "xxxx";
		client.Call ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public abstract class IClient{

	protected IFunction mFunction = null;
	public string mStr = null;

	public void SetFunction(IFunction function){
		this.mFunction = function;
	}

	public abstract void Call ();

}


public abstract class IFunction{
	protected IClient mClient;
	public void SetClient(IClient client){
		this.mClient = client;
	}
	public abstract void Call1 ();
	public abstract void Call2 ();
}

public class Client1 : IClient{
	public override void Call ()
	{
		mFunction.Call1 ();
	}
}

public class Client2 : IClient{
	public override void Call ()
	{
		mFunction.Call2 ();
	}
}

public class Function1 : IFunction{
	public override void Call1 ()
	{
		Debug.Log (mClient.mStr + " function1 call1");
	}

	public override void Call2 ()
	{
		Debug.Log (mClient.mStr + " function1 call2");
	}
}

public class Function2 : IFunction{
	public override void Call1 ()
	{
		Debug.Log (mClient.mStr + " function2 call1");
	}

	public override void Call2 ()
	{
		Debug.Log (mClient.mStr + " function2 call2");
	}
}

