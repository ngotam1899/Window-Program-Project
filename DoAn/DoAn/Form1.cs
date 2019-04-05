using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Form1 : Form
    {
        //enter the variables
        bool goup; //cho phép người chơi đi lên
        bool godown; //cho phép người chơi đi xuống
        bool shot = false;//kiểm tra xem người chơi có bắn phát nào chưa
        int score = 0;// số điểm người chơi
        int speed = 5;//tốc độ ufo
        Random rand = new Random();
        int playerSpeed = 7;//tốc độ di chuyển của người chơi
        int index;//thay đổi hình ufo

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //nếu người chơi bấm lên thay đổi biến thành true
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                //nếu người chơi bấm xuống thay đổi biến thành true
                godown = true;
            }
            if(e.KeyCode==Keys.Space && shot == false)
            {
                //nếu người chơi bấm space và biến shot là false. Sau đó chạy hàm bullet và gián lại shot = true
                MakeBullet();
                shot = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //nếu người chơi bấm lên thay đổi biến thành false
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                //nếu người chơi bấm xuống thay đổi biến thành false
                godown = false;
            }
            if (shot==true)
            {
                //nếu biến shot = true thì đổi lại false để người chơi bắn lại
                shot = false;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //dịch chuyển bức tường về trái màn hình
            pillar1.Left -= speed;
            pillar2.Left -= speed;
            //dịch chuyển ufo về trái
            ufo.Left -= speed;
            //Điểm số của người chơi
            label1.Text = "Score: " + score;
            if (goup)
            {
                // nếu goup=true di chuyển người chơi đi lên
                player.Top -= playerSpeed;
            }
            if (godown)
            {
                //nếu godown=true di chuyển người chơi đi xuống
                player.Top += playerSpeed;
            }
            if (pillar1.Left < -150)
            {
                //nếu bức tường đi khỏi màn hình, dịch chuyển bức tường sang phần bên phải (dịch chuyển từ phải sang trái)
                pillar1.Left = 900;
            }
            if (pillar2.Left < -150)
            {
                //nếu bức tường đi khỏi màn hình, dịch chuyển bức tường sang phần bên phải (dịch chuyển từ phải sang trái)
                pillar2.Left = 1000;
            }
            if(ufo.Left<-5 || player.Bounds.IntersectsWith(ufo.Bounds) || player.Bounds.IntersectsWith(pillar1.Bounds) || player.Bounds.IntersectsWith(pillar2.Bounds))
            {
                gameTimer.Stop();
                //hiện ra điểm số cuối cùng của người chơi
                MessageBox.Show("Game over: " + score);
            }
            foreach(Control X in this.Controls)
            {
                //nếu X là hình đầu đạn
                if(X is PictureBox && X.Tag == "bullet")
                {
                    //dịch chuyển X về pahi3 màn hình
                    X.Left +=15;
                    //nếu x đi ra khỏi màn hình
                    if (X.Left > 900)
                    {
                        this.Controls.Remove(X);
                        X.Dispose();
                    }
                    //nếu X đụng phải UF0
                    if (X.Bounds.IntersectsWith(ufo.Bounds))
                    {
                        //cộng 1 điểm
                        score += 1;
                        //dịch chuyển đạn ra khỏi màn hình
                        this.Controls.Remove(X);
                        X.Dispose();
                        //dịch chuyển UF0
                        ufo.Left = 1000;
                        ufo.Top = rand.Next(5, 330) - ufo.Height;
                        ChangeUFO();
                    }
                }
            }
        }
        private void ChangeUFO()
        {
            index += 1;//thay đổi hình UF0
            if (index > 3)
            {
                //nếu đổi hết 3 hình, trở lại hình đầu tiên
                index = 1;
            }
            switch (index)
            {
                //hình 1
                case 1:
                    ufo.Image = Properties.Resources.alien1;
                    break;
                //hình 2
                case 2:
                    ufo.Image = Properties.Resources.alien2;
                    break;
                //hình 3
                case 3:
                    ufo.Image = Properties.Resources.alien3;
                    break;
            }
        }
        private void MakeBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.BackColor = System.Drawing.Color.DarkOrange;
            bullet.Height = 5;
            bullet.Width = 10;
            bullet.Left = player.Left + player.Width; // bay trước mặt
            bullet.Top = player.Top + player.Height / 2; //bay chính giữa
            bullet.Tag = "bullet";
            this.Controls.Add(bullet);
            //thêm hình bullet
        }
    }
}
