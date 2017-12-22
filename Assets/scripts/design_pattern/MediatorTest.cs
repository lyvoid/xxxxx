using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediatorTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mediator mediator = new Mediator ();
		System1 system1 = new System1 (mediator);
		System2 system2 = new System2 (mediator);
		mediator.Initial (system1, system2);
		system1.Operation1 ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class Mediator{
	private System1 system1 = null;
	private System2 system2 = null; 
	public void Initial(System1 system1, System2 system2){
		this.system1 = system1;
		this.system2 = system2;
	}

	public void Operation1(){
		system2.Operation1();
	}

	public void Operation2(){
		system1.Operation2 ();
	}
}

public class ISystem{
	protected Mediator mMediator = null;

	public ISystem(Mediator mediator){
		this.mMediator = mediator;
	}
}

public class System1 : ISystem{

	public System1(Mediator mediator) : base(mediator){
		
	}

	public void Operation1(){
		mMediator.Operation1 ();
	}

	public void Operation2(){
		Debug.Log ("System1 Operation2");
	}
}

public class System2 : ISystem{

	public System2(Mediator mediator) : base(mediator){

	}

	public void Operation2(){
		mMediator.Operation2 ();
	}

	public void Operation1(){
		Debug.Log ("System2 Operation1");
	}
}