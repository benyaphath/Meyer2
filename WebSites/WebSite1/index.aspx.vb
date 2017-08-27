
Imports System.IO
Imports System.Net
Imports System.Net.WebClient
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Web.Script.Serialization
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myReq As HttpWebRequest
        Dim myResp As HttpWebResponse

        myReq = HttpWebRequest.Create("https://api.github.com/search/users?q=" + TextBox1.Text)

        myReq.UserAgent = "Foo"
        myResp = myReq.GetResponse
        Dim myreader As New System.IO.StreamReader(myResp.GetResponseStream)
        Dim myText As String
        myText = myreader.ReadToEnd
        Dim json As JObject = JObject.Parse(myText)

        Dim dt As New DataTable
        dt.Columns.Add("login")
        dt.Columns.Add("ru")
        dt.Columns.Add("im")
        Dim data As List(Of JToken) = json.Children().ToList
        For Each h As JProperty In data
            h.CreateReader()
            Select Case h.Name
                Case "items"
                    For Each item As JObject In h.Values
                        Dim login As String = item("login")
                        Dim im As String = item("avatar_url")
                        Dim ru As String = item("repos_url")
                        dt.Rows.Add(New String() {login, ru, im})

                    Next
            End Select

        Next
        GridView1.DataSource = dt
        GridView1.DataBind()

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBox1.Text = "microsoft"
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow
        Session("repos_url") = row.Cells(1).Text
        Server.Transfer("Detail.aspx", True)

    End Sub

End Class
