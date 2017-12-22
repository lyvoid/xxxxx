using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 提了一个流程放在抽象类里，方便多个子类流程修改时，只需要修改抽象类即可
public class TemplateMethodTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		IDosomething xxx = new DoSomething ();
		xxx.Do ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public abstract class IDosomething{
	public void Do(){
		Step1 ();
		Step2 ();
	}

	protected abstract void Step1 ();
	protected abstract void Step2 ();
}

public class DoSomething : IDosomething{
	protected override void Step1 ()
	{
		Debug.Log ("DoSomething step1");
	}

	protected override void Step2 ()
	{
		Debug.Log ("Dosomething Step2");
	}
}