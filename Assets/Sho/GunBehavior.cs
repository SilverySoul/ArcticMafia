using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class GunBehavior : Internal.PenguinBehavior
	{
		private float shot_dist = 5.0f;


		// Use this for initialization
		void Start()
		{
			Target = GameObject.Find("SeaRion");
			Parent.Type = PenguinManager.PenguinType.Gun;
		}

		// Update is called once per frame
		void Update()
		{
			shot_dist = Storage.GunsAttackRange;

			var v = Target.transform.position - this.transform.position;
			if (v.magnitude > shot_dist)
			{
				// Go to SeaRion
				Agent.destination = v.normalized * shot_dist + this.transform.position;
			}
			else
			{
				// Attack

			}
		}
	}
}