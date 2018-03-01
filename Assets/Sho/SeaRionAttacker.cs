using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class SeaRionAttacker : MonoBehaviour
	{
		SeaRion parent = null;

		[SerializeField, Header("Sec")]
		private float attack_span = 0.5f;

		[SerializeField]
		List<Penguin> attacks_list = new List<Penguin>();

		[SerializeField]
		private float advance_dist = 30.0f;
		[SerializeField]
		private float advance_velocity_max = 40.0f;


		// Use this for initialization
		void Start()
		{
			parent = this.GetComponentInParent<SeaRion>();

			StartCoroutine(AttackToPenguin());
		}

		// Update is called once per frame
		void Update()
		{
			if (parent.Rigid.velocity.magnitude >= advance_velocity_max)
			{
				parent.Rigid.velocity = parent.Rigid.velocity.normalized * advance_velocity_max;
			}
		}

		public IEnumerator AttackToPenguin()
		{
			while (true)
			{
				if (attacks_list.Count <= 0)
				{
					parent.AttackMode = false;
					yield return null;
				}
				else
				{
					parent.AttackMode = true;
					parent.Rigid.AddForce(this.transform.forward * advance_dist, ForceMode.Impulse);
					yield return new WaitForSeconds(attack_span);
					Attack();
				}
			}
		}

		private void Attack()
		{
			List<Penguin> temp = new List<Penguin>();
			foreach (var item in attacks_list)
			{
				Debug.Log("The Boss Attack Penguin" + item.ID);
				if (!item.Damage(parent.AttackPower))
				{
					temp.Add(item);
				}
			}
			attacks_list = temp;
		}

		public void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag != "Penguin") return;
			var p = other.GetComponent<Penguin>();
			foreach (var item in attacks_list)
			{
				if (p.ID == item.ID)
				{
					return;
				}
			}
			attacks_list.Add(p);
		}

		public void OnTriggerExit(Collider other)
		{
			if (other.gameObject.tag != "Penguin") return;
			var p = other.GetComponent<Penguin>();
			attacks_list.Remove(p);
		}
	}
}