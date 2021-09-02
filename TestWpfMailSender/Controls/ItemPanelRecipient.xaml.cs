using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для ItemPanelRecipient.xaml
    /// </summary>
    public partial class ItemPanelRecipient : UserControl
    {
        public readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(ItemPanelRecipient),
            new PropertyMetadata(default(string)));
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty,value);
        }

        #region Добавления нового элемента 
        public static readonly DependencyProperty AddNwItemCoomandProperty =
            DependencyProperty.Register(
                nameof(AddNewItemCoomand),
                typeof(ICommand),
                typeof(ItemPanelRecipient),
                new PropertyMetadata(default(ICommand)));

        [Description("Добавления нового элемента")]
        public ICommand AddNewItemCoomand
        {
            get => (ICommand)GetValue(AddNwItemCoomandProperty);
            set => SetValue(AddNwItemCoomandProperty, value);
        }

        #endregion
        #region Редактированние элемента 
        public static readonly DependencyProperty EditItemCoomandProperty =
            DependencyProperty.Register(
                nameof(EditItemCoomand),
                typeof(ICommand),
                typeof(ItemPanelRecipient),
                new PropertyMetadata(default(ICommand)));

        [Description("Редактированние элемента")]
        public ICommand EditItemCoomand
        {
            get => (ICommand)GetValue(EditItemCoomandProperty);
            set => SetValue(EditItemCoomandProperty, value);
        }

        #endregion
        #region Удаления элемента 
        public static readonly DependencyProperty RemoveItemCoomandProperty =
            DependencyProperty.Register(
                nameof(RemoveItemCoomand),
                typeof(ICommand),
                typeof(ItemPanelRecipient),
                new PropertyMetadata(default(ICommand)));

        [Description("Удаления элемента")]
        public ICommand RemoveItemCoomand
        {
            get => (ICommand)GetValue(RemoveItemCoomandProperty);
            set => SetValue(RemoveItemCoomandProperty, value);
        }

        #endregion
        public ItemPanelRecipient() => InitializeComponent();
    }
}
