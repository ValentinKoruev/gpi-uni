using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
				Shape selectedShape = dialogProcessor.ContainsPoint(e.Location);
				if(selectedShape != null)
				{
					if(dialogProcessor.Selection.Contains(selectedShape))
					{
						dialogProcessor.Selection.Remove(selectedShape);
					}
					else
					{
						dialogProcessor.Selection.Add(selectedShape);
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
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection.Count > 0) UpdateStatusBar("Последно действие: Влачене");
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
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
			foreach (Shape item in dialogProcessor.Selection)
			{
				dialogProcessor.ShapeList.Remove(item);
			}
			dialogProcessor.Selection.Clear();
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
	}
}
