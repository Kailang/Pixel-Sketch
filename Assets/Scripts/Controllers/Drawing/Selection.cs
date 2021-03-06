﻿using UnityEngine;

using System;
using System.Collections.Generic;

public class Selection {
	public readonly Dictionary<Short2, bool> Area = new Dictionary<Short2, bool>();
	public readonly Dictionary<Short2, Color> Content = new Dictionary<Short2, Color>();

	public float Scale {
		get { return scale; }
		set {
			scale = value;

			UiDirtyFlag = true;
		}
	}

	public float Rotation {
		get { return rotation; }
		set {
			rotation = value;

			UiDirtyFlag = true;
		}
	}

	public Vector3 Pivotal {
		get { return pivotal; }
		set {
			pivotal = value;

			UiDirtyFlag = true;
		}
	}

	public Vector3 Position {
		get { return position; }
		set {
			position = value;

			UiDirtyFlag = true;
		}
	}

	float scale;
	float rotation;
	Vector3 pivotal;
	Vector3 position;

	Vector3 min;
	Vector3 max;

	public bool UiDirtyFlag;
	public bool GridDirtyFlag;

	public Selection () {
		ResetSelection();
	}

	public void ResetSelection () {
		Area.Clear();
		Content.Clear();

		scale = 1;
		rotation = 0;
		pivotal = Vector3.zero;
		position = Vector3.zero;

		min = new Vector3(float.MaxValue, float.MaxValue);
		max = new Vector3(float.MinValue, float.MinValue);

		UiDirtyFlag = true;
		GridDirtyFlag = true;
	}

	public void ClearSelection () {
		Area.Clear();

		GridDirtyFlag = true;
	}

	public bool GetSelection (Short2 c) {
		return Area.ContainsKey(c);
	}

	public void SetSelection (Short2 c, bool value = true) {
		if (value) Area[c] = true;
		else if (Area.ContainsKey(c)) Area.Remove(c);

		GridDirtyFlag = true;
	}

	public void CalcPivotal () {
		min = new Vector3(float.MaxValue, float.MaxValue);
		max = new Vector3(float.MinValue, float.MinValue);

		foreach (var key in Area.Keys) {
			var v = new Vector3(key.x, key.y);
			min = Vector3.Min(min, v);
			max = Vector3.Max(max, v);
		}

		pivotal = (min + max) * 0.5f;
		position = pivotal;
	}
}