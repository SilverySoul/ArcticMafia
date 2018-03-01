using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Sho
{
	public class SeaRion : MonoBehaviour
	{
		[SerializeField]
		private Status status = new Status();

		public int AttackPower { get { return status.AttackPower; } }

		private NavMeshAgent Agent { get; set; }

		[SerializeField, Header("Sec")]
		private float span_search_new_target = 3.0f;

		[SerializeField]
		private float angular = 30.0f;

		private PenguinManager PenguinManager { get; set; }

		[SerializeField]
		private GameObject debug_target_view = null;

		private bool attack_mode = false;
		public bool AttackMode
		{
			get { return attack_mode; }
			set 
			{
				if (value)
				{
					Agent.speed = 0.0f;
				}
				else
				{
					Agent.speed = status.Speed;
				}
				attack_mode = value;
			}
		}

		private Rigidbody rigid = null;
		public Rigidbody Rigid
		{
			get { return rigid; }
		}

		private void Awake()
		{
			Agent = this.GetComponent<NavMeshAgent>();
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
			//Agent.speed = status.Speed;
			Agent.angularSpeed = angular;
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
					var dp = debug_target_view.transform.position;
					dp.x = p.transform.position.x;
					dp.z = p.transform.position.z;
					debug_target_view.transform.position = dp;
#endif
					yield return new WaitForSeconds(span_search_new_target);
				}
				else
				{
					yield return null;
				}
			}
		}

		public void Attack(Penguin pen)
		{
			pen.Damage(status.AttackPower);
		}
	}
}