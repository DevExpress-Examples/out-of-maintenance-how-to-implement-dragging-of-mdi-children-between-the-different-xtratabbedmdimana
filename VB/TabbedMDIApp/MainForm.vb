Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTabbedMdi

Namespace DevExpress.Samples.DocumentSelector
	Partial Public Class MainForm
		Inherits XtraForm
		Private Shared index As Integer = 0
		Public Sub New(ByVal owner As StartForm)
			index += 1
			Me.Owner = owner
			InitializeComponent()
			Text &= index.ToString()
			CType(Me.Owner, StartForm).Register(xtraTabbedMdiManager1)

			'** Floating options **
			xtraTabbedMdiManager1.FloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True
			xtraTabbedMdiManager1.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True
			xtraTabbedMdiManager1.FloatPageDragMode = FloatPageDragMode.Preview
			'** To Show form Icons in page headers **
			xtraTabbedMdiManager1.UseFormIconAsPageImage = DefaultBoolean.True

			AddHandler xtraTabbedMdiManager1.BeginFloating, AddressOf xtraTabbedMdiManager1_BeginFloating
			AddHandler xtraTabbedMdiManager1.FloatMDIChildDragging, AddressOf xtraTabbedMdiManager1_FloatMDIChildDragging
		End Sub
		Protected Overrides Sub OnClosed(ByVal e As EventArgs)
			CType(Owner, StartForm).UnRegister(xtraTabbedMdiManager1)
			MyBase.OnClosed(e)
		End Sub
		Private Sub xtraTabbedMdiManager1_FloatMDIChildDragging(ByVal sender As Object, ByVal e As FloatMDIChildDraggingEventArgs)
'             
'             * To allow an XtraTabbedMdiManager to accept a dragged panel, 
'             * the manager needs to be added to the e.Targets collection.
'             
			Dim dropTargets As IEnumerable(Of XtraTabbedMdiManager) = (CType(Owner, StartForm)).GetManagers()
			For Each manager As XtraTabbedMdiManager In dropTargets
				e.Targets.Add(manager)
			Next manager
		End Sub
		Private Sub xtraTabbedMdiManager1_BeginFloating(ByVal sender As Object, ByVal e As FloatingCancelEventArgs)
			e.Cancel = False ' Allow all tab pages to be dragged away from XTraTabbedMDIManager
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			If index Mod 2 = 0 Then
				AddChild("Recent", "Shows the recently viewed photos")
				AddChild("Favourites", "My favourite photos")
			Else
				AddChild("Published", "These photos are published in my blog")
				AddChild("Unsorted", "Not reviewed photos")
			End If
		End Sub
		Public Sub AddChild(ByVal category As String, ByVal tag As String)
			Dim categoryForm As New ChildForm()
			categoryForm.Text = category
			categoryForm.MdiParent = Me
			categoryForm.Tag = tag
			categoryForm.Show()
		End Sub
	End Class
End Namespace