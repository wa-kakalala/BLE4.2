using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Data;

// 异步搜索: http://t.csdn.cn/AcTcY
// 同步搜索: http://t.csdn.cn/jxgld
namespace BLE4._2
{
    public class Bt4AsyncScan 
    {
        public BluetoothClient bluetoothClient;
        public Bt4AsyncScan()
        {
            bluetoothClient = new BluetoothClient();
            // 未包含PrimaryRadio 问题 
            // https://blog.csdn.net/ksr12333/article/details/123358513
            BluetoothRadio bluetoothRadio = BluetoothRadio.PrimaryRadio;
            bluetoothRadio.Mode = RadioMode.Connectable;
        }

        public void Start_Scan(System.EventHandler<InTheHand.Net.Bluetooth.DiscoverDevicesEventArgs> baseFunc)
        {
            BluetoothComponent bluetoothComponent = new BluetoothComponent(bluetoothClient);
            // 开始异步扫描
            bluetoothComponent.DiscoverDevicesAsync(10, false, false, false, true, bluetoothComponent);
            // 扫描结果回调
            bluetoothComponent.DiscoverDevicesProgress += baseFunc;
        }

        public void Stop_Scan()
        {
            
        }
    }
}



