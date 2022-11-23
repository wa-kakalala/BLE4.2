using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLE4._2
{
    public partial class Form1 : Form
    {
        Bt4AsyncScan bt4AsyncScan;
        Dictionary<string, BluetoothAddress> bleaddrmap = new Dictionary<string, BluetoothAddress>();
        public Form1()
        {
            InitializeComponent();
            bt4AsyncScan = new Bt4AsyncScan();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!bleaddrmap.ContainsKey(BleAddrTxt.Text)){
                labelinfo.Text = "不存在对应的设备！";
                return;
            }
            BluetoothEndPoint ep = new BluetoothEndPoint(bleaddrmap[BleAddrTxt.Text], BluetoothService.SerialPort);
            try
            {
                bt4AsyncScan.bluetoothClient.Connect(ep);
                labelinfo.Text = "连接中...";
                if (bt4AsyncScan.bluetoothClient.Connected)
                {
                    labelinfo.Text = "连接成功！";
                }
                else
                {
                    labelinfo.Text = "连接失败！";
                }
            }catch (Exception err)
            {
                labelinfo.Text = "连接失败！";
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            bt4AsyncScan.Start_Scan(BluetoothComponent_DiscoverDevicesProgress);
            labelinfo.Text = "搜索中...";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void BluetoothComponent_DiscoverDevicesProgress(object sender, DiscoverDevicesEventArgs e)
        {
            BluetoothAddress bleaddr = e.Devices[0].DeviceAddress;
            string blename = e.Devices[0].DeviceName.ToString();
            //listBox.Items.Add(CommonUtil.btAddrFormat(addr));
            textBox2.Text += "dev : "+ blename + "\r\n";
            textBox2.Text += "addr: " + bleaddr + "\r\n";
            textBox2.Text += "-------------------------" + "\r\n";
            bleaddrmap.Add(bleaddr.ToString(), bleaddr);
        }

    }
}
