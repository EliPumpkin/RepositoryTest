﻿using System;
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

namespace Wpf_Clock
{
    /// <summary>
    /// Button.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonTest : Page
    {
        public ButtonTest()
        {
            InitializeComponent();
            Car car = new Car();
            car.SetBinding(Car.NameProperty, new Binding("text") { Source = TB1 });
            TB2.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = car });
        }
    }
    public class Car : DependencyObject
    {
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Car));
        
        //SetBinding 包装
        public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }
    }
}
