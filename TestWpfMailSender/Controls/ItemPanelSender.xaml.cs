using System;
using System.Collections;
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
using WpfMailSender.lib.Commands.Base;

namespace TestWpfMailSender.Controls
{
    /// <summary>
    /// Логика взаимодействия для ItemPanelSender.xaml
    /// Свойства зависимости для Title
    /// Для свойства зависимости. Нужно в название public static readonly DependencyProperty
    /// Должно присуствуват название свойства которуму делаем привязку
    /// public static readonly DependencyProperty TitleProperty
    /// Далее регистрируем обьект
    /// nameof -  указываем к кокому свойству привязка
    /// typeof- Тип данных свойства
    /// typeof - Тип свойства которуму принадлижит панель
    /// new PropertyMetadata(default  Задать дополнитльные мета данные  где указываем деволтное значения
    /// 
    /// </summary>
    public partial class ItemPanelSender : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(ItemPanelSender),
            new PropertyMetadata(default(string)));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty,value);
        }

        #region ICommand Добавления нового элемента 
        public static readonly DependencyProperty AddNwItemCoomandProperty =
            DependencyProperty.Register(
                nameof(AddNewItemCoomand),
                typeof(ICommand),
                typeof(ItemPanelSender),
                new PropertyMetadata(default(ICommand)));

        [Description("Добавления нового элемента")]
        public ICommand AddNewItemCoomand
        {
            get => (ICommand)GetValue(AddNwItemCoomandProperty);
            set => SetValue(AddNwItemCoomandProperty, value);
        }

        #endregion
        #region ICommand Редактированние элемента 
        public static readonly DependencyProperty EditItemCoomandProperty =
            DependencyProperty.Register(
                nameof(EditItemCoomand),
                typeof(ICommand),
                typeof(ItemPanelSender),
                new PropertyMetadata(default(ICommand)));

        [Description("Редактированние элемента")]
        public ICommand EditItemCoomand
        {
            get => (ICommand)GetValue(EditItemCoomandProperty);
            set => SetValue(EditItemCoomandProperty, value);
        }

        #endregion
        #region ICommand Удаления элемента 
        public static readonly DependencyProperty RemoveItemCoomandProperty =
            DependencyProperty.Register(
                nameof(RemoveItemCoomand),
                typeof(ICommand),
                typeof(ItemPanelSender),
                new PropertyMetadata(default(ICommand)));

        [Description("Удаления элемента")]
        public ICommand RemoveItemCoomand
        {
            get => (ICommand)GetValue(RemoveItemCoomandProperty);
            set => SetValue(RemoveItemCoomandProperty, value);
        }

        #endregion
        #region IEnumerable Элемент панели 
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register(
                nameof(ItemSource),
                typeof(IEnumerable),
                typeof(ItemPanelSender),
                new PropertyMetadata(default(IEnumerable)));

        [Description("Элемент панели")]
        public IEnumerable ItemSource
        {
            get => (IEnumerable)GetValue(ItemSourceProperty);
            set => SetValue(ItemSourceProperty, value);
        }

        #endregion
        #region object Выбранный элемент 
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(object),
                typeof(ItemPanelSender),
                new PropertyMetadata(default(object)));

        [Description("Выбранный элемент")]
        public object SelectedItem
        {
            get => (object)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        #endregion
        #region ItemTemplate Шаблон элемента выпадающего из списка 
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register(
                nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(ItemPanelSender),
                new PropertyMetadata(default(DataTemplate)));

        [Description("ItemTemplate Шаблон элемента выпадающего из списка")]
        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        #endregion
        #region DisplayMeberPath string - Имя отображаемого свойства 
        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(
                nameof(DisplayMemberPath),
                typeof(string),
                typeof(ItemPanelSender),
                new PropertyMetadata(default(string)));

        [Description("DisplayMeberPath string - Имя отображаемого свойства")]
        public string DisplayMemberPath
        {
            get => (string)GetValue(DisplayMemberPathProperty);
            set => SetValue(DisplayMemberPathProperty, value);
        }

        #endregion 
        public ItemPanelSender() => InitializeComponent();
    }
}
