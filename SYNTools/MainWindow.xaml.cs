using SYNTools.src.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SYNTools
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void setTextBoxOldGate(string text);
        private void setTextBoxOld(string text)
        {
            if (TextBoxOld.Dispatcher.Thread!=Thread.CurrentThread)
            {
                setTextBoxOldGate sg = new setTextBoxOldGate(setTextBoxOld);
                Dispatcher.Invoke(sg, new object[] { text });
            }
            else
            {
                TextBoxOld.Text = text;
            }
        }
        private delegate void setButtonOldGate(bool flag);
        private void setButtonOld(bool flag)
        {
            if (ButtonOld.Dispatcher.Thread != Thread.CurrentThread)
            {
                setButtonOldGate sg = new setButtonOldGate(setButtonOld);
                Dispatcher.Invoke(sg, new object[] { flag });
            }
            else
            {
                ButtonOld.IsEnabled = flag;
            }
        }
        
        private delegate void setTextBoxNewGate(string text);
        private void setTextBoxNew(string text)
        {
            if (TextBoxNew.Dispatcher.Thread != Thread.CurrentThread)
            {
                setTextBoxNewGate sg = new setTextBoxNewGate(setTextBoxNew);
                Dispatcher.Invoke(sg, new object[] { text });
            }
            else
            {
                TextBoxNew.Text = text;
            }
        }
        private delegate void setButtonNewGate(bool flag);
        private void setButtonNew(bool flag)
        {
            if (ButtonNew.Dispatcher.Thread != Thread.CurrentThread)
            {
                setButtonNewGate sg = new setButtonNewGate(setButtonNew);
                Dispatcher.Invoke(sg, new object[] { flag });
            }
            else
            {
                ButtonNew.IsEnabled = flag;
            }
        }
       
       
        private delegate void setButtonSaveGate(bool flag);
        private void setButtonSave(bool flag)
        {
            if (ButtonSave.Dispatcher.Thread != Thread.CurrentThread)
            {
                setButtonSaveGate sg = new setButtonSaveGate(setButtonSave);
                Dispatcher.Invoke(sg, new object[] { flag });
            }
            else
            {
                ButtonSave.IsEnabled = flag;
            }
        }
        private delegate void setComboBoxSaveGate(string item);
        private void setComboBoxSave(string item)
        {
            if (ComboBoxSave.Dispatcher.Thread != Thread.CurrentThread)
            {
                setComboBoxSaveGate sg = new setComboBoxSaveGate(setComboBoxSave);
                Dispatcher.Invoke(sg, new object[] { item });
            }
            else
            {
                ComboBoxSave.Items.Add(item);
                ComboBoxSave.SelectedItem = item;
            }
        }
        private delegate void setComboBoxSaveDeleteGate(string item);
        private void setComboBoxSaveDelete(string item)
        {
            if (ComboBoxSave.Dispatcher.Thread != Thread.CurrentThread)
            {
                setComboBoxSaveDeleteGate sg = new setComboBoxSaveDeleteGate(setComboBoxSaveDelete);
                Dispatcher.Invoke(sg, new object[] { item });
            }
            else
            {
                ComboBoxSave.Items.Remove(item);
                //ComboBoxSave.SelectedIndex = ComboBoxSave.Items.Count - 1;
            }
        }
        private delegate void setButtonDeleteGate(bool flag);
        private void setButtonDelete(bool flag)
        {
            if (ButtonDelete.Dispatcher.Thread != Thread.CurrentThread)
            {
                setButtonDeleteGate sg = new setButtonDeleteGate(setButtonDelete);
                Dispatcher.Invoke(sg, new object[] { flag });
            }
            else
            {
                ButtonDelete.IsEnabled = flag;
            }
        }
        private delegate void setListBoxHistoryGate(string item);
        private void setListBoxHistory(string item)
        {
            if (ListBoxHistory.Dispatcher.Thread != Thread.CurrentThread)
            {
                setListBoxHistoryGate sg = new setListBoxHistoryGate(setListBoxHistory);
                Dispatcher.Invoke(sg, new object[] { item });
            }
            else
            {
                ListBoxHistory.Items.Add(ListBoxHistory.Items.Count+1+": "+ item);
                ListBoxHistory.SelectedIndex = ListBoxHistory.Items.Count - 1;
                ListBoxHistory.ScrollIntoView(ListBoxHistory.SelectedItem);
                //ListBoxHistory.SelectedItem = ListBoxHistory.Items.GetItemAt(ListBoxHistory.Items.Count - 1);
                //ListBoxHistory.ScrollIntoView(ListBoxHistory.Items.GetItemAt(ListBoxHistory.Items.Count - 1));
            }
        }
        private delegate void setLabelHistoryGate(string content);
        private void setLabelHistory(string content)
        {
            if (LabelHistory.Dispatcher.Thread != Thread.CurrentThread)
            {
                setLabelHistoryGate sg = new setLabelHistoryGate(setLabelHistory);
                Dispatcher.Invoke(sg, new object[] { content });
            }
            else
            {
                LabelHistory.Content = content;
            }
        }
        private delegate void setButtonAbortGate(bool flag);
        private void setButtonAbort(bool flag)
        {
            if (ButtonAbort.Dispatcher.Thread != Thread.CurrentThread)
            {
                setButtonAbortGate sg = new setButtonAbortGate(setButtonAbort);
                Dispatcher.Invoke(sg, new object[] { flag });
            }
            else
            {
                ButtonAbort.IsEnabled = flag;
            }
        }
        private delegate void setProgressBarStartGate(int maximum,int value);
        private void setProgressBarStart(int maximum, int value)
        {
            if (ProgressBarStart.Dispatcher.Thread != Thread.CurrentThread)
            {
                setProgressBarStartGate sg = new setProgressBarStartGate(setProgressBarStart);
                Dispatcher.Invoke(sg, new object[] { maximum,value });
            }
            else
            {
                ProgressBarStart.Maximum = maximum;
                ProgressBarStart.Value = value;
            }
        }
        private delegate void setButtonStartGate(bool flag);
        private void setButtonStart(bool flag)
        {
            if (ButtonStart.Dispatcher.Thread != Thread.CurrentThread)
            {
                setButtonStartGate sg = new setButtonStartGate(setButtonStart);
                Dispatcher.Invoke(sg, new object[] { flag });
            }
            else
            {
                ButtonStart.IsEnabled = flag;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void buttonOldClickThread()
        {

        }
        private void buttonOldClick()
        {
            try
            {
                Thread thread = new Thread(buttonOldClickThread);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                setListBoxHistory(ex.Message);
            }
        }
        private void ButtonOld_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = false;
            fb.Description = "请选择源文件夹";
            fb.ShowDialog();
            if (fb.SelectedPath != "")
            {
                TextBoxOld.Text = fb.SelectedPath;
            }
            fb.Dispose();
        }
        private void buttonNewClickThread()
        {
            
        }
        private void buttonNewClick()
        {
            try
            {
                Thread thread = new Thread(buttonNewClickThread);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                setListBoxHistory(ex.Message);
            }
        }
        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;
            fb.Description = "请选择目标文件夹";
            fb.ShowDialog();
            if (fb.SelectedPath != "")
            {
                TextBoxNew.Text = fb.SelectedPath;
            }
            fb.Dispose();
        }
        private void buttonSaveClickThread()
        {
            //setButtonSave(false);
            //List<string> files = new List<string>();
            //List<string> errors = new List<string>();
            //UFile.getFiles("D:/programs", ref files,ref errors);
            //if (errors.Count==0)
            //{
            //    for (int i = 0; i < files.Count; i++)
            //    {
            //        setListBoxHistory(files[i]);
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < errors.Count; i++)
            //    {
            //        setListBoxHistory(errors[i]);
            //    }
            //}
            //setButtonSave(true);
        }
        private void buttonSaveClick()
        {
            try
            {
                Thread thread = new Thread(buttonSaveClickThread);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                setListBoxHistory(ex.Message);
            }
        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            ListBoxHistory.Items.Clear();
            if (TextBoxOld.Text.Equals("") || TextBoxNew.Text.Equals(""))
            {
                setListBoxHistory("请选择文件夹");
                return;
            }
            else
            {
               string o  = TextBoxOld.Text;
               string n  = TextBoxNew.Text;

                if (
                     o.EndsWith("\\") || n.EndsWith("\\") ||
                     o.EndsWith("/") || n.EndsWith("/") ||
                     o.EndsWith(":") || n.EndsWith(":") ||
                     o.EndsWith("*") || n.EndsWith("*") ||
                     o.EndsWith("?") || n.EndsWith("?") ||
                     o.EndsWith("\"") || n.EndsWith("\"") ||
                     o.EndsWith("<") || n.EndsWith("<") ||
                     o.EndsWith(@">") || n.EndsWith(">") ||
                     o.EndsWith("|") || n.EndsWith("|")
                    )
                {
                    setListBoxHistory("输入的文件夹名不能以下列任何字符结尾 \\ / : * ? \" < > |");

                }
                else
                {
                    if (Directory.Exists(o))
                    {
                        if (Directory.Exists(n))
                        {


                            ListBoxHistory.Items.Clear();
                            string oldPath = TextBoxOld.Text;
                            string oldError = null;
                            string newPath = TextBoxNew.Text;
                            string newError = null;
                            string oldDriver = UFile.getDriverName(oldPath, ref oldError);
                            string newDeiver = UFile.getDriverName(newPath, ref newError);
                            if (oldError != null)
                            {
                                setListBoxHistory(oldError);
                                return;
                            }
                            if (newError != null)
                            {
                                setListBoxHistory(newError);
                                return;
                            }
                            string oldLast = UFile.getLastDir(oldPath);
                            string newLast = UFile.getLastDir(newPath);

                            string name = oldDriver + ":\\...\\" + oldLast + " -> " + newDeiver + ":\\...\\" + newLast;
                            string confError = null;
                            bool flag = UConfig.writeAll(name, oldPath, newPath, "是", ref confError);
                            if (confError != null)
                            {
                                setListBoxHistory(confError);
                                return;
                            }
                            else
                            {
                                setListBoxHistory("保存成功");
                                if (flag)
                                {
                                    setComboBoxSave(name);
                                }
                            }

                        }
                        else
                        {
                            setListBoxHistory("目标文件夹不存在");
                        }
                    }
                    else
                    {
                        setListBoxHistory("源文件夹不存在");
                    }
                }
            }

            
        }
        private string comboName="";
        private delegate void setComboNameGate();
        private void setComboName(){
            if (ComboBoxSave.Dispatcher.Thread!=Thread.CurrentThread)
            {
                setComboNameGate sg = new setComboNameGate(setComboName);
                Dispatcher.Invoke(sg, new object[] { });
            }
            else
            {
                comboName = ComboBoxSave.SelectedItem.ToString();
            }
        }
        private void buttonDeleteClickThread()
        {
            string error = null;
            UConfig.delete("comboName",ref error);
            if (error!=null)
            {
                setListBoxHistory(error);
                return;
            }
            setComboBoxSaveDelete(comboName);
        }
        private void buttonDeleteClick()
        {
            try
            {
                Thread thread = new Thread(buttonDeleteClickThread);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                setListBoxHistory(ex.Message);
            }
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            
                if ("".Equals(comboName))
                {
                    ListBoxHistory.Items.Clear();
                    setListBoxHistory("已清空");
                }
                else
                {

            MessageBoxResult result = System.Windows.MessageBox.Show("是否删除?", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                ListBoxHistory.Items.Clear();
                    ListBoxHistory.Items.Clear();
                    flagComboBoxSave_SelectionChanged = false;
                    string error = null;
                    UConfig.delete(comboName, ref error);
                    if (error != null)
                    {
                        setListBoxHistory(error);
                        return;
                    }
                    ComboBoxSave.Items.Remove(comboName);
                    if (ComboBoxSave.Items.Count != 0)
                    {
                        setListBoxHistory("删除 " + comboName + " 成功");
                        ComboBoxSave.SelectedIndex = 0;
                        comboName = ComboBoxSave.SelectedItem.ToString();
                        readConfigs();
                        setTextBoxOld(configs[0]);
                        setTextBoxNew(configs[1]);


                    }
                    else
                    {
                        setListBoxHistory("删除 " + comboName + " 成功");
                        comboName = "";
                        setTextBoxOld("");
                        setTextBoxNew("");

                    }
                    flagComboBoxSave_SelectionChanged = true;
                }
            }

            
            
           // setComboBoxSaveDelete(comboName);
        }
        private void ButtonAbort_Click(object sender, RoutedEventArgs e)
        {
            thread.Abort();
            thread.Join();
            setButtonAbort(false);
            setButtonStart(true);
        }
        private void buttonStartClickThread()
        {
        }
        private void buttonStartClick()
        {
            try
            { 
                Thread thread = new Thread(buttonStartClickThread);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                setListBoxHistory(ex.Message);
            }
        }
        private string oldPath = "";
        private string newPath = "";
        private Thread thread = null;
        private void run()
        {
            setButtonStart(false);
            setButtonAbort(true);
            setListBoxHistory("正在开始同步");
            setLabelHistory("正在开始同步");
            int maximum = 0; 
            int value = 0;
            List<string> errors = new List<string>();
            List<string> oldFiles = UFile.getFiles(oldPath, ref errors);
            List<string> newFiles = UFile.getFiles(newPath, ref errors);
            List<string> oldDirs = UFile.getDirs(oldPath, ref errors);
            List<string> newDirs = UFile.getDirs(newPath, ref errors);
            if (errors.Count > 0)
            {
                for (int i = 0; i < errors.Count; i++)
                {
                    //Console.WriteLine(errors[i]);
                    setListBoxHistory(errors[i]);
                }
                return;
            }
            maximum = oldDirs.Count;
            value = 0;
            setListBoxHistory("(1/4)正在复制文件夹" );
            setLabelHistory("(1/4)正在复制文件夹");
            foreach (string oldDir in oldDirs)
            {
                if (UFile.copyDir(oldDir, oldPath, newPath, ref errors))
                {
                    setListBoxHistory("(1/4)正在复制文件夹: " + oldDir);
                    setLabelHistory("(1/4)正在复制文件夹: " + oldDir);
                } 
                value++;
                setProgressBarStart(maximum, value);
            }
            if (errors.Count > 0)
            {
                for (int i = 0; i < errors.Count; i++)
                {
                    setListBoxHistory(errors[i]);
                }
                return;
            }
            maximum = oldFiles.Count;
            value = 0;
            setListBoxHistory("(2/4)正在复制文件");
            setLabelHistory("(2/4)正在复制文件");
            foreach (string oldFile in oldFiles)
            {
                if (UFile.copyFile(oldFile, oldPath, newPath, ref errors))
                {
                    setListBoxHistory("(2/4)正在复制文件: " + oldFile);
                    setLabelHistory("(2/4)正在复制文件: " + oldFile);
                }
                value++;
                setProgressBarStart(maximum, value);
            }
            if (errors.Count > 0)
            {
                for (int i = 0; i < errors.Count; i++)
                {
                    setListBoxHistory(errors[i]);
                }
                return;
            }
            //删除在newFiles里不在oldFiles里的File
            maximum = newFiles.Count;
            value = 0;
            setListBoxHistory("(3/4)正在删除文件" );
            setLabelHistory("(3/4)正在删除文件");
            foreach (string newFile in newFiles)
            {
                if (UFile.delFile(newFile, oldPath, newPath, ref errors))
                {
                    setListBoxHistory("(3/4)正在删除文件: " + newFile);
                    setLabelHistory("(3/4)正在删除文件: " + newFile);
                }
                value++;
                setProgressBarStart(maximum, value);
            }
            if (errors.Count > 0)
            {
                for (int i = 0; i < errors.Count; i++)
                {
                    setListBoxHistory(errors[i]);
                }
                return;
            }
            maximum = newDirs.Count;
            value = 0;
            //删除在newDirs里不在oldDirs里的Dir
            setListBoxHistory("(4/4)正在删除文件夹");
            setLabelHistory("(4/4)正在删除文件夹");
            foreach (string newDir in newDirs)
            {
                if (UFile.delDir(newDir, oldPath, newPath, ref errors))
                {
                    setListBoxHistory("(4/4)正在删除文件夹: " + newDir);
                    setLabelHistory("(4/4)正在删除文件夹: " + newDir);
                }
                value++;
                setProgressBarStart(maximum, value);
            }
            if (errors.Count > 0)
            {
                for (int i = 0; i < errors.Count; i++)
                {
                    setListBoxHistory(errors[i]);
                }
                return;
            }
            setButtonStart(true);
            setButtonAbort(false);
            setLabelHistory("同步成功");
            setListBoxHistory("同步成功");
        }
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            ListBoxHistory.Items.Clear();
            if (TextBoxOld.Text.Equals("") || TextBoxNew.Text.Equals(""))
            {
                setListBoxHistory("请选择文件夹");
                return;
             }
            else
            {
                oldPath = TextBoxOld.Text;
                newPath = TextBoxNew.Text;
                
                if (
                     oldPath.EndsWith("\\") || newPath.EndsWith("\\") ||
                     oldPath.EndsWith("/") || newPath.EndsWith("/") ||
                     oldPath.EndsWith(":") || newPath.EndsWith(":") ||
                     oldPath.EndsWith("*") || newPath.EndsWith("*") ||
                     oldPath.EndsWith("?") || newPath.EndsWith("?") ||
                     oldPath.EndsWith("\"") || newPath.EndsWith("\"") ||
                     oldPath.EndsWith("<") || newPath.EndsWith("<") ||
                     oldPath.EndsWith(@">") || newPath.EndsWith(">") ||
                     oldPath.EndsWith("|") || newPath.EndsWith("|")
                    )
                {
                    setListBoxHistory("输入的文件夹名不能以下列任何字符结尾 \\ / : * ? \" < > |");
                  
                         }
                else
                {
                    if (Directory.Exists(oldPath))
                    {
                        if (Directory.Exists(newPath))
                        {
                            
                                MessageBoxResult result = System.Windows.MessageBox.Show("是否开始同步?", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                                if (result == MessageBoxResult.OK)
                                {
                                    ListBoxHistory.Items.Clear();
                                    ProgressBarStart.Value = 0;
                                    thread = new Thread(run);
                                    thread.IsBackground = true;
                                    thread.Start();
                                }
                            
                           
                        }
                        else
                        {
                            setListBoxHistory("目标文件夹不存在");
                                 }
                    }
                    else
                    {
                        setListBoxHistory("源文件夹不存在");
                            }
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setListBoxHistory("By.");
            setListBoxHistory("QQ: 183515951");
            setListBoxHistory("听风吹雨作品");
            string tp = null;
            try
            {
                tp = Directory.GetCurrentDirectory();
            }
            catch (Exception ex)
            {
                setListBoxHistory(ex.Message);
                flagComboBoxSave_SelectionChanged = true;
                return;
            }
            if (File.Exists(tp + "/conf.txt"))
            {
                string error = null;
                List<string> list = new List<string>();
                list = UConfig.readComboName(ref error);
                if (error != null)
                {
                    setListBoxHistory(error);
                    flagComboBoxSave_SelectionChanged = true;
                    return;
                }
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        setComboBoxSave(list[i]);
                    }
                    comboName = ComboBoxSave.SelectedItem.ToString();
                    readConfigs();
                    setTextBoxOld(configs[0]);
                    setTextBoxNew(configs[1]);
                    flagComboBoxSave_SelectionChanged = true;
                }
                else
                {
                    flagComboBoxSave_SelectionChanged = true;
                    setListBoxHistory("配置文件为空");
                }
            }
            else
            {
                flagComboBoxSave_SelectionChanged = true;
                setListBoxHistory("配置文件不存在");
            }
        }
        private string[] configs = null;
        private void readConfigs()
        {
            string error = null;
            configs = UConfig.readAll(comboName, ref error);
            if (error != null)
            {
                setListBoxHistory(error);
                return;
            }
        }
        private bool flagComboBoxSave_SelectionChanged = false;
        private void ComboBoxSave_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flagComboBoxSave_SelectionChanged)
            {
                comboName = ComboBoxSave.SelectedItem.ToString();
                readConfigs();
                setTextBoxOld(configs[0]);
                setTextBoxNew(configs[1]);
            }
        }
       
      
    }
}
