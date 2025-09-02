using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());
        }
    }

    public class CalculatorForm : Form
    {
        TextBox input1, input2;
        Button addButton, subtractButton, multiplyButton, divideButton;
        Label resultLabel;

        public CalculatorForm()
        {
            // Поля ввода
            input1 = new TextBox { Location = new System.Drawing.Point(20, 20), Width = 100 };
            input2 = new TextBox { Location = new System.Drawing.Point(140, 20), Width = 100 };

            // Кнопки операций
            addButton = new Button { Text = "Сложить", Location = new System.Drawing.Point(20, 60) };
            subtractButton = new Button { Text = "Вычесть", Location = new System.Drawing.Point(120, 60) };
            multiplyButton = new Button { Text = "Умножить", Location = new System.Drawing.Point(220, 60) };
            divideButton = new Button { Text = "Делить", Location = new System.Drawing.Point(320, 60) };

            // Метка результата
            resultLabel = new Label { Location = new System.Drawing.Point(20, 100), Width = 300 };

            // Обработчики событий
            addButton.Click += (sender, e) => Calculate((a, b) => a + b, "+");
            subtractButton.Click += (sender, e) => Calculate((a, b) => a - b, "-");
            multiplyButton.Click += (sender, e) => Calculate((a, b) => a * b, "×");
            divideButton.Click += (sender, e) =>
            {
                if (double.TryParse(input1.Text, out double a) && double.TryParse(input2.Text, out double b))
                {
                    if (b == 0)
                        resultLabel.Text = "Ошибка: деление на ноль";
                    else
                        resultLabel.Text = $"Результат: {a} ÷ {b} = {a / b}";
                }
                else
                {
                    resultLabel.Text = "Ошибка ввода";
                }
            };

            // Добавление элементов на форму
            Controls.Add(input1);
            Controls.Add(input2);
            Controls.Add(addButton);
            Controls.Add(subtractButton);
            Controls.Add(multiplyButton);
            Controls.Add(divideButton);
            Controls.Add(resultLabel);
        }

        private void Calculate(Func<double, double, double> operation, string symbol)
        {
            if (double.TryParse(input1.Text, out double a) && double.TryParse(input2.Text, out double b))
            {
                double result = operation(a, b);
                resultLabel.Text = $"Результат: {a} {symbol} {b} = {result}";
            }
            else
            {
                resultLabel.Text = "Ошибка ввода";
            }
        }
    }
}

