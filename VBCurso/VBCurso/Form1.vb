Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1
    ':::Ruta donde crearemos nuestro archivo txt
    Dim ruta As String = "C:\Tutoriales\"
    ':::Nombre del archivo
    Dim archivo As String = "Prueba.txt"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Antes de ingresar al formulario se ingresa el nombre 

        Dim nombre As String
        nombre = InputBox("Ingrese su nombre", "Datos", "", 100, 0)
        MessageBox.Show("Te damos la bienvenida: " & nombre, "Datos", MessageBoxButtons.OK, MessageBoxIcon.Question)

        'extraer el Json de una URL
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        request = DirectCast(WebRequest.Create("https://mdn.github.io/learning-area/javascript/oojs/json/superheroes.json"), HttpWebRequest)
        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())
        Dim rawresp As String
        rawresp = reader.ReadToEnd()
        'Parseo 
        Dim jResults As JObject = JObject.Parse(rawresp)
        Dim results As List(Of JToken) = jResults.Children().ToList()

        Dim sHeroe As List(Of Heroe) = New List(Of Heroe)


        'Iteración de el json
        For Each item As JProperty In results

            item.CreateReader()
            Select Case item.Name
                Case "squadName"
                    Dim strSquad = item.Value.ToString
                Case "members"

                    ' una subIteración para el campo con multiples datos 
                    For Each subItem As JObject In item.Value
                        Dim heroe As Heroe = New Heroe
                        heroe.name = subItem("name")
                        heroe.secretIdentity = subItem("secretIdentity")
                        'VBCurso.Heroe.Member = subItem("name")
                        'secretIdentity = subItem("secretIdentity")
                        sHeroe.Add(heroe)
                    Next

            End Select

        Next


        'datos de el Json a la tabla 
        DataGridView1.DataSource = ObtenerDatosDeJson(jResults)
        'sirve para no editar las filas 
        DataGridView1.ReadOnly = True
        ''Ajustar tamaño de columnas y celdas.
        DataGridView1.AutoResizeColumns()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells







    End Sub


    Public Function ObtenerDatosDeJson(json As JObject) As DataTable

        Dim srcArray = json.Descendants().Where(Function(d) TypeOf d Is JArray).First()

        Dim trgArray = New JArray()
        For Each row As JObject In srcArray.Children(Of JObject)
            Dim cleanRow = New JObject()
            For Each column As JProperty In row.Properties()
                If TypeOf column.Value Is JValue Then
                    cleanRow.Add(column.Name, column.Value)
                End If
            Next
            trgArray.Add(cleanRow)
        Next

        Return JsonConvert.DeserializeObject(Of DataTable)(trgArray.ToString())

    End Function

    Private Sub BtnCrearTxt_Click(sender As Object, e As EventArgs) Handles BtnCrearTxt.Click

        Dim fs As FileStream

        Try
            If File.Exists(ruta) Then

                ':::Si la carpeta existe creamos o sobreescribios el archivo txt
                fs = File.Create(ruta & archivo)
                fs.Close()
                MsgBox("Archivo creado Correctamente", MsgBoxStyle.Information, "Manejo de Archivos")

            Else
                ':::Si la carpeta no existe la creamos
                Directory.CreateDirectory(ruta)
                ':::Una vez creada la carpeta creamos o sobreescribios el archivo txt
                fs = File.Create(ruta & archivo)
                fs.Close()
                MsgBox("Archivo Creado Correctamente", MsgBoxStyle.Information, "Manejo de Archivos")
            End If

        Catch ex As Exception

            MsgBox("Se genero un error", MsgBoxStyle.Critical, "Manejo de Archivos")

        End Try

    End Sub

    Private Sub BtnSobreescribir_Click(sender As Object, e As EventArgs) Handles BtnSobreescribir.Click
        ':::Creamos un objeto de tipo StreamWriter que nos permite escribir en ficheros TXT
        Dim escribir As New StreamWriter(ruta & archivo)
        Try
            ':::Escribimos una linea en nuestro archivo TXT con el formato que este separado por coma (,)
            escribir.WriteLine(TxtNombres.Text + "," + TxtApellidos.Text)
            escribir.Close()
            MsgBox("registro Guardado Correctamente", MsgBoxStyle.Information, "Manejo de Archivos")
            '::: TextBox Vacíos
            TxtNombres.Clear()
            TxtApellidos.Clear()
            '::: procedimiento para leer el archivo TXT
            LeerArchivo()

        Catch ex As Exception

            MsgBox("Se genero un problema")

        End Try

    End Sub

    Sub LeerArchivo()
        ':::Creamos nuestro objeto de tipo StreamReader que nos permite leer archivos
        Dim leer As New StreamReader(ruta & archivo)

        ':::Limpiamos nuestro ListBox
        ListBoxClientes.Items.Clear()

        Try
            ':::Indicamos mediante un While que mientras no sea el ultimo caracter repita el proceso
            While leer.Peek <> -1
                ':::Lee cada linea del archivo TXT
                Dim linea As String = leer.ReadLine()
                ':::Valida que la linea no este vacia
                If String.IsNullOrEmpty(linea) Then
                    Continue While
                End If
                ':::Se Agrega los registros encontrados
                ListBoxClientes.Items.Add(linea)
            End While

            leer.Close()
            ':::Total de registros cargados al ListBox
            LblTotal.Text = ListBoxClientes.Items.Count

        Catch ex As Exception
            MsgBox("Se genero un problema para leer el archivo", MsgBoxStyle.Critical, "Manejo de Archivos")
        End Try


    End Sub

    Private Sub BtnGuardartodo_Click(sender As Object, e As EventArgs) Handles BtnGuardartodo.Click
        ':::Creamos un objeto de tipo StreamWriter que nos permite escribir en ficheros TXT
        ':::El unico cambio es que agregamos el valor TRUE con el fin de indicar que queremos
        ':::Seguir agregando los registros y no sobreescribirlos
        Dim escribir As New StreamWriter(ruta & archivo, True)

        Try
            ':::Escribimos una linea en nuestro archivo TXT con el formato que este separado por coma (,)
            escribir.WriteLine(TxtNombres.Text + "," + TxtApellidos.Text)
            escribir.Close()
            MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Manejo de archivos")
            TxtNombres.Clear()
            TxtApellidos.Clear()
            LeerArchivo()
        Catch ex As Exception

            MsgBox("Se presento un problema al momento de escribir", MsgBoxStyle.Critical, "Manejo de Archivos")

        End Try

    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            If File.Exists(ruta & archivo) Then
                ':::Eliminamos el archivo TXT
                File.Delete(ruta & archivo)
                MsgBox("Archivo eliminado Correctamente")
                TxtNombres.Clear()
                TxtApellidos.Clear()
                ListBoxClientes.ClearSelected()
                LblTotal.Text = "0"


            Else
                MsgBox("No se encuentra el archivo")

            End If

        Catch ex As Exception
            MsgBox("Se presento un problema al eliminar el archivo", MsgBoxStyle.Critical, "Manejo de archivos")
        End Try
    End Sub

End Class
