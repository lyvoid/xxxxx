using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 装饰器模式需要保证装饰后的对象可以替换原有对象
public class DecoratorTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		IBaseClass baseclass = new BaseClass1 ();
		IDecorator decorator = new Decorator1 (baseclass);
		TestFunc (decorator);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TestFunc(IBaseClass baseclass){
		baseclass.DoSomething ();
	}

}


public abstract class IBaseClass{
	public abstract void DoSomething();
}

public class BaseClass1 : IBaseClass{
	public override void DoSomething ()
	{
		Debug.Log ("BaseClass1 DoSomething");
	}
}

public abstract class IDecorator : IBaseClass{

	public IDecorator(IBaseClass baseclass){
		this.baseclass = baseclass;
	}

	protected IBaseClass baseclass;
}	

public class Decorator1 : IDecorator{

	public Decorator1(IBaseClass baseclass) : base(baseclass){}

	public override void DoSomething ()
	{
		Debug.Log ("Decorator1 Dosomething before");
		baseclass.DoSomething ();
	}	
}
