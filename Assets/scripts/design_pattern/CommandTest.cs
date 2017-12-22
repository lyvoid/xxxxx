using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoker invoker = new Invoker ();
		IReceive reveive = new Receive1 ();
		ICommand command = new Command1 ();
		command.ConstructCommand (reveive, "command");
		invoker.AddCommand (command);
		invoker.AddCommand (command);
		invoker.Execute ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public abstract class ICommand{

	protected IReceive mReceive;
	public abstract void Execute ();
	public abstract void ConstructCommand(IReceive receive, string param);
}

public abstract class IReceive{
	protected string param;
	public abstract void Action ();
	public abstract void SetParam (string param);
}

public class Receive1 : IReceive{
	public override void Action ()
	{
		Debug.Log (this.param);
	}

	public override void SetParam(string param){
		this.param = param;
	}
}


public class Command1 : ICommand{

	public override void ConstructCommand (IReceive receive, string param){
		this.mReceive = receive;
		receive.SetParam (param);
	}

	public override void Execute ()
	{
		mReceive.Action ();
	}
}

public class Invoker{
	List<ICommand> mCommand = new List<ICommand>();
	public void AddCommand(ICommand command){
		mCommand.Add (command);
	}

	public void Execute(){
		foreach (var item in mCommand) {
			item.Execute ();
		}
		mCommand.Clear ();
	}
}