﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 石油专家管理系统
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            //this.Close();
            form.Show();
            //this.Dispose();
        }
    }
}
