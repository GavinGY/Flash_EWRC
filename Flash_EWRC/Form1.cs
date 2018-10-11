using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;
using System.IO;

namespace Flash_EWRC
{
    public partial class Form1 : Form
    {
        //定义端口类
        private SerialPort ComDevice = new SerialPort();
        string[] str = SerialPort.GetPortNames();
        string reSdata;
        UInt16 flag_status=0;
        string CRC_Value_1=" ";
        string CRC_Value_2 = " ";
        Int16 Now_index=0;
        Int16 Now_index_old = 0;
        System.Timers.Timer t = new System.Timers.Timer(40000);//实例化Timer类，设置间隔时间为1000毫秒 就是1秒；
        string LogFileName = DateTime.Now.ToFileTimeUtc().ToString() + "_EWRC.log";
        

        public Form1()
        {
            InitializeComponent();
            InitralConfig();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void handle_1()
        {

        }

        private void Start()
        {
            flag_status = 0;
            SendString("crc -offset=0xC800000 -size=2949120 \r");
        }
        private void content_handle_1(string reSdata_in)
        {
            string reData = reSdata_in;
            reSdata = "";
            TextWrite(reData);
            string[] strArray = reData.Split(new char[3] { ' ', '*', '\r'});

            Init_PitureStatus();
            if (Now_index == 0)
                pictureBox1.BackgroundImage = Properties.Resources.blue;
            else
                pictureBox2.BackgroundImage = Properties.Resources.blue;

            if (strArray[0] == "CPU")//板子启动,询问 NOR CRC
            {
                Console.WriteLine("Board Start !!!!!!!");
                TextWrite(DateTime.Now.ToLocalTime().ToString() + " ####################### Board Start ################## ");
                flag_status = 0;
                SendString("crc -offset=0xC800000 -size=2949120 \r");
                return;
            }
            if (strArray.Length > 50)//板子重启,询问 NOR CRC
            {
                Console.WriteLine("Board Restart !!!!!!!");
                TextWrite(DateTime.Now.ToLocalTime().ToString() + " ####################### Board ReStart !!! ################## ");
                flag_status = 0;
                SendString("crc -offset=0xC800000 -size=2949120 \r");
                return;
            }

            if (flag_status == 0)  //获取初始NOR CRC校验值
            {
                //Console.WriteLine(strArray[7]);
                //Console.WriteLine(strArray[8]);
                //Console.WriteLine(strArray[9]);
                //Console.WriteLine(strArray[10]);
                CRC_Value_1 = strArray[10];
                Console.WriteLine("Stage00 get Nor CRC_InitValue OK");
                Console.WriteLine(CRC_Value_1);
                flag_status = 1;
                SendString("crc -offset=0xC800000 -size=33554432 \r"); //询问 Nand CRC校验值
                return;
            }
            if (flag_status == 1)//获取 Nand CRC校验值
            {
                CRC_Value_2 = strArray[10];
                Console.WriteLine("Stage01 get Nand CRC_InitValue OK");
                Console.WriteLine(CRC_Value_2);
               
                flag_status = 2;
                //SendString("erase flash0.Test_nor \r");
                sendConten(Now_index, 04);
                //Init_PitureStatus();
                pictureBoxS1.BackgroundImage = Properties.Resources.blue;
                return;
            }


            if (flag_status == 2) //检查擦除是否完成
            {
                //Console.WriteLine(strArray[9]);
                //Console.WriteLine(strArray[10]);
               // Console.WriteLine(strArray[14]);
               // Console.WriteLine(strArray[12]);

                if ("0" == strArray[14])//擦除成功
                {
                    Console.WriteLine("Stage " + Now_index + " Erase OK");
                    TextWrite(DateTime.Now.ToLocalTime().ToString() + "  Stage " + Now_index + " Erase OK");
                }
                else //擦除失败
                {
                    Console.WriteLine("Stage " + Now_index + " Erase Faile");
                    TextWrite(DateTime.Now.ToLocalTime().ToString() + "  Stage " + Now_index + " Erase Faile");
                }
                flag_status = 3;
                //SendString("flash -size=7 -forcewrite -mem=0xC800000 -memsize=0x2D0000 mem0 flash0.Test_nor \r");
                sendConten(Now_index,01);
                //Init_PitureStatus();
                pictureBoxS2.BackgroundImage = Properties.Resources.blue;
                return;
            }
            else if (flag_status == 3)//检查是否写入完成
            {
                //Console.WriteLine(strArray[23]);
                //Console.WriteLine(strArray[24]);
                //Console.WriteLine(strArray[25]);
                //Console.WriteLine(strArray[26]);

                if ("0" == strArray[25])//写入成功
                {
                    Console.WriteLine("Stage " + Now_index + " Write OK");
                    TextWrite(DateTime.Now.ToLocalTime().ToString() + "  Stage " + Now_index + " Write OK");
                }
                else //写入失败
                {
                    Console.WriteLine("Stage " + Now_index + " Write Faile");
                    TextWrite(DateTime.Now.ToLocalTime().ToString() + "  Stage " + Now_index + " Write Faile");
                }
                flag_status = 4;
                //SendString("load -raw -addr=0x8000 flash0.Test_nor mem \r");
                sendConten(Now_index, 02);
                //Init_PitureStatus();
                pictureBoxS3.BackgroundImage = Properties.Resources.blue;
                return;
            }
            else if (flag_status == 4)//检查读取是否完成
            {
                if (Now_index == 0)
                {
                    if ("2949120" == strArray[32])//读取成功 14//32
                    {
                        Console.WriteLine("Stage " + Now_index + " Read OK");
                        TextWrite(DateTime.Now.ToLocalTime().ToString()+"  Stage " + Now_index + " Read OK");
                    }
                    else //读取失败
                    {
                        Console.WriteLine("Stage " + Now_index + " Read Faile");
                        TextWrite(DateTime.Now.ToLocalTime().ToString() + "  Stage " + Now_index + " Read Faile");
                    }
                }
                else
                {
                    if ("33554432" == strArray[14])//读取成功 14//32
                    {
                        Console.WriteLine("Stage " + Now_index + " Read OK");
                        TextWrite(DateTime.Now.ToLocalTime().ToString() + "  Stage " + Now_index + " Read OK");
                    }
                    else //读取失败
                    {
                        Console.WriteLine("Stage " + Now_index + " Read Faile");
                        TextWrite(DateTime.Now.ToLocalTime().ToString() + "  Stage " + Now_index + " Read Faile");
                    }
                }
                flag_status = 5;
                //SendString("crc -offset=0x8000 -size=2949120 \r");
                sendConten(Now_index, 03);
                //Init_PitureStatus();
                pictureBoxS4.BackgroundImage = Properties.Resources.blue;
                return;
            }
            else if (flag_status == 5)//检查读取是否完成
            {  
                string CRC_Value;
                if (Now_index == 0)
                    CRC_Value = CRC_Value_1;
                else
                    CRC_Value = CRC_Value_2;

                if (CRC_Value == strArray[10])//校验成功
                {
                    Console.WriteLine("Stage " + Now_index + " CRC OK");
                    TextWrite(DateTime.Now.ToLocalTime().ToString() + "  Stage " + Now_index + " CRC OK");
                }
                else //校验失败
                {
                    Console.WriteLine("Stage " + Now_index + " CRC Faile");
                    TextWrite(DateTime.Now.ToLocalTime().ToString() + "  Stage " + Now_index + " CRC Faile");
                }
                flag_status = 2;

                Now_index++;
                if (Now_index >= 17)   Now_index = 0;

                sendConten(Now_index, 04);
                pictureBoxS1.BackgroundImage = Properties.Resources.blue;
                return;
            }

   
            //Console.WriteLine(strArray[0]);
            //Console.WriteLine(strArray[8]);
            //Console.WriteLine(strArray[9]);
            //Console.WriteLine(reData);
            //Console.WriteLine(reSdata);
           /* foreach (string item in strArray)
            {
                Console.WriteLine(item);
            }*/
            //Console.WriteLine(reData);
        }

        private void sendConten(Int16 index, Int16 number)
        {
            if (index == 0)//Test NorFlash
            {
                switch (number)
                {
                    case 01: SendString("flash -size=7 -forcewrite -mem=0xC800000 -memsize=0x2D0000 mem0 flash0.Test_nor \r"); break;
                    case 02: SendString("load -raw -addr=0x8000 flash0.Test_nor mem \r"); break;
                    case 03: SendString("crc -offset=0x8000 -size=2949120 \r"); break;
                    case 04: SendString("erase flash0.Test_nor \r"); break;
                }
            }
            else//Test NandFlash
            {
                switch (number)
                {
                    case 01: SendString("flash -size=7 -forcewrite -mem=0xC800000 -memsize=0x2000000 mem0 flash1.Test_nand_" + (index - 1) + " \r"); break;
                    case 02: SendString("load -raw -addr=0x8000 flash1.Test_nand_" + (index - 1) + " mem \r"); break;
                    case 03: SendString("crc -offset=0x8000 -size=33554432 \r"); break;
                    case 04: SendString("erase flash1.Test_nand_" + (index-1) + " \r"); break;
                }       
            }
           
        }

        public void TextWrite(string TextData)
        {
            StreamWriter sw = new StreamWriter(LogFileName, true);
            sw.WriteLine(TextData);
            sw.Close();
        }

        private void InitralConfig()
        {
            Init_PitureStatus();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }
            //添加串口项目  
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {//获取有多少个COM口  
                cbSerial.Items.Add(s);
            }
            //串口设置默认选择项  
            cbSerial.SelectedIndex = 0;         //设置cbSerial的默认选项  

            //向ComDevice.DataReceived（是一个事件）注册一个方法Com_DataReceived，当端口类接收到信息时时会自动调用Com_DataReceived方法
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);

        }

