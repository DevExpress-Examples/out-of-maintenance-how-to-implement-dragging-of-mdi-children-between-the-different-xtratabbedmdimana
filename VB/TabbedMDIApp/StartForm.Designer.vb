Imports Microsoft.VisualBasic
Imports System
Namespace DevExpress.Samples.DocumentSelector
	Partial Public Class StartForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.button1 = New System.Windows.Forms.Button()
			Me.label1 = New System.Windows.Forms.Label()
			Me.button2 = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(12, 96)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(318, 25)
			Me.button1.TabIndex = 0
			Me.button1.Text = "Add a new form"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.Create_Click);
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(12, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(318, 84)
			Me.label1.TabIndex = 1
			Me.label1.Text = "This example demonstrates how to implement drag-n-drop of MDI children (tabs) bet" & "ween different XtraTabbedMDIManagers." & Constants.vbCrLf & Constants.vbCrLf & "Create two or more forms and practice d" & "ragging tabs between the forms."
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' button2
			' 
			Me.button2.Location = New System.Drawing.Point(12, 123)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(318, 25)
			Me.button2.TabIndex = 2
			Me.button2.Text = "Close all opened forms"
			Me.button2.UseVisualStyleBackColor = True
'			Me.button2.Click += New System.EventHandler(Me.CloseAll_Click);
			' 
			' StartForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(342, 154)
			Me.Controls.Add(Me.button2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.button1)
			Me.Name = "StartForm"
			Me.Text = "Start"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents button1 As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		Private WithEvents button2 As System.Windows.Forms.Button
	End Class
End Namespace