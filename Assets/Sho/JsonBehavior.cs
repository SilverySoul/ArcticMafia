using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Sho
{
	public class JsonBehavior : Internal.PenguinBehavior
	{
        public AudioPenguinScript SoundScript;
		private bool is_attack_mode = false;
		private bool IsAttackMode
		{
			get { return is_attack_mode; }
			set
			{
				if (!is_attack_mode && value)
				{
                    SoundScript.PenguingLaughSound();
					StartCoroutine(AttackExecuter());
				}

				is_attack_mode = value;
			}
		}

		private Animator Anim { get; set; }

		// Use this for initialization
		void Start()
		{
			Target = GameObject.Find("SeaRion");

			Parent.Type = PenguinManager.PenguinType.Json;

			Anim = this.GetComponentInChildren<Animator>();

			StartCoroutine(AttackExecuter());
		}

		// Update is called once per frame
		void Update()
		{
			if (!Target) return;
			Agent.destination = Target.transform.position;
			Agent.speed = Parent.Speed;
		}

		/// <summary>
		///  if you call this function penguin create bullet which has no speed and range in front of him
		/// </summary>
		public void Attack()
		{
            SoundScript.PenguingChainsawSound();
			var chain = GameObject.Instantiate(Storage.Chainsaw);
			chain.transform.position = this.transform.position + new Vector3(0.0f, 1.0f, 0.0f);
			IsAttackMode = false;
			Anim.SetTrigger("Attack");
		}

		private IEnumerator AttackExecuter()
		{
			while (true)
			{
				if (!Target) yield break;
				if ((Target.transform.position - this.transform.position).magnitude <= Storage.ChainsawAttackRange)
				{
					Attack();
					Agent.speed = 0.0f;
				}
				else
				{
					Agent.speed = Parent.Speed;
				}
				yield return new WaitForSeconds(Storage.ChainsawAttackSpan);
			}
		}
	}
}