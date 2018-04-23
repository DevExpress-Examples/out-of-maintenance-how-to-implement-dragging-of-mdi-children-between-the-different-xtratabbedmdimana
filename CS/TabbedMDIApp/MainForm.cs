using System;
using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;

namespace DevExpress.Samples.DocumentSelector {
    public partial class MainForm : XtraForm {
        static int index = 0;
        public MainForm(StartForm owner) {
            index++;
            Owner = owner;
            InitializeComponent();
            Text += index.ToString();
            ((StartForm)Owner).Register(xtraTabbedMdiManager1);

            /*** Floating options ***/
            xtraTabbedMdiManager1.FloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            xtraTabbedMdiManager1.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            xtraTabbedMdiManager1.FloatPageDragMode = FloatPageDragMode.Preview;
            /*** To Show form Icons in page headers ***/
            xtraTabbedMdiManager1.UseFormIconAsPageImage = DefaultBoolean.True;

            xtraTabbedMdiManager1.BeginFloating += xtraTabbedMdiManager1_BeginFloating;
            xtraTabbedMdiManager1.FloatMDIChildDragging += xtraTabbedMdiManager1_FloatMDIChildDragging;
        }
        protected override void OnClosed(EventArgs e) {
            ((StartForm)Owner).UnRegister(xtraTabbedMdiManager1);
            base.OnClosed(e); 
        }
        void xtraTabbedMdiManager1_FloatMDIChildDragging(object sender, FloatMDIChildDraggingEventArgs e) {
            /* 
             * To allow an XtraTabbedMdiManager to accept a dragged panel, 
             * the manager needs to be added to the e.Targets collection.
             */
            IEnumerable<XtraTabbedMdiManager> dropTargets = ((StartForm)Owner).GetManagers();
            foreach(XtraTabbedMdiManager manager in dropTargets) 
                e.Targets.Add(manager);
        }
        void xtraTabbedMdiManager1_BeginFloating(object sender, FloatingCancelEventArgs e) {
            e.Cancel = false; // Allow all tab pages to be dragged away from XTraTabbedMDIManager
        }
        void Form1_Load(object sender, EventArgs e) {
            if(index % 2 == 0) {
                AddChild("Recent", "Shows the recently viewed photos");
                AddChild("Favourites", "My favourite photos");
            }
            else {
                AddChild("Published", "These photos are published in my blog");
                AddChild("Unsorted", "Not reviewed photos");
            }
        }
        public void AddChild(string category, string tag) {
            ChildForm categoryForm = new ChildForm();
            categoryForm.Text = category;
            categoryForm.MdiParent = this;
            categoryForm.Tag = tag;
            categoryForm.Show();
        }
    }
}