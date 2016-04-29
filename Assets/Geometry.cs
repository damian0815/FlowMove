using System;
using UnityEngine;

namespace AssemblyCSharp
{
	static public class Geometry
	{
		public struct Circle
		{
			public Vector2 center;
			public float radius;

			public Circle(Vector2 center, float radius) {
				this.center = center;
				this.radius = radius;
			}
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

		public static bool Intersects (Circle c, Rect r)
		{
			// http://stackoverflow.com/questions/401847/circle-rectangle-collision-detection-intersection
			if (IsPointInRectangle (c.center, r)) {
				return true;
			}
			var rA = new Vector2 (r.xMin, r.yMin);
			var rB = new Vector2 (r.xMax, r.yMin);
			var rC = new Vector2 (r.xMax, r.yMax);
			var rD = new Vector2 (r.xMin, r.yMax);
			return Intersects (c, new Line (rA, rB)) || 
				Intersects (c, new Line (rB, rC)) ||
				Intersects (c, new Line (rC, rD)) || 
				Intersects (c, new Line (rD, rA));
		}

		public static bool Intersects (Circle c, Line l)
		{
			var shortestDistanceToLine = Distance(c.center, l);
			return (shortestDistanceToLine < c.radius);
		}

		public static Vector2 GetNearestPointOnLineToPoint(Vector2 p, Line l)
		{
			var AP = p - l.p1;
			var AB = l.p2 - l.p1;

			float ABAPproduct = Vector2.Dot(AP, AB);
			float distance = ABAPproduct / AB.sqrMagnitude;

			if (distance < 0) {
				return l.p1;
			} else if (distance > 1) {
				return l.p2;
			} else {
				return l.p1 + AB * distance;
			}
		}

		public static float Distance(Vector2 p, Line l)
		{
			var nearestPoint = GetNearestPointOnLineToPoint(p, l);
			return (nearestPoint - p).magnitude;
		}

		public static bool IsPointInRectangle (Vector2 p, Rect r)
		{
			return r.xMin <= p.x && r.xMax > p.x && r.yMin <= p.y && r.yMax > p.y;
		}
	}
}

