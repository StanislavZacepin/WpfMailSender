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

namespace TestWpfMailSender.Controls
{
    /// <summary>
    /// Логика взаимодействия для ItemPanelServers.xaml
    /// </summary>
    public partial class ItemPanelServers : UserControl
    {
        public readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(ItemPanelServers),
            new PropertyMetadata(default(string)));
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public ItemPanelServers() => InitializeComponent();
    }
}
