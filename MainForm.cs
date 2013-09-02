/*
    Copyright (C) 2013 Bartosz Kazmierczak
    
    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPNCalculator
{
    public partial class MainForm : Form
    {
        private Stack<double> stack = new Stack<double>();
        private int positionInHistory = -1;
        private String lastExpression = "";

        public MainForm()
        {
            InitializeComponent();
            if (RPNCalculator.Properties.Settings.Default.AngleUnit == (byte)AngleUnit.Degree)
            {
                degreeToolStripMenuItem.Checked = true;
                radianToolStripMenuItem.Checked = false;
            }
            clearStack.Checked = RPNCalculator.Properties.Settings.Default.ClearStack;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void evaluate_Click(object sender, EventArgs e)
        {
            historyList.Items.Add(expression.Text);
            stackList.Items.Clear();
            if (RPNCalculator.Properties.Settings.Default.ClearStack)
                stack.Clear();
            try
            {
                CompiledExpression exp = RPNEvaluator.Compile(expression.Text);
                exp.Execute(stack);
                //RPNEvaluator.Evaluate(expression.Text, stack);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.GetType().Name + " : " + ex.Message);
            }
            foreach (double element in stack)
            {
                stackList.Items.Add(element);
            }
        }

        private void radianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPNCalculator.Properties.Settings.Default.AngleUnit = (byte)AngleUnit.Radian;
            degreeToolStripMenuItem.Checked = false;
        }

        private void degreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPNCalculator.Properties.Settings.Default.AngleUnit = (byte)AngleUnit.Degree;
            radianToolStripMenuItem.Checked = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void clearStack_CheckedChanged(object sender, EventArgs e)
        {
            RPNCalculator.Properties.Settings.Default.ClearStack = clearStack.Checked;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(
                "RPN Calculator\n" +
                //"Preview 1\n\n" +
                
                "Copyright (C) 2013 Bartosz Kaźmierczak\n\n" +
                
                "This program is free software; you can redistribute it and/or modify\n" +
                "it under the terms of the GNU General Public License as published by\n" +
                "the Free Software Foundation; either version 2 of the License, or\n" +
                "(at your option) any later version.\n\n"+

                "This program is distributed in the hope that it will be useful,\n" +
                "but WITHOUT ANY WARRANTY; without even the implied warranty of\n" +
                "MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the\n" +
                "GNU General Public License for more details.\n\n" +

                "You should have received a copy of the GNU General Public License\n" +
                "along with this program; if not, write to the Free Software\n" +
                "Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA", "About RPN Calculator");
        }

        private void expression_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                evaluate.PerformClick();
            }
        }

        private void expression_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (positionInHistory - 1 < -1)
                    return;
                positionInHistory--;
                if (positionInHistory == -1)
                    expression.Text = lastExpression;
                else
                    expression.Text = (String)historyList.Items[historyList.Items.Count - 1 - positionInHistory];
                
            }
            if (e.KeyCode == Keys.Up)
            {
                if (positionInHistory == -1 && historyList.Items.Count == 0)
                    return;
                if (historyList.Items.Count - positionInHistory <= 1)
                    return;
                positionInHistory++;
                if (positionInHistory == 0)
                    lastExpression = expression.Text;
                expression.Text = (String)historyList.Items[historyList.Items.Count - 1 - positionInHistory];
            }
        }

        private void plotFunctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FunctionPlotter plotter = new FunctionPlotter();
            Stack<double> functionStack = new Stack<double>();

            try
            {
                CompiledExpression exp = plotter.expression = RPNEvaluator.Compile(expression.Text);
                //plotter.expression = exp;
                
                for (decimal x = -25; x <= 25; x += (decimal)0.1)
                {
                    RPNEvaluator.x.Value = (double)x;
                    exp.Execute(functionStack);
                    double y = functionStack.Pop();
                    if (Double.IsInfinity(y) || Double.IsNaN(y)) continue;
                    plotter.points.Add((double)x, y);
                    functionStack.Clear();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.GetType().Name + " : " + ex.Message);
            }
            foreach (double element in stack)
            {
                stackList.Items.Add(element);
            }
            plotter.Show();
        }
    }
}