        public void time_out(object source, System.Timers.ElapsedEventArgs e)
        {
            //this.Invoke(new TextOption(f));//invok 委托实现跨线程的调用
            if (Now_index_old == Now_index)
            {
                //Start();
                sendConten(Now_index, 04);
                TextWrite(DateTime.Now.ToLocalTime().ToString() + " ####################### Error ################## " + Now_index + " Tool Restart !");
            }
            Now_index_old = Now_index;
        }


        private void Init_PitureStatus()
        {
            pictureBox1.BackgroundImage = Properties.Resources.gray;
            pictureBox2.BackgroundImage = Properties.Resources.gray;
            pictureBoxS1.BackgroundImage = Properties.Resources.gray;
            pictureBoxS2.BackgroundImage = Properties.Resources.gray;
            pictureBoxS3.BackgroundImage = Properties.Resources.gray;
            pictureBoxS4.BackgroundImage = Properties.Resources.gray;
        }

        /// <summary>
        /// 接收端对话框显示消息
        /// </summary>
        /// <param name="content"></param>
        private void AddContent(string content)
        {
            BeginInvoke(new MethodInvoker(delegate{textReceive.AppendText(content);}));
        }

        /// <summary>
        /// 一旦ComDevice.DataReceived事件发生，就将从串口接收到的数据显示到接收端对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //开辟接收缓冲区
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            //从串口读取数据
            ComDevice.Read(ReDatas, 0, ReDatas.Length);
            //实现数据的解码与显示
            //Console.WriteLine(ReDatas.Length);
            AddContent(new ASCIIEncoding().GetString(ReDatas));

