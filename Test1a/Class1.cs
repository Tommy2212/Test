using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using System.Drawing;

namespace TestGroupName
{

    public class Collect_Nhay_Num : CodeActivity
    {
        [Category("Array_Of_JO")]
        public InArgument<string[]> Name { get; set; }
        [Category("Array_Of_NhayNumber")]
        public OutArgument<int[]> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            Form form1 = new Form();
            Button button1 = new Button();
            button1.Text = "Confirm";
            string[] name = Name.Get(context);
            int count = name.Length;
            TextBox[] Box = new TextBox[count];
            Label[] Label = new Label[count];
            int[] result = new int[count];

            form1.Text = "Collect information for each JO!    ----   Design by: Automation Team.";
            form1.HelpButton = true;
            form1.FormBorderStyle = FormBorderStyle.Fixed3D;
            form1.Width = 600;

            if ((60 + (count * 15))>700)
            {
                form1.Height = 700;
            }
            else
            {
                form1.Height = (140 + ((count/3) * 45));
            }
            

            form1.MaximizeBox = false;
            form1.MinimizeBox = false;
      
            form1.AcceptButton = button1;
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Controls.Add(button1);
            form1.AutoScroll = true;
            button1.DialogResult = DialogResult.OK;

            for (int i = 0; i < count; i++)
            {
                Label[i] = new Label();
                Box[i] = new TextBox();
                Box[i].Width = 30;
                Label[i].Width = 119;
                Label[i].Text = name[i];

                

                if (i%3==0)
                {
                    Label[i].Location = new Point(10, 10 + (i * 15));
                    Box[i].Location = new Point(130, 10 + (i * 15));
                }
                else if (i%3==1)
                {
                    Label[i].Location = new Point(200, -5 + (i * 15));
                    Box[i].Location = new Point(320, -5 + (i * 15));
                }
                else
                {
                    Label[i].Location = new Point(390, -20 + (i * 15));
                    Box[i].Location = new Point(510, -20 + (i * 15));
                }


                form1.Controls.Add(Box[i]);
                form1.Controls.Add(Label[i]);



            }
            button1.Location = new Point(200, 50 + (count * 15));
            form1.ShowDialog();

            if(button1.DialogResult == DialogResult.OK)
            {
                form1.Close();
            }

            for (int i = 0; i < count; i++)
            {

                if (Box[i].Text != "")
                {
                    result[i] = int.Parse(Box[i].Text);
                }
                else
                {
                    result[i] = 0;
                }

            }
            Result.Set(context, result);

        }

    }
}
