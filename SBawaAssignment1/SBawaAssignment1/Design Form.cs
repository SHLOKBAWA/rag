using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;                //FOR STREAMWRITER.

namespace SBawaAssignment1
{
    public partial class Design_Form : Form
    {
        enum Characters                         //SPECIFYING NAME OF INDEXES. DOR EVERY CHARACTER
        {
            NONE,
            hero,
            WALL,
            BOX,
            DESTINATION
        }

            /*-----------------------------THE BEST PART-------------------------------*/
        System.Drawing.Bitmap hero = SBawaAssignment1.Properties.Resources.hero;            //DECLARING VARIABLES FOR EVERY RESOURCE IMAGES TO MAKE IT LOOK SIMPLE     
        System.Drawing.Bitmap WALL = SBawaAssignment1.Properties.Resources.WALL;
        System.Drawing.Bitmap BOX = SBawaAssignment1.Properties.Resources.BOX;
        System.Drawing.Bitmap DESTINATION = SBawaAssignment1.Properties.Resources.DESTINATION;
            /*------------------------------THE BEST PART-----------------------------*/


        Characters characters = new Characters();                //CREATING THE OBJECT OF CHARACTERS


        public Design_Form()
        {
            InitializeComponent();
        }

        private void Design_Form_Load(object sender, EventArgs e)
        {

        }



        /*---METHOD FOR CLICK FUNCTION OF EVERY PICTUREBOX CREATED BY LOOP---*/

        private void Add_Characters(object sender, EventArgs e)                     
        {
            PictureBox pbox = (PictureBox)sender;                  
            switch (characters)                         //SETTING VALUES FOR APPROPRIATE ENUM INDEX FUNCTION WITH APPROPRIATE IMAGES STORED IN SBAWAASSIGNMENT1/PROPRTIES/RESOURCES
            {
                case Characters.NONE:
                    pbox.Image = null;
                    break;
                case Characters.hero:
                    pbox.Image = hero;
                    break;
                case Characters.WALL:
                    pbox.Image = WALL;
                    break;
                case Characters.BOX:
                    pbox.Image = BOX;
                    break;
                case Characters.DESTINATION:
                    pbox.Image = DESTINATION;
                    break;
                default:
                    break;
            }
        }
        /*---METHOD FOR CLICK FUNCTION OF EVERY PICTUREBOX CREATED BY LOOP---*/





        /*---METHOD FOR ROWS WITH COORDINATES---*/

        private void picboxes(int pboxRows, int height, int width, int lpointTop, int lpointLeft, int gap)    
        {
            for(int i=0;i< pboxRows; i++)
            {
                PictureBox pbox = new PictureBox();
                pbox.Click += Add_Characters;                           //CALLING THE CLICK FUNCTION FOR THE ACTION
                
                

                pbox.Height = height;
                pbox.Width = width;
                pbox.Top = lpointTop;
                pbox.Left = lpointLeft;
                pbox.BorderStyle = BorderStyle.Fixed3D;                 //SETTING THE BORDERS OF EACH PICTUREBOX FOR VISIBILITY
                pbox.SizeMode = PictureBoxSizeMode.StretchImage;        //SETTING THE SIZE OF THE IMAGE THAT IS TO BE ENTERED
                
                lpointLeft += width + gap;                              //SETTING THE LEFT COORDINATE IN LOOP SO EVERY PICTURE BOX HAVE GAP FROM THE PICTURE BOX AROUND IT WITH RESPECT TO WIDTH

                this.Controls.Add(pbox);                                //ADDING THE PICTUREBOX EVERYTIME THE LOOP RUNS 
            }
            
        }

        /*---METHOD FOR ROWS WITH COORDINATES---*/




            /*---BUTTON TO GENERATE THE PICTUREBOXES---*/

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int pboxRows = int.Parse(textBox1.Text);
                int pboxCol = int.Parse(textBox2.Text);

                int height = 50;                                        //SEETING THE VALUES PARAMETERS THAT ARE TO BE PASSSED TO THE METHOD 
                int width = 50;
                int lpointTop = 170;
                int lpointLeft = 200;
                int gap = 1;

                for (int i = 0; i < pboxCol; i++)
                {
                    picboxes(pboxRows, height, width, lpointTop, lpointLeft, gap);          //CALLING THE METHOD WITH INCREMENTING THE LEFT POSITIONS OF THE PICTUREBOXES
                    lpointTop += height + gap;                                              //SETTING THE LEFT COORDINATE IN LOOP SO EVERY PICTURE BOX HAVE GAP FROM THE PICTURE BOX AROUND IT WITH RESPECT TO WIDTH
                }
            }
            catch
            {
                MessageBox.Show("PLEASE PROVIDE VALID DATA FOR ROWS AND COLUMNS (BOTH MUST BE INT");
            }
        }

        /*---BUTTON TO GENERATE THE PICTUREBOXES---*/






        /*---------------THE FOLLOWING BUTTONS ARE USED TO GENERATE THE CHARACTERS THROUGH ON CLICK EVENTS----------------*/





        private void button2_Click_1(object sender, EventArgs e)
        {
            
            characters = Characters.NONE;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            characters = Characters.hero;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            characters = Characters.WALL;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            characters = Characters.BOX;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            characters = Characters.DESTINATION;
        }

        /*---------------THE ABOVE BUTTONS ARE USED TO GENERATE THE CHARACTERS THROUGH ON CLICK EVENTS----------------*/




        private void SaveToFile(string fname, int[,] data)
        {
            int nRow = data.GetLength(0);
            int nCol = data.GetLength(1);
            
            StreamWriter writeStream = new StreamWriter(fname);
            writeStream.WriteLine(nRow);
            writeStream.WriteLine(nCol);
            for (int r = 0; r < nRow; ++r)
            {
                for (int c = 0; c < nCol; ++c)
                {
                    
                    writeStream.WriteLine(data[r, c]);
                }
            }
            writeStream.Close();
        }
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Characters characters = new Characters();
            int nRow = int.Parse(textBox1.Text);
            int nCol = int.Parse(textBox2.Text);

            int[,] data = new int[nRow, nCol];

            for (int r = 0; r < nRow; ++r)
            {
                for (int c = 0; c < nCol; ++c)
                {
                    
                         data[r, c] = r * 100 + c;
                
                }
            }

            DialogResult res = saveFileDialog1.ShowDialog();
            switch (res)
            {
                case DialogResult.OK:
                    string fname = saveFileDialog1.FileName;
                    SaveToFile(fname, data);
                    break;
            }

        }
        


        

    }
}
