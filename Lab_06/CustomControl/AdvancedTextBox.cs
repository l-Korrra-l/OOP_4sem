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

namespace CustomControl
{
    /// <summary>
    /// Выполните шаги 1a или 1b, а затем 2, чтобы использовать этот пользовательский элемент управления в файле XAML.
    ///
    /// Шаг 1a. Использование пользовательского элемента управления в файле XAML, существующем в текущем проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControl"
    ///
    ///
    /// Шаг 1б. Использование пользовательского элемента управления в файле XAML, существующем в другом проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControl;assembly=CustomControl"
    ///
    /// Потребуется также добавить ссылку из проекта, в котором находится файл XAML,
    /// на данный проект и заново выполнить построение во избежание ошибок компиляции:
    ///
    ///     Щелкните правой кнопкой мыши нужный проект в обозревателе решений и выберите
    ///     "Добавить ссылку"->"Проекты"->[Выберите этот проект]
    ///
    ///
    /// Шаг 2)
    /// Продолжайте дальше и используйте элемент управления в файле XAML.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    /// 

    [TemplatePart(Name = "Part_TexBox", Type = typeof(TextBox))]
    [TemplatePart(Name="Part_Icon", Type=typeof(Image))]

    public enum TextBoxType
    {
        Clear,
        BrowseFile,
        BrowseFolder
    }

    public class AdvancedTextBox : Control
    {
        static AdvancedTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AdvancedTextBox), new FrameworkPropertyMetadata(typeof(AdvancedTextBox)));
        }

        public TextBoxType Type
        {
            get { return (TextBoxType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }


            public static readonly DependencyProperty TypeProperty = DependencyProperty.Register("Type", typeof(TextBoxType),
                typeof(AdvancedTextBox), new FrameworkPropertyMetadata(TextBoxType.Clear, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        TextBox _textBox;
        Image _buttonIcon;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (this.Template!=null)
            {
                _textBox = this.Template.FindName("Part_TextBox",this) as TextBox;
                _buttonIcon = this.Template.FindName("Part_Icon", this) as Image;

                if(_textBox!=null && _buttonIcon!=null)
                {
                    if(Type == TextBoxType.BrowseFile)
                    {
                        _buttonIcon.PreviewMouseDown += BrowseFile;
                    }                    
                    else  if(Type == TextBoxType.BrowseFolder)
                    {
                        _buttonIcon.PreviewMouseDown += BrowseFolder;
                    }                    
                    else
                    {
                        _buttonIcon.PreviewMouseDown += Clear;
                    }
                }
            }
        }

        private void Clear(object sender, MouseButtonEventArgs e)
        {
            _textBox.Clear();
        }

        private void BrowseFolder(object sender, MouseButtonEventArgs e)
        {
            var folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            if (folderBrowser.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                _textBox.Text = folderBrowser.SelectedPath;
            }
        }

        private void BrowseFile(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                _textBox.Text = openFileDialog.FileName;
            }
        }
    }
}
