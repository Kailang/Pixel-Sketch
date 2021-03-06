﻿using UnityEngine;
using UnityEngine.EventSystems;

using System.Collections;

using Uif;

public class PopupOverlayController : MonoBehaviour, IPointerClickHandler {
	public delegate void OnOverlayClicked ();

	public event OnOverlayClicked OnOverlayClickcedEvent;

	public Hidable OverlayHidable;


	void OnValidate () {
		OverlayHidable = GetComponent<Hidable>();
	}

	void Start () {
		ShowOverlay();
	}

	public void ShowOverlay () {
		gameObject.SetActive(true);
		OverlayHidable.Show();
	}

	public void HideOverlay () {
		OverlayHidable.Hide();
		StartCoroutine(DeactivateHandler());
	}

	public void OnPointerClick (PointerEventData eventData) {
		if (OnOverlayClickcedEvent != null) OnOverlayClickcedEvent();
	}

	IEnumerator DeactivateHandler () {
		yield return new WaitForSeconds(0.5f);

		gameObject.SetActive(false);
	}
}
