using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	[Serializable]
	public class GroupShape : Shape
	{
		#region Constructor

		public GroupShape() { }
		public GroupShape(RectangleF rect) : base(rect)
		{
		}

		public GroupShape(GroupShape group) : base(group)
		{
		}

		public GroupShape(IEnumerable<Shape> shapes) : base()
		{
			SubShapes = shapes.ToList();

			if(SubShapes.Count > 0)
			{
				float groupX = SubShapes[0].Rectangle.X;
				float groupY = SubShapes[0].Rectangle.Y;
				float groupWidth = SubShapes[0].Rectangle.Width;
				float groupHeight = SubShapes[0].Rectangle.Height;



				Rectangle = new RectangleF(groupX, groupY, groupWidth, groupHeight);
			}
		}

		public List<Shape> SubShapes = new List<Shape>();


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
			foreach(Shape shape in SubShapes)
			{
				if(shape.Contains(point)) return true;
			}

			return false;
		}

		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			foreach(Shape shape in SubShapes)
			{
				shape.DrawSelf(grfx);
			}

			// grfx.DrawRectangle(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
		}

		public override Shape Clone()
		{
			return new GroupShape()
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
				SubShapes = new List<Shape>(this.SubShapes)
			};
		}
	}
}
