using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TriangleFormApp
{
    public class MainForm : Form
    {
        private Button toggleShapeButton;
        private ListBox locationListBox;
        private bool isTriangle = false;
        private Rectangle originalBounds;

        public MainForm()
        {
            this.Text = "Форма с событиями";
            this.Size = new Size(400, 300);
            originalBounds = this.Bounds;

            toggleShapeButton = new Button
            {
                Text = "Сделать форму треугольной",
                Location = new Point(20, 20),
                Size = new Size(200, 30)
            };
            toggleShapeButton.Click += ToggleShapeButton_Click;

            locationListBox = new ListBox
            {
                Location = new Point(20, 70),
                Size = new Size(200, 100)
            };
            locationListBox.Items.Add("Слева");
            locationListBox.Items.Add("По центру");
            locationListBox.Items.Add("Справа");
            locationListBox.SelectedIndexChanged += LocationListBox_SelectedIndexChanged;

            locationListBox.MouseEnter += (s, e) => this.BackColor = Color.LightYellow;
            locationListBox.MouseLeave += (s, e) => this.BackColor = SystemColors.Control;

            this.Controls.Add(toggleShapeButton);
            this.Controls.Add(locationListBox);
        }

        private void ToggleShapeButton_Click(object sender, EventArgs e)
        {
            if (!isTriangle)
            {
                GraphicsPath trianglePath = new GraphicsPath();
                trianglePath.AddPolygon(new Point[]
                {
                    new Point(this.Width / 2, 0),
                    new Point(0, this.Height),
                    new Point(this.Width, this.Height)
                });
                this.Region = new Region(trianglePath);
                toggleShapeButton.Text = "Вернуть форму";
                isTriangle = true;
            }
            else
            {
                this.Region = null;
                toggleShapeButton.Text = "Сделать форму треугольной";
                isTriangle = false;
            }
        }

        private void LocationListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (locationListBox.SelectedIndex)
            {
                case 0: // Слева
                    this.Location = new Point(100, this.Location.Y);
                    break;
                case 1: // Центр
                    this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2, this.Location.Y);
                    break;
                case 2: // Справа
                    this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 100, this.Location.Y);
                    break;
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
