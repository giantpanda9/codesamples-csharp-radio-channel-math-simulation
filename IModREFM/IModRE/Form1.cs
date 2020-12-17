using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IModRE
{
    public partial class Form1 : Form
    {
        public int DelAllAndEnd;
        public Form1()
        {
            InitializeComponent();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IModRE: Radio-path building simulation\nv1.1 AM-FM Edition\nAuthor:Chegodaev N.I.\nPostraduate\nAcademy IMSIT", "About...");
        }

        private void simulateToolStripMenuItem_Click(object sender, EventArgs e)
        {
  
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (DelAllAndEnd == 1)
            {
                e.Graphics.Clear(Color.White);
                goto Finish;
            }
            PointF[] Cospoints1=new PointF[1000];
            PointF[] Cospoints2 = new PointF[1000];
            PointF[] CospointsAll = new PointF[1000];
            Double OmegaF1,OmegaF2, Um1,Um2, PShift,tmp1,tmp2,Step1,Step2;
            float xCoord1,xCoord2,yCoord1,yCoord2;
            tmp1 = Convert.ToDouble(textBox5.Text) / 1000;
            OmegaF1 = (2 * Math.PI) / tmp1;
            tmp2 = Convert.ToDouble(textBox3.Text) / 1000;
            OmegaF2 = (2 * Math.PI) / tmp2;
            Step1 = Convert.ToDouble(textBox8.Text);
            Step2 = Convert.ToDouble(textBox9.Text);
            Um1 = Convert.ToDouble(textBox6.Text);
            Um2 = Convert.ToDouble(textBox7.Text);
            PShift = Convert.ToDouble(textBox4.Text);
            Pen greenPen = new Pen(Color.Green, 1);
            Pen redPen = new Pen(Color.Red, 1);
            if (toolStripComboBox1.Text=="False")
            {
            for (int i = Convert.ToInt32(textBox1.Text); i < Convert.ToInt32(textBox2.Text); i++)
            {
                xCoord1 = (float)(i*Step1);
                yCoord1 = (float)(Um1 * Math.Cos(OmegaF1 * xCoord1 + 0));
                xCoord2 = (float)(i * Step2);
                yCoord2=(float)(Um2 * Math.Cos(OmegaF2 * xCoord2 + PShift));
                PointF tmpPoint1=new PointF(xCoord1,yCoord1+50.0F);
                Cospoints1[i] = tmpPoint1;
                PointF tmpPoint2=new PointF(xCoord2,yCoord2+50.0F);
                Cospoints2[i] = tmpPoint2;

            }
            e.Graphics.DrawCurve(greenPen, Cospoints1);
            e.Graphics.DrawCurve(redPen, Cospoints2);
            }

            if (toolStripComboBox1.Text == "True")
            {
                for (int i = Convert.ToInt32(textBox1.Text); i < Convert.ToInt32(textBox2.Text); i++)
                {
                    xCoord1 = (float)(i * Step1);
                    yCoord1 = (float)(Um1 * Math.Cos(OmegaF1 * xCoord1 + PShift));
                    xCoord2 = (float)(i * Step2);
                    yCoord2 = (float)(Um2 * Math.Cos(OmegaF2 * xCoord2 + 2*PShift));
                    
                    yCoord1 = yCoord1 + yCoord2;
                    PointF tmpPoint1 = new PointF(xCoord1, yCoord1 + 50.0F);
                    CospointsAll[i] = tmpPoint1;
             

                }
               

                e.Graphics.DrawCurve(greenPen, CospointsAll);
                //e.Graphics.DrawCurve(redPen, Cospoints2);
            }
        Finish: ; 
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (DelAllAndEnd == 1)
            {
                e.Graphics.Clear(Color.White);
                goto Finish;
            }
            PointF[] CospointsM = new PointF[1000];
            Double OmegaF1, OmegaF2, OmegaM, Um1, Um2, UmA, PShift, tmp1, tmp2, Step1, Step2, StepM, mFactor, FCarrier, YDelta, XScale, YScale;
            float xCoord1, xCoord2, yCoord1, yCoord2,xCoordM,yCoordM;
            tmp1 = Convert.ToDouble(textBox5.Text) / 1000;
            OmegaF1 = (2 * Math.PI) / tmp1;
            tmp2 = Convert.ToDouble(textBox3.Text) / 1000;
            OmegaF2 = (2 * Math.PI) / tmp2;
            FCarrier = (Convert.ToDouble(textBoxCF.Text)/1000) / 1000;
            OmegaM = (2*Math.PI) / FCarrier;
            Step1 = Convert.ToDouble(textBox8.Text);
            Step2 = Convert.ToDouble(textBox9.Text);
            StepM = Step1;
            if (Step1 > Step2)
            {
                StepM = Step1;
            }
            if (Step1 < Step2)
            {
                StepM = Step2;
            }
            if (Step1 == Step2)
            {
                StepM = Step1;
            }
                //StepM = Convert.ToDouble(textBox11.Text);
            Um1 = Convert.ToDouble(textBox6.Text);
            Um2 = Convert.ToDouble(textBox7.Text);
            mFactor = Convert.ToDouble(textBox12.Text);

            UmA = Um1;
            if (Um1 > Um2)
            {
                UmA = Um1;
            }
            if (Um1 < Um2)
            {
                UmA = Um2;
            }
            if (Um1 == Um2)
            {
                UmA = Um1;
            }

            
            PShift = Convert.ToDouble(textBox4.Text);
            YDelta = Convert.ToDouble(textBox11.Text);
            YScale = Convert.ToDouble(textBox10.Text);
            XScale = Convert.ToDouble(textBox13.Text);

            Pen greenPen = new Pen(Color.Green, 1);

            for (int i = Convert.ToInt32(textBox1.Text); i < Convert.ToInt32(textBox2.Text); i++)
            {
                xCoord1 = (float)(i);
                yCoord1 = (float)(Um1 * Math.Cos(OmegaF1 * xCoord1 + PShift));
                xCoord2 = (float)(i);
                yCoord2 = (float)(Um2 * Math.Cos(OmegaF2 * xCoord2 + 2 * PShift));
                yCoord1 = yCoord1 + yCoord2;
                xCoordM = (float)(i * StepM);
                yCoordM = (float)(UmA * Math.Cos(OmegaM * xCoordM + PShift));
                yCoordM = i;
                if (toolStripComboBox3.Text == "FM")
                {
                    yCoordM = (float)(UmA*10.0F * Math.Cos(2*Math.PI*FCarrier*(xCoordM)*mFactor*1000*Math.Cos(2*Math.PI*(tmp1+tmp2)*xCoordM)));
                }

                if (toolStripComboBox3.Text == "AM")
                {
                    yCoordM = (float)((Um1+Um2) * Math.Cos(OmegaM * xCoordM + PShift));
                    yCoordM = (float)(yCoordM * (1 + mFactor * ((Um1 * Math.Cos(OmegaF1 * xCoord1 + PShift)+(Um2 * Math.Cos(OmegaF2 * xCoord2 + 2*PShift))))));
                }
                yCoordM = yCoordM + (float)(YDelta);
                PointF tmpPoint1 = new PointF(xCoordM, yCoordM + 50.0F);
                CospointsM[i] = tmpPoint1;


            }
            //e.Graphics.ScaleTransform(1.0F, 0.1F);
            //e.Graphics.TranslateTransform(0.0F, 1.0F);
            e.Graphics.ResetTransform();

            e.Graphics.ScaleTransform((float)(XScale), (float)(YScale));
         
            
            e.Graphics.DrawCurve(greenPen, CospointsM);
            //
        Finish: ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
            int a,ETFactor,QueueLength,agStep,agTotal;
            Double a0,ICall;
            string agtmp;
            int agtmp1;
            agStep = 0;
            Random gen = new Random();
            ETFactor = Convert.ToInt32(toolStripTextBox1.Text);
            QueueLength = Convert.ToInt32(toolStripTextBox2.Text);
            TiminglistBox.Items.Clear();
            agTotal = 0;
            a = 0;
            a0 = 1;
            ICall = 1;
            // Aggregates disabled
            if (toolStripComboBox2.Text == "Aggregates disabled")

            {
                TiminglistBox.Items.Add("Aggregates disabled.");
                a = 0;
                a0 = 1.0;
                ICall = 1;
            }
            // Outgoing call
            if (toolStripComboBox2.Text == "Outgoing call")
            {
                TiminglistBox.Items.Add("Outgoing call:");
                a = 1;
                a0 = 1.0;
                ICall = 1;
            }
            // Ingoing call
            if (toolStripComboBox2.Text == "Ingoing call")
            {
                TiminglistBox.Items.Add("Ingoing call:");
                a = 2;
                a0 = 1.0;
            }
            // A0-Outgoing call
            if (toolStripComboBox2.Text == "A0-Outgoing call")
            {
                TiminglistBox.Items.Add("A0-Outgoing call:");
                a = 1;
                a0 = gen.NextDouble();
            }
            // A0-Ingoing call
            if (toolStripComboBox2.Text == "A0-Ingoing call")
            {
                TiminglistBox.Items.Add("A0-Ingoing call:");
                a = 2;
                a0 = gen.NextDouble();
                ICall = gen.NextDouble();
            }

            if ((textBox1.Text.Length != 0) && (textBox2.Text.Length != 0) && (textBox3.Text.Length != 0) && (textBox4.Text.Length != 0) && (textBox5.Text.Length != 0) && (textBox6.Text.Length != 0) && (textBox7.Text.Length != 0))
            {
                // If there is an outgoing call then count all the events bound to it 
                if (a == 1)
                {
                    // Step 1
                    agStep = 1;
                    
                    agtmp = "A1: Finished in ";
                    agtmp1 = agStep * ETFactor;
                    agtmp = agtmp + agtmp1.ToString() + " ms";
                    TiminglistBox.Items.Add(agtmp);

                    //Step 2

                    agStep = agStep+1;

                    for (int i=1; i<=QueueLength; i++)
                    {
                        agtmp1 = agStep * ETFactor * QueueLength * i;
                   
                        agtmp = "A2: Finished in ";
                        agtmp = agtmp + agtmp1.ToString() + " ms";
                        TiminglistBox.Items.Add(agtmp);
                    
                    }
                   
                    // Step 3
                    agStep = agStep+1;                    
                    agtmp = "A3: Finished in ";
                    agtmp1 = agStep * ETFactor;
                    agtmp = agtmp + agtmp1.ToString() + " ms.";
                    TiminglistBox.Items.Add(agtmp);
                    TiminglistBox.Items.Add("Complex signal generating allowed.");

                    // Step 4
                    agStep = agStep+1;
                    agtmp = "A4: Finished in ";
                    agtmp1 = agStep * ETFactor;
                    agtmp = agtmp + agtmp1.ToString() + " ms. All the formalities are finished.";
                    
                    TiminglistBox.Items.Add(agtmp);
                    TiminglistBox.Items.Add("Transceive the data to the air.");
                    //Step A0
                    agStep = agStep + 1;
                    agtmp1 = agStep * ETFactor * Convert.ToInt32(a0);
                    if (agtmp1 != 0)
                    {
                        agtmp = "A0: Success - finished in ";
                        agtmp = agtmp + agtmp1.ToString() + " ms";
                        TiminglistBox.Items.Add(agtmp);
                    }
                    else
                    {
                        agtmp = "A0: Fail - interrupted after ";
                        agtmp = agtmp + agtmp1.ToString() + " ms.";
                        TiminglistBox.Items.Add(agtmp);
                        TiminglistBox.Items.Add("No air/wired connection lines available.");
                        DelAllAndEnd = 1;
                        pictureBox1.BackColor = Color.White;
                        pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
                        pictureBox2.BackColor = Color.White;
                        pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = true;
                        pictureBox2.Visible = true;
                        goto Finish;
                    }
                    // Step A'1
                    agStep = agStep + 1;
                    agtmp = "A'1: Finished in ";
                    agtmp1 = agStep * ETFactor;
                    agtmp = agtmp + agtmp1.ToString() + " ms.";
                    TiminglistBox.Items.Add(agtmp);
                    TiminglistBox.Items.Add("Modulated complex signal delivered to basic module.");
                    // Step A'3
                    agStep = agStep + 1;
                    agtmp = "A'3: Finished in ";
                    agtmp1 = agStep * ETFactor;
                    agtmp = agtmp + agtmp1.ToString() + " ms.";
                    TiminglistBox.Items.Add(agtmp);
                    TiminglistBox.Items.Add("Complex signal demodulation.");
                

                }

                // If there is an ingoing call then count all the events bound to it
                if (a == 2)
                {
                    agStep = 1;
                    //Step A0
                    agStep = agStep + 1;
                    agtmp1 = agStep * ETFactor * Convert.ToInt32(a0);
                    if (agtmp1 != 0)
                    {
                        agtmp = "A0: Success - finished in ";
                        agtmp = agtmp + agtmp1.ToString() + " ms";
                        TiminglistBox.Items.Add(agtmp);
                    }
                    else
                    {
                        agtmp = "A0: Fail - interrupted after ";
                        agtmp = agtmp + agtmp1.ToString() + " ms.";
                        TiminglistBox.Items.Add(agtmp);
                        TiminglistBox.Items.Add("No wired connection lines available.");
                        DelAllAndEnd = 1;
                        pictureBox1.BackColor = Color.White;
                        pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
                        pictureBox2.BackColor = Color.White;
                        pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = true;
                        pictureBox2.Visible = true;
                        goto Finish;
                    }
                    // Step A'1
                    agStep = agStep + 1;
                    agtmp1 = agStep * ETFactor * Convert.ToInt32(ICall);
                    if (agtmp1 != 0)
                    {
                        agtmp = "A'1: Success - finished in ";
                        agtmp = agtmp + agtmp1.ToString() + " ms.";
                        TiminglistBox.Items.Add(agtmp);
                        TiminglistBox.Items.Add("There is an input call.");
                    }
                    else
                    {
                        agtmp = "A'1: Fail - interrupted after ";
                        agtmp = agtmp + agtmp1.ToString() + " ms.";
                        TiminglistBox.Items.Add(agtmp);
                        TiminglistBox.Items.Add("There is no input call.");
                        DelAllAndEnd = 1;
                        pictureBox1.BackColor = Color.White;
                        pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
                        pictureBox2.BackColor = Color.White;
                        pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = true;
                        pictureBox2.Visible = true;
                        goto Finish;
                    }

                    // Step 3
                    agStep = agStep + 1;
                    agtmp = "A'3: Finished in ";
                    agtmp1 = agStep * ETFactor;
                    agtmp = agtmp + agtmp1.ToString() + " ms.";
                    TiminglistBox.Items.Add(agtmp);
                    TiminglistBox.Items.Add("Input data analysis.");

                    // Step 4
                    agStep = agStep + 1;
                    agtmp = "A'2: Finished in ";
                    agtmp1 = agStep * ETFactor;
                    agtmp = agtmp + agtmp1.ToString() + " ms.";
                    TiminglistBox.Items.Add(agtmp);
                    TiminglistBox.Items.Add("Communicating to transceiver.");

                    // Step 5
                    agStep = agStep + 1;
                    agtmp = "A'4: Finished in ";
                    agtmp1 = agStep * ETFactor;
                    agtmp = agtmp + agtmp1.ToString() + " ms.";
                    TiminglistBox.Items.Add(agtmp);
                    TiminglistBox.Items.Add("Creating radio-path...");

                   
                    
                    //Step A0
                    agStep = agStep + 1;
                    agtmp1 = agStep * ETFactor * Convert.ToInt32(a0);
                    if (agtmp1 != 0)
                    {
                        agtmp = "A0: Success - finished in ";
                        agtmp = agtmp + agtmp1.ToString() + " ms";
                        TiminglistBox.Items.Add(agtmp);
                    }
                    else
                    {
                        agtmp = "A0: Fail - interrupted after ";
                        agtmp = agtmp + agtmp1.ToString() + " ms.";
                        TiminglistBox.Items.Add(agtmp);
                        TiminglistBox.Items.Add("No air connection available/no answer from .");
                        DelAllAndEnd = 1;
                        pictureBox1.BackColor = Color.White;
                        pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
                        pictureBox2.BackColor = Color.White;
                        pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = true;
                        pictureBox2.Visible = true;
                        goto Finish;
                    }

                    // Step 6
                    agStep = agStep + 1;
                    agtmp = "A1: Finished in ";
                    agtmp1 = agStep * ETFactor;
                    agtmp = agtmp + agtmp1.ToString() + " ms.";
                    TiminglistBox.Items.Add(agtmp);
                    TiminglistBox.Items.Add("Obtaining data from the air.");

                    // Step 7
                    agStep = agStep + 1;
                    agtmp = "A2: Finished in ";
                    agtmp1 = agStep * ETFactor;
                    agtmp = agtmp + agtmp1.ToString() + " ms.";
                    TiminglistBox.Items.Add(agtmp);
                    TiminglistBox.Items.Add("Data proccessing.");

                    // Step 8
                    agStep = agStep + 1;
                    agtmp = "A3: Finished in ";
                    agtmp1 = agStep * ETFactor;
                    agtmp = agtmp + agtmp1.ToString() + " ms.";
                    TiminglistBox.Items.Add(agtmp);
                    TiminglistBox.Items.Add("Indicatiion: Line # -> User.");
                }               
                DelAllAndEnd = 0;
                //pictureBox1.Dock = DockStyle.Fill;
                pictureBox3.BackColor = Color.Red;
                
                pictureBox1.BackColor = Color.White;
                pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
                pictureBox2.BackColor = Color.White;
                pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;

                Double[] vRarray = new Double[1000];
                Double[] Skarray = new Double[1000];
                Double[] WRarray = new Double[1000];
                Double OmegaF1, OmegaF2, Um1, Um2, PShift, tmp1, tmp2, Step1, Step2, alpha;
                float xCoord1, xCoord2, yCoord1, yCoord2;
                tmp1 = Convert.ToDouble(textBox5.Text) / 1000;
                OmegaF1 = (2 * Math.PI) / tmp1;
                tmp2 = Convert.ToDouble(textBox3.Text) / 1000;
                OmegaF2 = (2 * Math.PI) / tmp2;
                Step1 = Convert.ToDouble(textBox8.Text);
                Step2 = Convert.ToDouble(textBox9.Text);
                Um1 = Convert.ToDouble(textBox6.Text);
                Um2 = Convert.ToDouble(textBox7.Text);
                PShift = Convert.ToDouble(textBox4.Text);

                for (int i = Convert.ToInt32(textBox1.Text); i < Convert.ToInt32(textBox2.Text); i++)
                {
                    xCoord1 = (float)(i * Step1);
                    yCoord1 = (float)(Um1 * Math.Cos(OmegaF1 * xCoord1 + PShift));
                    xCoord2 = (float)(i * Step2);
                    yCoord2 = (float)(Um2 * Math.Cos(OmegaF2 * xCoord2 + 2 * PShift));
                    yCoord1 = yCoord1 + yCoord2;
                    alpha = 2 * Math.Cos(2 * Math.PI * (yCoord1 / Convert.ToInt32(textBox2.Text)));
                    WRarray[i] = Math.Cos(2 * Math.PI * (yCoord1 / Convert.ToInt32(textBox2.Text)));
                    if (i >= 3)
                    {
                        try
                        {
                            vRarray[i] = yCoord1 + 2 * alpha * vRarray[i - 1] - vRarray[i - 2];
                        }
                        catch
                        {
                            vRarray[i] = yCoord1 + 2 * alpha;
                        }
                    }
                }
                for (int i = 0; i < vRarray.Length; i++)
                {
                    for (int j = 0; j < WRarray.Length; j++)
                    {
                        if (i >= 3)
                        {
                            try
                            {
                                Skarray[i] = WRarray[j] * vRarray[i - 1] - vRarray[i - 2];

                            }
                            catch
                            {
                                Skarray[i] = WRarray[j];
                            }
                        }
                    }
                }
               
                for (int i = 0; i < Skarray.Length; i++)
                {
                    if (Skarray[i].ToString() == "NaN") 
                    {
                      //  listBox1.Items.Add(Skarray[i]);
                        int dummy = 3;
                    }
                    else if (Skarray[i].ToString() == "0")
                    {
                      //  listBox1.Items.Add(Skarray[i]);
                        int dummy = 3;
                    }
                    else if (Skarray[i].ToString() == "бесконечность")
                    {
                        //  listBox1.Items.Add(Skarray[i]);
                        int dummy = 3;
                    }
                    else
                    {
                        listBox1.Items.Add(Skarray[i]);
                        if (Skarray[i].ToString() == textBox14.Text)
                        {
                            pictureBox3.BackColor = Color.Green;
                            if (a == 1)
                            {
                                // Step A'2
                                agStep = agStep + 1;
                                agtmp1 = agStep * ETFactor;
                                agtmp = "A'2: Finished in ";

                                agtmp = agtmp + agtmp1.ToString() + " ms. ";
                                TiminglistBox.Items.Add(agtmp);
                                TiminglistBox.Items.Add("Data analysis finished successfully.");

                                // Step A'4
                                agStep = agStep + 1;
                                agtmp1 = agStep * ETFactor;
                                agtmp = "A'4: Finished in ";

                                agtmp = agtmp + agtmp1.ToString() + " ms. ";
                                TiminglistBox.Items.Add(agtmp);
                                
                            }
                        }
                        else if (a == 1)
                        {
                            // Step A'2
                            agStep = agStep + 1;
                            agtmp1 = agStep * ETFactor;
                            agtmp = "A'2: Interrupted in ";

                            agtmp = agtmp + agtmp1.ToString() + " ms. ";
                            TiminglistBox.Items.Add(agtmp);
                            TiminglistBox.Items.Add("Data analysis confused.");
                        }
                    }
                   
                }





            



            }
            else MessageBox.Show("It is one or more data fields left empty; please, check them out.", "Sorry, Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
       
            Finish: ;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                textBox14.Text = listBox1.SelectedItem.ToString();
            }
            catch
            {
                int dummy = 3;
            }
            }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
           
                        Pen greenPen = new Pen(Color.Green, 1);
                        Pen redPen = new Pen(Color.Red, 1);
                        Brush greenBrush = new SolidBrush(Color.Green);

                        e.Graphics.DrawEllipse(greenPen, 3, 3, 190, 190);
                        e.Graphics.FillEllipse(greenBrush, 3, 3, 190, 190);
               
            }
     
     
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

      

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DelAllAndEnd = 1;
            System.Drawing.Drawing2D.GraphicsPath pBox = new System.Drawing.Drawing2D.GraphicsPath();
            pBox.AddEllipse(0,0,30,30);
            Region pBoxRgn = new Region(pBox);
            pictureBox3.Region = pBoxRgn;
            pictureBox3.BackColor = Color.Red;

        }

        private void executionTimingFactorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox3_TextChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox3.Text == "FM")
            {
                textBox13.Text = "0,066";
                textBox11.Text = "450";
                textBox10.Text = "0,09";
                textBox3.Text = "15";
            }
            if (toolStripComboBox3.Text == "AM")
            {
                textBox13.Text = "0,05";
                textBox10.Text = "0,03";
                textBox11.Text = "1600";
                textBox3.Text = "15";
            }

        }

        private void toolStripComboBox3_Click(object sender, EventArgs e)
        {

        }

    }
}
