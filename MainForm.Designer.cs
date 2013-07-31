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

namespace RPNCalculator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.expression = new System.Windows.Forms.TextBox();
            this.evaluate = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearStack = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.historyList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.stackList = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.angleUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.degreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // expression
            // 
            this.expression.Location = new System.Drawing.Point(12, 300);
            this.expression.Name = "expression";
            this.expression.Size = new System.Drawing.Size(353, 20);
            this.expression.TabIndex = 0;
            this.expression.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.expression_KeyPress);
            this.expression.KeyUp += new System.Windows.Forms.KeyEventHandler(this.expression_KeyUp);
            // 
            // evaluate
            // 
            this.evaluate.Location = new System.Drawing.Point(371, 300);
            this.evaluate.Name = "evaluate";
            this.evaluate.Size = new System.Drawing.Size(75, 19);
            this.evaluate.TabIndex = 1;
            this.evaluate.Text = "Evaluate";
            this.evaluate.UseVisualStyleBackColor = true;
            this.evaluate.Click += new System.EventHandler(this.evaluate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(455, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearStack,
            this.angleUnitToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.modeToolStripMenuItem.Text = "Settings";
            // 
            // clearStack
            // 
            this.clearStack.Checked = true;
            this.clearStack.CheckOnClick = true;
            this.clearStack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clearStack.Name = "clearStack";
            this.clearStack.Size = new System.Drawing.Size(226, 22);
            this.clearStack.Text = "Clear stack before evaluating";
            this.clearStack.CheckedChanged += new System.EventHandler(this.clearStack_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.historyList);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 267);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // historyList
            // 
            this.historyList.FormattingEnabled = true;
            this.historyList.Location = new System.Drawing.Point(6, 19);
            this.historyList.Name = "historyList";
            this.historyList.Size = new System.Drawing.Size(265, 238);
            this.historyList.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stackList);
            this.groupBox2.Location = new System.Drawing.Point(296, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 120);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stack";
            // 
            // stackList
            // 
            this.stackList.FormattingEnabled = true;
            this.stackList.Location = new System.Drawing.Point(7, 18);
            this.stackList.Name = "stackList";
            this.stackList.Size = new System.Drawing.Size(137, 95);
            this.stackList.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox3);
            this.groupBox3.Location = new System.Drawing.Point(296, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 140);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Variables";
            // 
            // listBox3
            // 
            this.listBox3.Enabled = false;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Items.AddRange(new object[] {
            "NYI"});
            this.listBox3.Location = new System.Drawing.Point(7, 19);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(137, 108);
            this.listBox3.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 329);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(455, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(39, 17);
            this.status.Text = "Ready";
            // 
            // angleUnitToolStripMenuItem
            // 
            this.angleUnitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.radianToolStripMenuItem,
            this.degreeToolStripMenuItem});
            this.angleUnitToolStripMenuItem.Name = "angleUnitToolStripMenuItem";
            this.angleUnitToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.angleUnitToolStripMenuItem.Text = "Angle unit";
            // 
            // radianToolStripMenuItem
            // 
            this.radianToolStripMenuItem.Checked = true;
            this.radianToolStripMenuItem.CheckOnClick = true;
            this.radianToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radianToolStripMenuItem.Name = "radianToolStripMenuItem";
            this.radianToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.radianToolStripMenuItem.Text = "Radian";
            this.radianToolStripMenuItem.Click += new System.EventHandler(this.radianToolStripMenuItem_Click);
            // 
            // degreeToolStripMenuItem
            // 
            this.degreeToolStripMenuItem.CheckOnClick = true;
            this.degreeToolStripMenuItem.Name = "degreeToolStripMenuItem";
            this.degreeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.degreeToolStripMenuItem.Text = "Degree";
            this.degreeToolStripMenuItem.Click += new System.EventHandler(this.degreeToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 351);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.evaluate);
            this.Controls.Add(this.expression);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(471, 390);
            this.MinimumSize = new System.Drawing.Size(471, 390);
            this.Name = "Form1";
            this.Text = "RPN Calculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox expression;
        private System.Windows.Forms.Button evaluate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox historyList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox stackList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearStack;
        private System.Windows.Forms.ToolStripMenuItem angleUnitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem degreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

