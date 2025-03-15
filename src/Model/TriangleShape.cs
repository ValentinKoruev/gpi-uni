using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
	public class TriangleShape : Shape
	{
		public TriangleShape() { }

		public TriangleShape(RectangleF rect) : base(rect) { }

		public TriangleShape(TriangleShape triangle) : base(triangle) { }

		public override bool Contains(PointF point)
		{
			PointF p1 = new PointF(Rectangle.Left + Rectangle.Width / 2, Rectangle.Top);
			PointF p2 = new PointF(Rectangle.Left, Rectangle.Bottom);
			PointF p3 = new PointF(Rectangle.Right, Rectangle.Bottom);

			return IsPointInTriangle(point, p1, p2, p3);
		}

		private bool IsPointInTriangle(PointF p, PointF p1, PointF p2, PointF p3)
		{
			float d1 = Sign(p, p1, p2);
			float d2 = Sign(p, p2, p3);
			float d3 = Sign(p, p3, p1);
			bool hasNeg = (d1 < 0) || (d2 < 0) || (d3 < 0);
			bool hasPos = (d1 > 0) || (d2 > 0) || (d3 > 0);
			return !(hasNeg && hasPos);
		}

		private float Sign(PointF p1, PointF p2, PointF p3)
		{
			return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
		}

		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

			using (Matrix m = new Matrix())
			{
				m.RotateAt(Rotation, new PointF(Rectangle.Left + (Rectangle.Width / 2),
							Rectangle.Top + (Rectangle.Height / 2)));

				grfx.Transform = m;

				PointF[] points =
				{
					new PointF(Rectangle.Left + Rectangle.Width / 2, Rectangle.Top),
					new PointF(Rectangle.Left, Rectangle.Bottom),
					new PointF(Rectangle.Right, Rectangle.Bottom)
				};
				grfx.FillPolygon(new SolidBrush(Color.FromArgb(Transparency, FillColor)), points);
				grfx.DrawPolygon(new Pen(StrokeColor), points);
				grfx.ResetTransform();
			}
		}

		public override Shape Clone()
		{
			return new TriangleShape
			{
				Rectangle = this.Rectangle,
				FillColor = this.FillColor,
				StrokeColor = this.StrokeColor,
				Transparency = this.Transparency,
				Rotation = this.Rotation
			};
		}
	}
}
