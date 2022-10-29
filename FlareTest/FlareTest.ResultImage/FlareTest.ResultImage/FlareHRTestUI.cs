using System.Windows.Forms;
using FlareTest.Model;
using FlareTest.Operations;

namespace FlareTest.ResultImage
{
    public partial class FlareHRTestUI : Form
    {
        Grid grid = new Grid();
        List<Model.Rectangle> rects = new List<Model.Rectangle>();
        ShapesHandler shapesHandler;
        private Random rnd = new Random();
        public FlareHRTestUI()
        {
            InitializeComponent();
        }

        private void ShowRectangle_Click(object sender, EventArgs e)
        {

            ReadAllData();

            shapesHandler = new ShapesHandler(grid, rects);
            labelResult.Text = shapesHandler.ValidateGrid();
            //drawing
            Pen selPen = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            DarwReactanlgeCustom(selPen, 0, 0, grid.Width, grid.Height, Color.Azure);
            foreach (Model.Rectangle rect in rects)
            {
                Color stroke = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                selPen = new Pen(stroke);
                DarwReactanlgeCustom(selPen, rect.X, rect.Y, rect.Width, rect.Height, stroke);
            }
        }
        private void DarwReactanlgeCustom(Pen DrawPen, int X, int Y, int Width, int Height, Color FilllColor)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush sb = new SolidBrush(FilllColor);
            g.DrawRectangle(DrawPen, X * 7, Y * 7, Width * 7, Height * 7);
            g.FillRectangle(sb, X * 7, Y * 7, Width * 7, Height * 7);
            g.Dispose();
        }
       
        private void textBoxAny_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                  (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }
        private void ReadAllData()
        {
            grid = new Grid();
            rects = new List<Model.Rectangle>();
            grid.X = 0;
            grid.Y = 0;
            grid.Height = (int)numericUpDownHeight.Value;
            grid.Width = (int)numericUpDownWidth.Value;

            rects.Add(new Model.Rectangle()
            {
                X = Convert.ToInt32(textBoxXRect1.Text == "" ? "0" : textBoxXRect1.Text),
                Y = Convert.ToInt32(textBoxYRect1.Text == "" ? "0" : textBoxYRect1.Text),
                Height = Convert.ToInt32(textBoxHeightRect1.Text == "" ? "0" : textBoxHeightRect1.Text),
                Width = Convert.ToInt32(textBoxWidthRect1.Text == "" ? "0" : textBoxWidthRect1.Text)
            });
            rects.Add(new Model.Rectangle()
            {
                X = Convert.ToInt32(textBoxXRect2.Text == "" ? "0" : textBoxXRect2.Text),
                Y = Convert.ToInt32(textBoxYRect2.Text == "" ? "0" : textBoxYRect2.Text),
                Height = Convert.ToInt32(textBoxHeightRect2.Text == "" ? "0" : textBoxHeightRect2.Text),
                Width = Convert.ToInt32(textBoxWidthRect2.Text == "" ? "0" : textBoxWidthRect2.Text)
            });
            rects.Add(new Model.Rectangle()
            {
                X = Convert.ToInt32(textBoxXRect3.Text == "" ? "0" : textBoxXRect3.Text),
                Y = Convert.ToInt32(textBoxYRect3.Text == "" ? "0" : textBoxYRect3.Text),
                Height = Convert.ToInt32(textBoxHeightRect3.Text == "" ? "0" : textBoxHeightRect3.Text),
                Width = Convert.ToInt32(textBoxWidthRect3.Text == "" ? "0" : textBoxWidthRect3.Text)
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDownHeight.Value = 25;
            numericUpDownWidth.Value = 25;
            textBoxXRect1.Text = "1";
            textBoxYRect1.Text = "1";
            textBoxHeightRect1.Text = "5";
            textBoxWidthRect1.Text = "5";
            textBoxXRect2.Text = "7";
            textBoxYRect2.Text = "7";
            textBoxHeightRect2.Text = "3";
            textBoxWidthRect2.Text = "3";
            textBoxXRect3.Text = "12";
            textBoxYRect3.Text = "12";
            textBoxHeightRect3.Text = "9";
            textBoxWidthRect3.Text = "9";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDownHeight.Value = 25;
            numericUpDownWidth.Value = 25;
            textBoxXRect1.Text = "1";
            textBoxYRect1.Text = "1";
            textBoxHeightRect1.Text = "5";
            textBoxWidthRect1.Text = "55";
            textBoxXRect2.Text = "7";
            textBoxYRect2.Text = "7";
            textBoxHeightRect2.Text = "3";
            textBoxWidthRect2.Text = "3";
            textBoxXRect3.Text = "12";
            textBoxYRect3.Text = "12";
            textBoxHeightRect3.Text = "9";
            textBoxWidthRect3.Text = "9";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDownHeight.Value = 25;
            numericUpDownWidth.Value = 25;
            textBoxXRect1.Text = "1";
            textBoxYRect1.Text = "1";
            textBoxHeightRect1.Text = "5";
            textBoxWidthRect1.Text = "5";
            textBoxXRect2.Text = "3";
            textBoxYRect2.Text = "2";
            textBoxHeightRect2.Text = "10";
            textBoxWidthRect2.Text = "10";
            textBoxXRect3.Text = "12";
            textBoxYRect3.Text = "12";
            textBoxHeightRect3.Text = "9";
            textBoxWidthRect3.Text = "9";
        }
    }

}