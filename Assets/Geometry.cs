using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Geometry
	{
		public struct Circle
		{
			public Vector2 c;
			public float radius;
		}

		public struct Line
		{
			public Vector2 p1;
			public Vector2 p2;

			public Line (Vector2 p1, Vector2 p2)
			{
				this.p1 = p1;
				this.p2 = p2;
			}
		}

		public bool Intersect (Circle c, Rect r)
		{
			// http://stackoverflow.com/questions/401847/circle-rectangle-collision-detection-intersection
			if (PointInRectangle (c.c, r)) {
				return true;
			}
			var rA = new Vector2 (r.xMin, r.yMin);
			var rB = new Vector2 (r.xMax, r.yMin);
			var rC = new Vector2 (r.xMax, r.yMax);
			var rD = new Vector2 (r.xMin, r.yMax);
			return Intersect (c, new Line (rA, rB)) || Intersect (c, new Line (rB, rC)) ||
			Intersect (c, new Line (rC, rD)) || Intersect (c, new Line (rD, rA));
		}

		public bool Intersect (Circle c, Line l)
		{
			var r2 = c.radius * c.radius;
			var delta1 = l.p1 - c.c;
			var delta2 = l.p2 - c.c;
			if (Vector2.SqrMagnitude (delta1) < r2 || Vector2.SqrMagnitude (delta2) < r2) {
				return true;
			}

		}

		public bool Intersect (Line l1, Line l2, out Vector2 intersectPos)
		{
			//Line1
			float A1 = l1.p2.y - l1.p1.y;
			float B1 = l1.p2.x - l1.p1.x;
			float C1 = A1 * l1.p1.x + B1 * l1.p1.y;

			//Line2
			float A2 = l1.p2.y - l1.p1.y;
			float B2 = l1.p2.x - l1.p1.x;
			float C2 = A2 * l1.p1.x + B2 * l2.p1.y;

			float det = A1 * B2 - A2 * B1;
			if (det == 0) {
				// parallel
				intersectPos = null;
				return false;
			}

			float x = (B2 * C1 - B1 * C2) / det;
			float y = (A1 * C2 - A2 * C1) / det;
			intersectPos = new Vector2 (x, y);
			return true; this isn't right - return true iff intersectpos is between the points
		}

		public bool PointInRectangle (Vector2 p, Rect r)
		{
			return r.xMin >= p.x && r.xMax < p.x && r.yMin >= p.y && r.yMax < p.y;
		}
	}
}

