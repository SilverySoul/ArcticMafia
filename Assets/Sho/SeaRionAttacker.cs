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

		// Use this for initialization
		void Start()
		{
			parent = this.GetComponentInParent<SeaRion>();

			StartCoroutine(AttackToPenguin());
		}

		// Update is called once per frame
		void Update()
		{

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