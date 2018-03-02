using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Sho
{
	public class SeaRion : MonoBehaviour, IStatusBehavior
	{
		[SerializeField]
		public Status status = new Status();

		public AudioWalrusScript SoundScript;

		public int AttackPower { get { return status.AttackPower; } }

		private NavMeshAgent Agent { get; set; }

		[SerializeField, Header("Sec")]
		private float span_search_new_target = 3.0f;

		private PenguinManager PenguinManager { get; set; }

		private bool attack_mode = false;
		public bool AttackMode
		{
			get { return attack_mode; }
			set
			{
				if (!value)
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
			AttackMode = false;
			rigid = this.GetComponent<Rigidbody>();
		}

		// Use this for initialization
		void Start()
		{
			SoundScript.WalrusRoarSound();
			PenguinManager = GameObject.Find("PenguinManager").GetComponent<PenguinManager>();

			StartCoroutine(SearchAndSetTarget());
		}

		// Update is called once per frame
		void Update()
		{
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
			if (status.Hp <= 0)
			{
				SoundScript.WalrusDieSound();
				Destroy(this.gameObject);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void AddExp(int exp)
		{

		}
	}
}