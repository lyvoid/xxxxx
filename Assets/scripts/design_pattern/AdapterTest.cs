using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 当一个接口的参数为一个类，但需要使用的方法却是另一个类的时候用
// 相当于把一个类转化成另一个需求的类来使用
public class AdapterTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		A a = new A1 ();
		IAdaptor adaptor = new Adaptor1 ();
		adaptor.a = a;
		TestFunction (adaptor);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TestFunction(B b){
		b.BOperation ();
	}
}

public abstract class A{
	public abstract void AOperation();
}

public abstract class B{
	public abstract void BOperation();
}

public class A1 : A {
	public override void AOperation ()
	{
		Debug.Log ("A1 - AOperation");
	}
}

public class B1 : B{
	public override void BOperation ()
	{
		Debug.Log ("B1 - B Operation");
	}
}

public abstract class IAdaptor : B{

	public A a;
}

public class Adaptor1 : IAdaptor{
	public override void BOperation ()
	{
		a.AOperation ();
	}
}