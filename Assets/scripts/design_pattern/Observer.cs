using System.Collections;
using System.Collections.Generic;
using UnityEngine;

delegate void DelegateType(string msg);//相当于声明update的接口类型
public class Observer : MonoBehaviour {
		
	DelegateType subject1;//新增一个subject，供Observer订阅

	// Use this for initialization
	void Start () {
		subject1 += new DelegateType (ObserverUpdate1);
		subject1 += new DelegateType (ObserverUpdate2); //增加订阅者
		subject1("event");//发送消息/触发事件
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ObserverUpdate1(string msg){
		Debug.Log ("update1 " + msg);
	}

	void ObserverUpdate2(string msg){
		Debug.Log ("update2 " + msg);
	}
}
	