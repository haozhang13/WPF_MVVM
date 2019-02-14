using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMExample.Model;
using System.Windows.Input;
namespace WPFMVVMExample.ViewModel
{
    public class StudentViewModel
    {
        public StudentModel Student { get; set; }

        public List<StudentModel> STUS { get; set; }
        public DelegateCommand ShowCommand { get; set; }
        public DelegateCommand ShowCommand2 { get; set; }

        public DelegateCommand TestCommand { get; set; }
        private int a = 0;
        public StudentViewModel()
        {
            
            Student = new StudentModel();
            STUS = new List<StudentModel>();
           // Student.StudentId = 10;
            ShowCommand = new DelegateCommand();
            ShowCommand2 = new DelegateCommand();

            TestCommand = new DelegateCommand();
            ShowCommand.ExecuteCommand = new Action<object>(ShowStudentData);//执行命令
            ShowCommand2.ExecuteCommand = new Action<object>(ShowStudentData2);//执行命令
            TestCommand.ExecuteCommand = new Action<object>(Test);//执行命令

            //当满足某个条件时，才会执行命令
            //ShowCommand.CanExecuteCommand = new Func<object,bool>(CanShowStudentData);
        }

        public void Test(object o)
        {
            WaitWindow waitcontrol = new WaitWindow();

           
               // System.Windows.MessageBox.Show("The file type is wrong!");
                waitcontrol.Show();


            Task task = Task.Run(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        for (int m = 0; m < 1000; m++)
                        {

                        }
                    }
                }
            });

            task.Wait();
            System.Windows.MessageBox.Show("The file typewwg!");
            waitcontrol.Close();
        }
        public void ShowStudentData(object obj)
        {
            StudentModel studentModel = new StudentModel();
            Student.StudentId= studentModel.StudentId = a;
            Student.StudentName= studentModel.StudentName = "tiana";
            Student.StudentAge = studentModel.StudentAge = 20 +a;
            Student.StudentEmail = studentModel.StudentEmail = "8644003248@qq.com";
            Student.StudentSex =studentModel.StudentSex = "大帅哥";
            
            STUS.Add(studentModel);
            a++;
        }

        public void ShowStudentData2(object obj)
        {
            List<StudentModel> ss = new List<StudentModel>();
            ss.AddRange(STUS);
            STUS = new List<StudentModel>();
            STUS.AddRange(ss);
        }



    }

    public class DelegateCommand : ICommand
        {
            
            public Action<object> ExecuteCommand = null;
            public Func<object, bool> CanExecuteCommand = null;
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                if (CanExecuteCommand != null)
                {
                    return this.CanExecuteCommand(parameter);
                }
                else
                {
                    return true;
                }  
            }

            public void Execute(object parameter)
            {
                if (this.ExecuteCommand != null)
                {
                    this.ExecuteCommand(parameter);
                }
            }

            public void RaiseCanExecuteChanged()
            {
                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, EventArgs.Empty);
                }
            }  
        }
}
