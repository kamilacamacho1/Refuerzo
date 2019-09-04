<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BtnCrearTxt = New System.Windows.Forms.Button()
        Me.BtnSobreescribir = New System.Windows.Forms.Button()
        Me.BtnGuardartodo = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.TxtNombres = New System.Windows.Forms.TextBox()
        Me.TxtApellidos = New System.Windows.Forms.TextBox()
        Me.ListBoxClientes = New System.Windows.Forms.ListBox()
        Me.LblTotal = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(39, 288)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(430, 150)
        Me.DataGridView1.TabIndex = 2
        '
        'BtnCrearTxt
        '
        Me.BtnCrearTxt.Location = New System.Drawing.Point(39, 12)
        Me.BtnCrearTxt.Name = "BtnCrearTxt"
        Me.BtnCrearTxt.Size = New System.Drawing.Size(75, 23)
        Me.BtnCrearTxt.TabIndex = 3
        Me.BtnCrearTxt.Text = "Crear Txt"
        Me.BtnCrearTxt.UseVisualStyleBackColor = True
        '
        'BtnSobreescribir
        '
        Me.BtnSobreescribir.Location = New System.Drawing.Point(120, 12)
        Me.BtnSobreescribir.Name = "BtnSobreescribir"
        Me.BtnSobreescribir.Size = New System.Drawing.Size(96, 23)
        Me.BtnSobreescribir.TabIndex = 4
        Me.BtnSobreescribir.Text = "Sobre Escribir"
        Me.BtnSobreescribir.UseVisualStyleBackColor = True
        '
        'BtnGuardartodo
        '
        Me.BtnGuardartodo.Location = New System.Drawing.Point(222, 12)
        Me.BtnGuardartodo.Name = "BtnGuardartodo"
        Me.BtnGuardartodo.Size = New System.Drawing.Size(102, 23)
        Me.BtnGuardartodo.TabIndex = 5
        Me.BtnGuardartodo.Text = "Guardar Todo"
        Me.BtnGuardartodo.UseVisualStyleBackColor = True
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Location = New System.Drawing.Point(330, 12)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.BtnEliminar.TabIndex = 6
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'TxtNombres
        '
        Me.TxtNombres.Location = New System.Drawing.Point(39, 69)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(100, 20)
        Me.TxtNombres.TabIndex = 7
        '
        'TxtApellidos
        '
        Me.TxtApellidos.Location = New System.Drawing.Point(145, 69)
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.Size = New System.Drawing.Size(100, 20)
        Me.TxtApellidos.TabIndex = 8
        '
        'ListBoxClientes
        '
        Me.ListBoxClientes.FormattingEnabled = True
        Me.ListBoxClientes.Location = New System.Drawing.Point(39, 124)
        Me.ListBoxClientes.Name = "ListBoxClientes"
        Me.ListBoxClientes.Size = New System.Drawing.Size(206, 95)
        Me.ListBoxClientes.TabIndex = 9
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Location = New System.Drawing.Point(330, 75)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(13, 13)
        Me.LblTotal.TabIndex = 11
        Me.LblTotal.Text = "0"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.ListBoxClientes)
        Me.Controls.Add(Me.TxtApellidos)
        Me.Controls.Add(Me.TxtNombres)
        Me.Controls.Add(Me.BtnEliminar)
        Me.Controls.Add(Me.BtnGuardartodo)
        Me.Controls.Add(Me.BtnSobreescribir)
        Me.Controls.Add(Me.BtnCrearTxt)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BtnCrearTxt As Button
    Friend WithEvents BtnSobreescribir As Button
    Friend WithEvents BtnGuardartodo As Button
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents TxtNombres As TextBox
    Friend WithEvents TxtApellidos As TextBox
    Friend WithEvents ListBoxClientes As ListBox
    Friend WithEvents LblTotal As Label
End Class
