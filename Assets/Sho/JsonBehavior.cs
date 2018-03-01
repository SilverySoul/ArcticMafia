using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Sho
{
	public class JsonBehavior : Internal.PenguinBehavior
	{
		
		// Use this for initialization
		void Start()
		{
			Target = GameObject.Find("SeaRion");

			Parent.Type = PenguinManager.PenguinType.Json;
		}

		// Update is called once per frame
		void Update()
		{
			Agent.destination = Target.transform.position;
			Agent.speed = Parent.Speed;
		}
	}
}