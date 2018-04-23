using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraTabbedMdi;

namespace DevExpress.Samples.DocumentSelector {
    public partial class StartForm : Form {
        IList<XtraTabbedMdiManager> managers;
        public StartForm() {
            managers = new List<XtraTabbedMdiManager>();
            InitializeComponent();
        }
        void Create_Click(object sender, EventArgs e) {
            new MainForm(this).Show();
        }
        void CloseAll_Click(object sender, EventArgs e) {
            XtraTabbedMdiManager[] array = new XtraTabbedMdiManager[managers.Count];
            managers.CopyTo(array, 0);
            for(int i = 0; i < array.Length; i++) 
                array[i].MdiParent.Close();
        }
        public void Register(XtraTabbedMdiManager manager) {
            if(!managers.Contains(manager))
                managers.Add(manager);
        }
        public void UnRegister(XtraTabbedMdiManager manager) {
            managers.Remove(manager);
        }
        public IEnumerable<XtraTabbedMdiManager> GetManagers() {
            return managers;
        }
    }
}