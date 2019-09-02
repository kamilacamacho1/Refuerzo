Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1
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

    'Private Sub GenerarArchivo(jResults As JObject)

    '    Dim strStreamW As Stream
    '    Dim strStreamWriter As StreamWriter

    '    Try
    '        Dim ds As DataSet
    '        'Ruta de el archivo para agregar
    '        Dim fileP As String = "C:\nombreArchivo.txt"

    '        strStreamW = File.OpenWrite(fileP)

    '        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.UTF8)

    '        'ds = jResults

    '    Catch ex As Exception

    '    End Try

    'End Sub

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

End Class
