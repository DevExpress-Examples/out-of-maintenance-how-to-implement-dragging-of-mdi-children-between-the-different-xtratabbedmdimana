Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.XtraTabbedMdi

Namespace DevExpress.Samples.DocumentSelector
	Partial Public Class StartForm
		Inherits Form
		Private managers As IList(Of XtraTabbedMdiManager)
		Public Sub New()
			managers = New List(Of XtraTabbedMdiManager)()
			InitializeComponent()
		End Sub
		Private Sub Create_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			CType(New MainForm(Me), MainForm).Show()
		End Sub
		Private Sub CloseAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			Dim array(managers.Count - 1) As XtraTabbedMdiManager
			managers.CopyTo(array, 0)
			For i As Integer = 0 To array.Length - 1
				array(i).MdiParent.Close()
			Next i
		End Sub
		Public Sub Register(ByVal manager As XtraTabbedMdiManager)
			If (Not managers.Contains(manager)) Then
				managers.Add(manager)
			End If
		End Sub
		Public Sub UnRegister(ByVal manager As XtraTabbedMdiManager)
			managers.Remove(manager)
		End Sub
		Public Function GetManagers() As IEnumerable(Of XtraTabbedMdiManager)
			Return managers
		End Function
	End Class
End Namespace