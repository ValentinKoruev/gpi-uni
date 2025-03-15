using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
	/// <summary>
	/// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
	/// </summary>
	public abstract class Shape
	{
		#region Constructors
		
		public Shape()
		{
		}
		
		public Shape(RectangleF rect)
		{
			rectangle = rect;
		}
		
		public Shape(Shape shape)
		{
			this.Height = shape.Height;
			this.Width = shape.Width;
			this.Location = shape.Location;
			this.rectangle = shape.rectangle;
			
			this.FillColor =  shape.FillColor;
		}
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Обхващащ правоъгълник на елемента.
		/// </summary>
		private RectangleF rectangle;		
		public virtual RectangleF Rectangle {
			get { return rectangle; }
			set { rectangle = value; }
		}
		
		/// <summary>
		/// Широчина на елемента.
		/// </summary>
		public virtual float Width {
			get { return Rectangle.Width; }
			set { rectangle.Width = value; }
		}
		
		/// <summary>
		/// Височина на елемента.
		/// </summary>
		public virtual float Height {
			get { return Rectangle.Height; }
			set { rectangle.Height = value; }
		}
		
		/// <summary>
		/// Горен ляв ъгъл на елемента.
		/// </summary>
		public virtual PointF Location {
			get { return Rectangle.Location; }
			set { rectangle.Location = value; }
		}
		
		/// <summary>
		/// Цвят на елемента.
		/// </summary>
		private Color fillColor;		
		public virtual Color FillColor {
			get { return fillColor; }
			set { fillColor = value; }
		}

		/// <summary>
		/// Цвят на щрихта.
		/// </summary>
		private Color strokeColor;
		public virtual Color StrokeColor
		{
			get { return strokeColor; }
			set { strokeColor = value; }
		}

		/// <summary>
		/// Транспарентност.
		/// </summary>
		private byte transparency = 255;
		public virtual byte Transparency
		{
			get { return transparency; }
			set { transparency = value; }
		}

		/// <summary>
		/// Транспарентност.
		/// </summary>
		private float rotation = 0f;
		public virtual float Rotation
		{
			get { return rotation; }
			set { rotation = value; }
		}

		/// <summary>
		/// Транспарентност.
		/// </summary>
		private float scale = 1f;
		public virtual float Scale
		{
			get { return scale; }
			set { scale = value; }
		}


		#endregion


			/// <summary>
			/// Проверка дали точка point принадлежи на елемента.
			/// </summary>
			/// <param name="point">Точка</param>
			/// <returns>Връща true, ако точката принадлежи на елемента и
			/// false, ако не пренадлежи</returns>
		public virtual bool Contains(PointF point)
		{
			return Rectangle.Contains(point.X, point.Y);	
		}
		
		/// <summary>
		/// Визуализира елемента.
		/// </summary>
		/// <param name="grfx">Къде да бъде визуализиран елемента.</param>
		public virtual void DrawSelf(Graphics grfx)
		{
			// shape.Rectangle.Inflate(shape.BorderWidth, shape.BorderWidth);
		}


		/// <summary>
		/// Оразмерява елемента.
		/// </summary>
		/// <param name="grfx">Оразмерява елемента.</param>
		public virtual void Resize(float scaleFactor)
		{
			if (scaleFactor <= 0) return;

			float newWidth = Rectangle.Width * scaleFactor;
			float newHeight = Rectangle.Height * scaleFactor;

			float deltaX = (newWidth - Rectangle.Width) / 2;
			float deltaY = (newHeight - Rectangle.Height) / 2;

			Rectangle = new RectangleF(
				Rectangle.X - deltaX,
				Rectangle.Y - deltaY,
				newWidth,
				newHeight
			);
		}

		public abstract Shape Clone();

		public void Offset(float dx, float dy)
		{
			Rectangle = new RectangleF(Rectangle.X + dx, Rectangle.Y + dy, Rectangle.Width, Rectangle.Height);
		}
	}
}
