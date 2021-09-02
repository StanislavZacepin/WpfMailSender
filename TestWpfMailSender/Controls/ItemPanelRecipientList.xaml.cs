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

namespace TestWpfMailSender.Controls
{
    /// <summary>
    /// Логика взаимодействия для ItemPanelRecipientList.xaml
    ///  Свойства зависимости для Title
    /// Для свойства зависимости. Нужно в название public static readonly DependencyProperty
    /// Должно присуствуват название свойства которуму делаем привязку
    /// public static readonly DependencyProperty TitleProperty
    /// Далее регистрируем обьект
    /// nameof -  указываем к кокому свойству привязка
    /// typeof- Тип данных свойства
    /// typeof - тип свойства которуму принадлижит панель
    /// new PropertyMetadata(default  Задать дополнитльные мета данные  где указываем деволтное значения
    /// </summary>
    public partial class ItemPanelRecipientList : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(ItemPanelRecipientList),
            new PropertyMetadata(default(string)));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        

            
        public ItemPanelRecipientList() => InitializeComponent();
    }
}
