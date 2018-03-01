using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class UIObserver : MonoBehaviour
	{
		private Cursor cursor { get; set; }
		// Use this for initialization
		void Start()
		{
			cursor = GameObject.Find("Cursor").GetComponent<Cursor>();
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void OnUI()
		{
			cursor.CanCreate = false;
		}

		public void LeaveUI()
		{
			cursor.CanCreate = true;
		}
	}
}
