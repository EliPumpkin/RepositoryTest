using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Reflection;
using System.Threading;
using System.Reflection;
using System.ComponentModel;
namespace Wpf_Clock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            SolidColorBrush brush = new SolidColorBrush ();
            brush.Color=Colors.Blue;
            this.Rec.Fill = brush;
            //判断
            bool f;
            Mutex ml = new Mutex(true, "xxx", out f);
            if (!f)
            {
                Console.WriteLine("不能同时本运行程序两次");
                return;
            }
            Console.WriteLine("启动成功!");
            Console.ReadLine();

            DemoTypeOf<int>();
            //获取类型信息
            Type t = Type.GetType("TestSpace.TestClass");
            //构造器的参数
            object[] constuctParms = new object[] { "timmy" };
            //根据类型创建对象
            object dObj = Activator.CreateInstance(t, constuctParms);
            //获取方法的信息
            MethodInfo method = t.GetMethod("GetValue");
            //调用方法的一些标志位，这里的含义是Public并且是实例方法，这也是默认的值
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance;
            //GetValue方法的参数
            object[] parameters = new object[] { "Hello" };
            //调用方法，用一个object接收返回值
            object returnValue = method.Invoke(dObj, flag, Type.DefaultBinder, parameters, null);
            MessageBox.Show(t.ToString());            
            //string[] aba = System.Configuration.ConfigurationManager.AppSettings["Demo"].Split(',');
            MethodInfo info = t.GetMethod("Plus");
            object[] paras = new object[] { 2, 5 };
            object value = info.Invoke(dObj, flag, Type.DefaultBinder, paras, null);
            MessageBox.Show(value.ToString());
            FontSizeChange();
        }

        private void FontSizeChange()
        {
            System.Windows.Application.Current.Resources.Remove("DemoFontSize");  
            double size = ((SystemParameters.PrimaryScreenWidth / 12) / 3 * 2) / 5 * 0.8;
            System.Windows.Application.Current.Resources.Add("DemoFontSize",size);
        }
        public static void DemoTypeOf<X>()
        {
            MessageBox.Show(typeof(X).ToString()+"||||"+typeof(List<>)+"||||"+typeof(List<X>)+"||||"+typeof(List<long>));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Human h = (Human)this.FindResource("human");
            //MessageBox.Show(h.Child.Name);
            TestWindow tw = new TestWindow();
            tw.ShowDialog();
        }
    }
    [TypeConverter(typeof(MyTypeConvert))]
    public class Human
    {
        public string Name { get; set; }
        public Human Child { get; set; }
    }
    
}
namespace TestSpace
{
    public class TestClass
    {
        private string _value;
        public TestClass()
        {
        }
        public TestClass(string value)
        {
            _value = value;
        }

        public string GetValue(string prefix)
        {
            if (_value == null)
                return "NULL";
            else
                return prefix + "  :  " + _value;
        }

        public string Value
        {
            set
            {
                _value = value;
            }
            get
            {
                if (_value == null)
                    return "NULL";
                else
                    return _value;
            }
        }
        public string Plus(int a, int b)
        {
            return (a + b).ToString();
        }
        public T Demo<T,X>(X para) where T: class  where X :struct
        {
            throw new NotImplementedException();
        }
    }
}
