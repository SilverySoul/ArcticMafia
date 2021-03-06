﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Sho
{
	public class SeaRion : MonoBehaviour, IStatusBehavior
	{
		[SerializeField]
		private Status status = new Status();

		public int AttackPower { get { return status.AttackPower; } }

		private NavMeshAgent Agent { get; set; }

		[SerializeField, Header("Sec")]
		private float span_search_new_target = 3.0f;

		private PenguinManager PenguinManager { get; set; }

		[SerializeField]
		private GameObject debug_target_view = null;

		private bool attack_mode = false;
		public bool AttackMode
		{
			get { return attack_mode; }
			set
			{
				if(!value)
				{
					Agent.speed = status.Speed;
				}
				else
				{
					Agent.speed = 0.0f;
				}
				attack_mode = value;
			}
		}

		private Rigidbody rigid = null;
		public Rigidbody Rigid
		{
			get { return rigid; }
		}

		private bool HasTarget { get; set; }

		private void Awake()
		{
			Agent = this.GetComponent<NavMeshAgent>();
			//Agent.updatePosition = false;
			//Agent.updateRotation = false;
			AttackMode = false;
			rigid = this.GetComponent<Rigidbody>();
		}

		// Use this for initialization
		void Start()
		{

			PenguinManager = GameObject.Find("PenguinManager").GetComponent<PenguinManager>();

			StartCoroutine(SearchAndSetTarget());
		}

		// Update is called once per frame
		void Update()
		{
			//if (!HasTarget) return;
			//var dir = Agent.nextPosition - this.transform.position;
			//var smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
			//var angle = Mathf.Acos(Vector3.Dot(transform.forward, dir.normalized)) * Mathf.Rad2Deg * smooth;

			//var rot = Quaternion.AngleAxis(angle, Vector3.up);
			//transform.forward = rot * transform.forward;

			/*if (!AttackMode) */
			//this.transform.position = Agent.nextPosition;
			Agent.speed = status.Speed;
			Agent.angularSpeed = status.Angular;
		}

		IEnumerator SearchAndSetTarget()
		{
			while (true)
			{
				var p = PenguinManager.SearchNearOne(this.gameObject);
				if (p)
				{
					Agent.SetDestination(p.transform.position);
#if DEBUG
					if (debug_target_view)
					{
						var dp = debug_target_view.transform.position;
						dp.x = p.transform.position.x;
						dp.z = p.transform.position.z;
						debug_target_view.transform.position = dp;
					}
#endif
					HasTarget = true;
					yield return new WaitForSeconds(span_search_new_target);
				}
				else
				{
					HasTarget = false;
					yield return null;
				}
			}
		}

		public void Attack(Penguin pen)
		{
			pen.Damage(status.AttackPower);
		}

		public void AddGold(int gold)
		{
			// later

		}

		public bool Damage(int damage)
		{
			status.Hp -= damage;
			return status.Hp <= 0 ? true : false;
		}

		public void AddExp(int exp)
		{

		}
	}
}