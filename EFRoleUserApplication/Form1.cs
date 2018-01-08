using EFRoleUserApplication.Context;
using EFRoleUserApplication.Entities;
using EFRoleUserApplication.Services;
using EFRoleUserApplication.Validation.FluentValidator;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFRoleUserApplication
{
    public partial class Form1 : Form
    {
        private ServicePoint sPoint = ServicePoint.GetInstance();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProjectContext context = new ProjectContext();
            var lst = context.AppUsers.FirstOrDefault();

            UserAccount a = new UserAccount(lst.Id);

            //tool kullanmadan öncesi
            ApplicationUser user = new ApplicationUser();
            user.UserName = "mtatest";
            user.Email = "mert.alptekin@wissenakademie.com";
            user.Password = "Pa$$W0rd1";


            var r = sPoint.userService.Insert(user);

            var data = sPoint.userService.Select().FirstOrDefault();
            data.Email = "mytest@test.com";

            var r1 = sPoint.userService.Update(data);


            sPoint.userService.Select();
            //ServicePoint.GetInstance().Dispose(true);

            foreach (var item in r.Errors)
            {
                MessageBox.Show(item.ErrorMessage);
            }

            //UserService service = new UserService();
            //Dictionary<string,string> errors =  service.Insert(user);

        }
    }
}
