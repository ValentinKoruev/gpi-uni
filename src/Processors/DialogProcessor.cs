using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на диалога.
	/// </summary>
	public class DialogProcessor : DisplayProcessor
	{
		#region Constructor
		
		public DialogProcessor()
		{
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Избран елемент.
		/// </summary>
		private List<Shape> selection = new List<Shape>();
		public List<Shape> Selection {
			get { return selection; }
			set { selection = value; }
		}
		
		/// <summary>
		/// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
		/// </summary>
		private bool isDragging;
		public bool IsDragging {
			get { return isDragging; }
			set { isDragging = value; }
		}
		
		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		private PointF lastLocation;
		public PointF LastLocation {
			get { return lastLocation; }
			set { lastLocation = value; }
		}
		
		#endregion
		
		/// <summary>
		/// Добавя примитив - правоъгълник на произволно място върху клиентската област.
		/// </summary>
		public void AddRandomRectangle()
		{
			Random rnd = new Random();
			int x = rnd.Next(100,1000);
			int y = rnd.Next(100,600);
			
			RectangleShape rect = new RectangleShape(new Rectangle(x,y,100,200));
			rect.FillColor = Color.White;
			rect.StrokeColor = Color.Black;

			ShapeList.AddLast(rect);
		}


		/// <summary>
		/// Добавя примитив - елипса на произволно място върху клиентската област.
		/// </summary>
		public void AddRandomEllipse()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			EllipseShape ellipse = new EllipseShape(new Rectangle(x, y, 100, 200));
			ellipse.FillColor = Color.White;
			ellipse.StrokeColor = Color.Black;

			ShapeList.AddLast(ellipse);
		}

		/// <summary>
		/// Добавя примитив - квадрат на произволно място върху клиентската област.
		/// </summary>
		public void AddRandomSquare()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			RectangleShape rect = new RectangleShape(new Rectangle(x, y, 100, 100));
			rect.FillColor = Color.White;
			rect.StrokeColor = Color.Black;

			ShapeList.AddLast(rect);
		}

		/// <summary>
		/// Проверява дали дадена точка е в елемента.
		/// Обхожда в ред обратен на визуализацията с цел намиране на
		/// "най-горния" елемент т.е. този който виждаме под мишката.
		/// </summary>
		/// <param name="point">Указана точка</param>
		/// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
		public Shape ContainsPoint(PointF point)
		{
			List<Shape> tempList = ShapeList.ToList();
			for (int i = ShapeList.Count - 1; i >= 0; i--){
				if (tempList[i].Contains(point)){
					return tempList[i];
				}	
			}
			return null;
		}
		
		/// <summary>
		/// Транслация на избраният елемент на вектор определен от <paramref name="p">p</paramref>
		/// </summary>
		/// <param name="p">Вектор на транслация.</param>
		public void TranslateTo(PointF p)
		{
			foreach(Shape item in selection)
			{
				TranslateToGroup(item, p);
				
				item.Location = new PointF(item.Location.X + p.X - lastLocation.X, item.Location.Y + p.Y - lastLocation.Y);
			}
			lastLocation = p;
		}

		/// <summary>
		/// Транслация на елемент от тип група <paramref name="item">item</paramref> с вектор определен от <paramref name="p">p</paramref>.
		/// Ако елемента не е от тип група, метода не се изпълнява.
		/// </summary>
		/// <param name="item">Елемент за проверка от тип група.</param>
		/// <param name="p">Вектор на транслация.</param>
		private void TranslateToGroup(Shape item, PointF p)
		{
			if (item.GetType() == typeof(GroupShape))
			{
				GroupShape group = (GroupShape)item;
				foreach (Shape groupItem in group.SubShapes)
				{
					if(groupItem.GetType() == typeof(GroupShape))
					{
						TranslateToGroup(groupItem, p);
					}
					groupItem.Location = new PointF(groupItem.Location.X + p.X - lastLocation.X, groupItem.Location.Y + p.Y - lastLocation.Y);
				}
			}
		}

		public void ChangeFillColor(Color color)
		{
			foreach (Shape shape in Selection)
			{
				ChangeFillColorIfGroup(shape, color);
				shape.FillColor = color;
			}
		}
		public void ChangeFillColorIfGroup(Shape shape, Color color)
		{
			if (shape.GetType() == typeof(GroupShape))
			{
				GroupShape group = (GroupShape)shape;
				foreach (Shape groupItem in group.SubShapes)
				{
					ChangeFillColorIfGroup(groupItem, color);
					groupItem.FillColor = color;
				}
			}
		}

		public void ChangeStrokeColor(Color color)
		{
			foreach (Shape shape in Selection)
			{
				ChangeStrokeColorIfGroup(shape, color);
				shape.StrokeColor = color;
			}
		}
		public void ChangeStrokeColorIfGroup(Shape shape, Color color)
		{
			if (shape.GetType() == typeof(GroupShape))
			{
				GroupShape group = (GroupShape)shape;
				foreach (Shape groupItem in group.SubShapes)
				{
					ChangeStrokeColorIfGroup(groupItem, color);
					groupItem.StrokeColor = color;
				}
			}
		}

		/// <summary>
		/// Смяна на транспарентност <paramref name="transparency">transparency</paramref> на елемент <paramref name="shape">shape</paramref>
		/// </summary>
		/// <param name="transparency">Ниво на прозрачност.</param>
		/// <param name="shape">Фигурата за промяна.</param>
		public void ChangeTransparency(byte transparency, Shape shape)
		{
			if (shape.GetType() == typeof(GroupShape))
			{
				GroupShape group = (GroupShape)shape;
				foreach (Shape groupItem in group.SubShapes)
				{
					ChangeTransparency(transparency, groupItem);
				}
			}
			shape.Transparency = transparency;
		}
		/// <summary>
		/// Завъртане на ротация <paramref name="rotation">rotation</paramref> на елемент <paramref name="shape">shape</paramref>
		/// </summary>
		/// <param name="angle">Градуси за добавяне/изваждане.</param>
		/// <param name="shape">Фигурата за промяна.</param>
		public void ChangeRotation(float angle, Shape shape)
		{
			if (shape.GetType() == typeof(GroupShape))
			{
				GroupShape group = (GroupShape)shape;
				foreach (Shape groupItem in group.SubShapes)
				{
					ChangeRotation(angle, groupItem);
				}
			}
			shape.Rotation += angle;
		}

		public void ChangeScale(float scale, Shape shape)
		{
			if (shape.GetType() == typeof(GroupShape))
			{
				GroupShape group = (GroupShape)shape;
				foreach (Shape groupItem in group.SubShapes)
				{
					groupItem.Resize(scale);
				}
			}
			shape.Resize(scale);
		}
		public void AddGroupFromSelection()
		{
			List<Shape> shapesToGroup = new List<Shape>();
			foreach (Shape item in ShapeList)
			{
				if (Selection.Contains(item))
				{
					shapesToGroup.Add(item);
				}
			}

			GroupShape groupShape = new GroupShape(shapesToGroup);

			foreach(Shape item in selection)
			{
				ShapeList.Remove(item);
			}

			ShapeList.AddLast(groupShape);
			selection.Clear();
		}

		public void UngroupFromSelection()
		{
			foreach(GroupShape groupShape in selection)
			{
				ShapeList.Remove(groupShape);
				foreach(Shape shape in groupShape.SubShapes)
				{
					ShapeList.AddLast(shape);
				}
			}

			selection.Clear();
		}

		public void CopySelection()
		{
			if (selection.Count == 0)
				return;

			List<Shape> copiedShapes = new List<Shape>();
			List<Shape> shapesToBeCopied = new List<Shape>();

			foreach(Shape shape in ShapeList)
			{
				if(selection.Contains(shape)) shapesToBeCopied.Add(shape);
			}

			foreach (Shape shape in shapesToBeCopied)
			{
				Shape copiedShape = shape.Clone(); 
				copiedShape.Offset(10, 10); 
				copiedShapes.Add(copiedShape);
				ShapeList.AddLast(copiedShape);
			}

			selection.Clear();
			selection.AddRange(copiedShapes);
		}

		public void DeleteSelection()
		{
			foreach (Shape item in selection)
			{
				ShapeList.Remove(item);
			}
			selection.Clear();
		}

		public enum ModelFileType
		{
			BIN,
			XML,
			JSON,
			UNSUPPORTED
		}

		public ModelFileType FindFileType(string filePath)
		{
			ModelFileType type = ModelFileType.UNSUPPORTED;
			switch(Path.GetExtension(filePath))
			{
				case ".bin":
				{
					type = ModelFileType.BIN;
					break;
				}
				case ".xml":
				{
					type = ModelFileType.XML;
					break;
				}
				case ".json":
				{
					type = ModelFileType.JSON;
					break;
				}
			}
			return type;
		}

		public void SaveDrawing(string filePath)
		{
			switch(FindFileType(filePath))
			{
				case ModelFileType.BIN:
				{
					using (FileStream fs = new FileStream(filePath, FileMode.Create))
					{
						BinaryFormatter formatter = new BinaryFormatter();
						formatter.Serialize(fs, ShapeList);
					}
					break;
				}
				case ModelFileType.XML:
				{
					string xml = SerializeXml(ShapeList.ToArray());

					File.WriteAllText(filePath, xml);
					break;
				}
				default:
				{
					throw new Exception("File type not supported.");
				}
			}
		}

		public void LoadDrawing(string filePath) 
		{
		}

		public static string SerializeXml(object obj)
		{
			Type[] extraTypes = new Type[]
			{
				typeof(RectangleShape),
				typeof(EllipseShape),
				typeof(GroupShape)
			};
			XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType(), extraTypes);
			using (StringWriter stringWriter = new StringWriter())
			{
				xmlSerializer.Serialize(stringWriter, obj);
				return stringWriter.ToString();
			}
		}
	}
}