            string reSdatatmp = new ASCIIEncoding().GetString(ReDatas);
            reSdata = reSdata + reSdatatmp;
            Int32 end_flag_po = ReDatas.Length - 2 ;
            if(end_flag_po > -1)
            {
                if (ReDatas[end_flag_po] == 62)
                {
                    content_handle_1(reSdata);
                }
            }
            //string reSdatatmp = new ASCIIEncoding().GetString(ReDatas);
            //reSdata = reSdata + reSdatatmp;
            //content_handle_1(new ASCIIEncoding().GetString(ReDatas));
        }

        /// <summary>
        /// 此函数将编码后的消息传递给串口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SendData(byte[] data)
        {
             if (ComDevice.IsOpen)
             {
                try
                {
                     //将消息传递给串口
                     ComDevice.Write(data, 0, data.Length);
                     return true;
                }
                catch (Exception ex)
                {
                     MessageBox.Show(ex.Message, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             }
             else
             {
                 MessageBox.Show("串口未开启", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             return false;
         }


        private void button1_Click(object sender, EventArgs e)
        {

             if (ComDevice.IsOpen == false)
             {
                 //设置串口相关属性
                 ComDevice.PortName = cbSerial.SelectedItem.ToString();
                 ComDevice.BaudRate = (int)115200;
                 ComDevice.Parity = Parity.None;
                 ComDevice.DataBits = (int)8;
                 ComDevice.StopBits = StopBits.One;

                 try
                 {
                     //开启串口
                    ComDevice.Open();
                    btnSend.Enabled = true;

                    LogFileName = cbSerial.SelectedItem.ToString()+ "_" + LogFileName; 
                    FileStream fs = new FileStream(LogFileName, FileMode.Create);
                    fs.Close();

                    t.Elapsed += new System.Timers.ElapsedEventHandler(time_out);//到达时间的时候执行事件；
                    t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
                    t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message, "未能成功开启串口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }
                 btnSwitch.Text = "Disconnect";
                 //pictureBox_Status.BackgroundImage = Properties.Resources.green;
             }
             else
             {
                 try
                 {
                     //关闭串口
                     ComDevice.Close();
                     btnSend.Enabled = false;
                     t.Close();
                 }
                 catch (Exception ex)
                 {
                    MessageBox.Show(ex.Message, "串口关闭错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 btnSwitch.Text = "Connect";
                 //pictureBox_Status.BackgroundImage = Properties.Resources.red;
             }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
             Start();
            /* if (textReceive.Text.Length > 0)
             {
                 textReceive.AppendText("\n");
             }
 
             byte[] sendData = null;
             sendData = Encoding.ASCII.GetBytes(textSend.Text);
             SendData(sendData);*/
        }

        private void SendString(string sData)
        {
            byte[] sendData = null;
            sendData = Encoding.ASCII.GetBytes(sData);
            SendData(sendData);     
        }

        public static bool Delay(int delayTime)
        {
            DateTime now = DateTime.Now;
            int s;
            do
            {
                TimeSpan spand = DateTime.Now - now;
                s = spand.Seconds;
                Application.DoEvents();
            }
            while (s < delayTime);
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    
    }


 
}
