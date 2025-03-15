using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	[Serializable]
	public class EllipseShape : Shape
	{
		#region Constructor

		public EllipseShape() { }
		public EllipseShape(RectangleF rect) : base(rect)
		{
		}

		public EllipseShape(EllipseShape ellipse) : base(ellipse)
		{
		}

		#endregion

		/// <summary>
		/// Проверка за принадлежност на точка point към правоъгълника.
		/// В случая на правоъгълник този метод може да не бъде пренаписван, защото
		/// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
		/// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
		/// елемента в този случай).
		/// </summary>
		public override bool Contains(PointF point)
		{
			if (base.Contains(point))
				// Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
				// В случая на правоъгълник - директно връщаме true
				return true;
			else
				// Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
				return false;
		}

		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

			using (Matrix m = new Matrix())
			{
				m.RotateAt(Rotation, new PointF(Rectangle.Left + (Rectangle.Width / 2),
							Rectangle.Top + (Rectangle.Height / 2)));

				grfx.Transform = m;
				grfx.FillEllipse(new SolidBrush(Color.FromArgb(Transparency, FillColor)), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
				grfx.DrawEllipse(new Pen(StrokeColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
				grfx.ResetTransform();
			}
		}

		public override Shape Clone()
		{
			return new EllipseShape()
			{
				Rectangle = this.Rectangle,
				FillColor = this.FillColor,
				StrokeColor = this.StrokeColor,

				Transparency = this.Transparency,
				Rotation = this.Rotation,
				Scale = this.Scale,

				Width = this.Width,
				Height = this.Height,
				Location = this.Location,
			};
		}
	}
}
