using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		VisitorCube visitor = new VisitorCube ();
		Cube cube = new Cube ();
		cube.RunVisitor (visitor);
		XShape xshape = new XShape ();
		xshape.RunVisitor (visitor);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public abstract class IVisitor{
	public virtual void VisiteShape(IShape shape){
		Debug.Log ("generic visite " + shape.info);
	}

	// 如果有需要访问特殊的实现类，则每次有新增的时候增加一个方法
	public virtual void VisiteCube(Cube cube){
		//Debug.Log (typeof(cube));
	}

	public virtual void VisiteSphere(Sphere sphere){
		//Debug.Log (typeof(sphere));
	}
}

public class VisitorCube : IVisitor{
	public override void VisiteCube (Cube cube)
	{
		Debug.Log ("visite cube" + cube.info);
	}
}

public class VisitorSphere : IVisitor{
	public override void VisiteSphere (Sphere sphere)
	{
		Debug.Log ("visite sphere " + sphere.info);
	}
}

public abstract class IShape{

	public string info;

	public virtual void RunVisitor(IVisitor visitor){
		visitor.VisiteShape (this);
	}
}

public class XShape : IShape{
	public XShape(){
		info = "Xshape";
	}
}

public class Cube : IShape{

	public Cube(){
		info = "cube";
	}

	public override void RunVisitor (IVisitor visitor)
	{
		visitor.VisiteCube (this);
	}
}

public class Sphere : IShape{

	public Sphere(){
		info = "sphere";
	}

	public override void RunVisitor (IVisitor visitor)
	{
		visitor.VisiteSphere (this);
	}
}