using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Sho.Internal
{
	/// <summary>
	/// the Base Class of Json and Guns
	/// </summary>
	public class PenguinBehavior : MonoBehaviour
	{
		protected Penguin Parent { get; set; }
		protected NavMeshAgent Agent { get; set; }
		protected GameObject Target { get; set; }
		protected PenguinBehaviorStatus Storage { get; set; }

		private void Awake()
		{
			Agent = this.GetComponent<NavMeshAgent>();
			Parent = this.GetComponent<Penguin>();
			Storage = GameObject.Find("PenguinBehaviorValueStorage").GetComponent<PenguinBehaviorStatus>();
		}
	}
}