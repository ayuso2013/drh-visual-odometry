﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace VisualOdometry
{
	public struct Angle
	{
		private static readonly double s_TwoPI = 2 * Math.PI;
		private static readonly double s_RadToDegree = 180.0 / Math.PI;
		private static readonly double s_DegreeToRad = Math.PI / 180.0;

		/// <summary>
		/// Nomalizes the provided angle (degree) so that it falls in the range
		/// (-180, 180]
		/// </summary>
		/// <param name="angle">The angle to normalize in degree.</param>
		/// <returns></returns>
		public static Angle Normalize(Angle angle)
		{
			double factor = Math.Floor(angle.Rads / s_TwoPI);
			double normalizedAngleRad = angle.Rads - factor * s_TwoPI;
			if (normalizedAngleRad < 0)
			{
				normalizedAngleRad = angle.Rads + s_TwoPI;
			}

			if (normalizedAngleRad > Math.PI)
			{
				normalizedAngleRad = normalizedAngleRad - s_TwoPI;
			}
			return Angle.FromRads(normalizedAngleRad);
		}

		/// <summary>
		/// Nomalizes the provided angle (rad) so that it falls in the range
		/// (-pi, pi]
		/// </summary>
		/// <param name="rads">The angle to normalize in degree.</param>
		/// <returns></returns>
		public static double NormalizeRad(double rads)
		{
			double factor = Math.Floor(rads / s_TwoPI);
			double normalizedAngleRad = rads - factor * s_TwoPI;
			if (normalizedAngleRad < 0)
			{
				normalizedAngleRad = rads + s_TwoPI;
			}

			if (normalizedAngleRad > Math.PI)
			{
				normalizedAngleRad = normalizedAngleRad - s_TwoPI;
			}
			return normalizedAngleRad;
		}

		public static Angle FromRads(double rad)
		{
			return new Angle(rad);
		}

		public static Angle FromDegrees(double degree)
		{
			return new Angle(degree * s_DegreeToRad);
		}

		public static Angle operator +(Angle a1, Angle a2)
		{
			return new Angle(a1.Rads + a2.Rads);
		}

		public static Angle operator -(Angle a1, Angle a2)
		{
			return new Angle(a1.Rads - a2.Rads);
		}

		public static Angle operator /(Angle a1, double value)
		{
			return new Angle(a1.Rads / value);
		}

		public static Angle operator *(Angle a1, double value)
		{
			return new Angle(a1.Rads * value);
		}

		private Angle(double rad)
		{
			Rads = NormalizeRad(rad);
		}

		public double Degrees
		{
			get { return Rads * s_RadToDegree; }
		}

		public double Rads;

		public override string ToString()
		{
			return this.Degrees.ToString(CultureInfo.InvariantCulture) + " deg";
		}
	}
}
