using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	/// <summary>
	/// PenguinBehavior is not Prehab , so You can Use this Storage to SetUp Some Value in each PenguinBehavior
	/// </summary>
	public class PenguinBehaviorStatus : MonoBehaviour
	{
		[SerializeField, Header("Attack Range")]
		private float guns_attack_range = 5.0f;
		public float GunsAttackRange
		{
			get { return guns_attack_range; }
		}

		[SerializeField, Header("Update TargetGold Pos")]
		private float search_gold_span = 1.0f;
		public float SearchGoldSpan
		{
			get
			{
				return search_gold_span;
			}
		}

		[SerializeField]
		private BulletBehavior bullet_prehab = null;
		public BulletBehavior BulletPrehab
		{
			get
			{
				return bullet_prehab;
			}
		}

		[SerializeField]
		private float gun_attack_span = 0.2f;
		public float GunAttackSpan
		{
			get { return gun_attack_span; }
		}

		[SerializeField,Header("Fire time Per a Bullet")]
		private float gun_attack_span_to_next_bullet = 0.2f;
		public float GunAttackSpanToNextBullet
		{
			get { return gun_attack_span_to_next_bullet; }
		}
	}
}