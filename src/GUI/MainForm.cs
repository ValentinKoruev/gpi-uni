using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//

			this.MouseWheel += new MouseEventHandler(this.mainform_MouseWheel);
			KeyPreview = true;
		}

		public static int Clamp(int value, int min, int max)
		{
			return (value < min) ? min : (value > max) ? max : value;
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}
		
		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();

			UpdateStatusBar("Последно действие: Рисуване на правоъгълник");
			
			viewPort.Invalidate();
		}

		void UpdateStatusBar(string text)
		{
			statusBar.Items[0].Text = text;
		}

		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (pickUpSpeedButton.Checked) {

				if (e.Button == System.Windows.Forms.MouseButtons.Left)
				{
					
				}
				if (e.Button == System.Windows.Forms.MouseButtons.Right)
				{
					Shape selectedShape = dialogProcessor.ContainsPoint(e.Location);
					if (selectedShape != null)
					{
						if (dialogProcessor.Selection.Contains(selectedShape))
						{
							dialogProcessor.Selection.Remove(selectedShape);
						}
						else
						{
							dialogProcessor.Selection.Add(selectedShape);
						}
					}
				}
				

				UpdateStatusBar("Последно действие: Селекция на примитив");
				dialogProcessor.IsDragging = true;
				dialogProcessor.LastLocation = e.Location;
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				if (dialogProcessor.IsDragging)
				{
					if (dialogProcessor.Selection.Count > 0) UpdateStatusBar("Последно действие: Влачене");
					dialogProcessor.TranslateTo(e.Location);
					viewPort.Invalidate();
				}
			}
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

		private void DrawEllipseButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomEllipse();

			UpdateStatusBar("Последно действие: Рисуване на елипса");

			viewPort.Invalidate();
		}

		private void DrawTriangleButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomTriangle();
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Рисуване на триъгълник");
		}

		private void DrawCircleButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomCircle();
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Рисуване на кръг");
		}

		private void changeFillColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(colorDialog1.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.ChangeFillColor(colorDialog1.Color);
				viewPort.Invalidate();
			}

			UpdateStatusBar("Последно действие: Смяна на цвят на запълване");
		}

		private void changeStrokeColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.ChangeStrokeColor(colorDialog1.Color);
				viewPort.Invalidate();
			}
			UpdateStatusBar("Последно действие: Смяна на цвят на щрих");
		}

		private void deleteSelectionButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.DeleteSelection();
			viewPort.Invalidate();

			UpdateStatusBar("Последно действие: Изтриване на селекция");
		}

		private void changeSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void bringToBackButton_Click(object sender, EventArgs e)
		{
			List<Shape> shapesToBack = new List<Shape>();
			for (int i = dialogProcessor.ShapeList.Count - 1; i >= 0; i--)
			{
				Shape item = dialogProcessor.ShapeList.ToArray()[i];
				if (dialogProcessor.Selection.Contains(item))
				{
					shapesToBack.Add(item);
				}
			}

			foreach (Shape item in shapesToBack)
			{
				dialogProcessor.ShapeList.Remove(item);
				dialogProcessor.ShapeList.AddFirst(item);
			}
			viewPort.Invalidate();

			UpdateStatusBar("Последно действие: Преместване на селекция отдолу");
		}

		private void bringToFrontButton_Click(object sender, EventArgs e)
		{
			List<Shape> shapesToFront = new List<Shape>();
			foreach (Shape item in dialogProcessor.ShapeList)
			{
				if (dialogProcessor.Selection.Contains(item))
				{
					shapesToFront.Add(item);
				}
			}

			foreach (Shape item in shapesToFront)
			{
				dialogProcessor.ShapeList.Remove(item);
				dialogProcessor.ShapeList.AddLast(item);
			}
			viewPort.Invalidate();

			UpdateStatusBar("Последно действие: Преместване на селекция отгоре");
		}

		#region ChangeTransparencyButtonEvents
		private void changeTransparency_0_Click(object sender, EventArgs e)
		{
			foreach (Shape item in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeTransparency(0, item);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Смяна на транспарентност");
		}

		private void changeTransparency_25_Click(object sender, EventArgs e)
		{
			foreach (Shape item in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeTransparency(64, item);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Смяна на транспарентност");
		}

		private void changeTransparency_50_Click(object sender, EventArgs e)
		{
			foreach (Shape item in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeTransparency(128, item);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Смяна на транспарентност");
		}

		private void changeTransparency_75_Click(object sender, EventArgs e)
		{
			foreach (Shape item in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeTransparency(191, item);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Смяна на транспарентност");
		}

		private void changeTransparency_100_Click(object sender, EventArgs e)
		{
			foreach (Shape item in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeTransparency(255, item);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Смяна на транспарентност");
		}
		#endregion

		#region ChangeRotationButtonEvents
		private void rotation_30_right_Click(object sender, EventArgs e)
		{
			foreach (Shape item in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeRotation(30.0f, item);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Завъртане на селекция");
		}

		private void rotation_60_right_Click(object sender, EventArgs e)
		{
			foreach (Shape item in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeRotation(60.0f, item);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Завъртане на селекция");
		}

		private void rotation_90_right_Click(object sender, EventArgs e)
		{
			foreach (Shape item in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeRotation(90.0f, item);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Завъртане на селекция");
		}

		private void rotation_30_left_Click(object sender, EventArgs e)
		{
			foreach (Shape item in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeRotation(-30.0f, item);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Завъртане на селекция");
		}

		private void rotation_60_left_Click(object sender, EventArgs e)
		{
			foreach (Shape item in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeRotation(-60.0f, item);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Завъртане на селекция");
		}

		private void rotation_90_left_Click(object sender, EventArgs e)
		{
			foreach (Shape item in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeRotation(-90.0f, item);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Завъртане на селекция");
		}
		#endregion

		private void groupSelection_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddGroupFromSelection();
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Създаване на група");
		}

		private void ungroupElementsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.UngroupFromSelection();
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Разгрупиране на група");
		}

		private void DrawSquareButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomSquare();
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Рисуване на квадрат");
		}

		#region ChangeScaleButtons
		private void scale_2_Click(object sender, EventArgs e)
		{
			foreach(Shape shape in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeScale(2f, shape);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Смяна на мащаб");
		}
		private void scale_1_5_Click(object sender, EventArgs e)
		{
			foreach (Shape shape in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeScale(1.5f, shape);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Смяна на мащаб");
		}

		private void scale_1_Click(object sender, EventArgs e)
		{
			foreach (Shape shape in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeScale(1f, shape);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Смяна на мащаб");
		}

		private void scale_0_5_Click(object sender, EventArgs e)
		{
			foreach (Shape shape in dialogProcessor.Selection)
			{
				dialogProcessor.ChangeScale(0.5f, shape);
			}
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Смяна на мащаб");
		}
		#endregion
		private void mainform_MouseWheel(object sender, MouseEventArgs e)
		{
			foreach (Shape shape in dialogProcessor.Selection)
			{
				if (ModifierKeys.Equals(Keys.Control | Keys.Shift))
				{
					int transparencyFactor = (e.Delta > 0) ? 10 : -10;
					int transparency = Clamp(shape.Transparency + transparencyFactor, 0, 255);
					dialogProcessor.ChangeTransparency((byte)transparency, shape);
					UpdateStatusBar("Последно действие: Смяна на транспарентност");
				}
				else if (ModifierKeys.Equals(Keys.Control))
				{
					float scale = (e.Delta > 0) ? 1.1f : 0.9f;
					dialogProcessor.ChangeScale(scale, shape);
					UpdateStatusBar("Последно действие: Смяна на мащаб");
				}
				else if (ModifierKeys.Equals(Keys.Shift))
				{
					float rotation = (e.Delta > 0) ? 5f : -5f;
					dialogProcessor.ChangeRotation(rotation, shape);
					UpdateStatusBar("Последно действие: Завъртане на селекция");
				}
			}

			viewPort.Invalidate();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if (e.Control && e.KeyCode == Keys.C)
			{
				dialogProcessor.CopySelection();
				UpdateStatusBar("Последно действие: Копиране на селекция");
				viewPort.Invalidate(); 
			}
			else if (e.KeyCode == Keys.Delete) 
			{
				dialogProcessor.DeleteSelection();
				UpdateStatusBar("Последно действие: Изтриване на селекция");
				viewPort.Invalidate();
			}
		}

		private void SaveImageModelButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog()
			{
				Title = "Load Save File",
				Filter = "JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml|Binary Files (*.bin)|*.bin|All Files (*.*)|*.*",
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
			}; 

			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					dialogProcessor.SaveDrawing(saveFileDialog.FileName);


					UpdateStatusBar("Последно действие: Запазване на модел");
					MessageBox.Show("Файлът беше запазен успешно!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch(Exception ex)
				{
					MessageBox.Show("Грешка при зареждане: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}	
		}

		private void LoadImageModelButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Title = "Load Save File",
				Filter = "JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml|Binary Files (*.bin)|*.bin|All Files (*.*)|*.*",
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
			};

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					dialogProcessor.LoadDrawing(openFileDialog.FileName);

					UpdateStatusBar("Последно действие: Зареждане на модел");
					viewPort.Invalidate();
					MessageBox.Show("Файлът беше успешно зареден!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Грешка при зареждане: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void ClearButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.ShapeList.Clear();
			dialogProcessor.Selection.Clear();
			viewPort.Invalidate();
			UpdateStatusBar("Последно действие: Изтриване на всички елементи");
		}

		private void viewPort_Load(object sender, EventArgs e)
		{

		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string helpText = "[Markup tool]\n" +
				"Left Click - Move selected elements\n" +
				"Right Click - Select element\n" +
				"[Tranform]\n" +
				"Ctrl + Scroll - Resize\n" +
				"Shift + Scroll - Rotate\n" +
				"Ctrl + Shift + Scroll - Transparency\n" +
				"[Element manipulation]\n" +
				"Ctrl + C - Copy selection\n" +
				"Delete - Delete selection\n";
			MessageBox.Show(helpText);
		}

		private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.Selection.Clear();
			UpdateStatusBar("Последно действие: Деселектиране на всички елементи");
		}

		private void CopySelectionButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.CopySelection();
			UpdateStatusBar("Последно действие: Копиране на селекция");
			viewPort.Invalidate();
		}
	}
}
