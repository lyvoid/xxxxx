using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryAndBuilder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(Factory.getProduct<ProductA, Builder1> ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class IProduct{
	public string part1;
	public string part2;

	public override string ToString ()
	{
		return part1 + " " + part2;
	}
}

public class ProductA : IProduct{}

public class Factory{
	public static IProduct getProduct<T, V>()where T : IProduct, new() 
		where V : IBuilder, new(){
		Director director = new Director ();
		IProduct product = new T ();
		director.setProduct (product);
		director.Construct (new V());
		return product;
	}
}

public class Director{
	private IProduct product;

	public void setProduct(IProduct product){
		this.product = product;
	}

	public void Construct(IBuilder builder){
		builder.BuildPart1 (product);
		builder.BuildPart2 (product);
	}
}

public abstract class IBuilder{
	public abstract void BuildPart1 (IProduct product);
	public abstract void BuildPart2 (IProduct product);
}

public class Builder1 : IBuilder{
	public override void BuildPart1 (IProduct product)
	{
		product.part1 = "part1 type1";
	}
	public override void BuildPart2 (IProduct product)
	{
		product.part2 = "part2 type2";
	}
}

// public class Builder2 : IBuilder{
// ...	
// }