
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
        Session("repos_url") = ""
        Server.Transfer("index.aspx", True)
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim myReq As HttpWebRequest
        Dim myResp As HttpWebResponse

        myReq = HttpWebRequest.Create(CType(Session.Item("repos_url"), String))

        myReq.UserAgent = "Foo"
        myResp = myReq.GetResponse
        Dim myreader As New System.IO.StreamReader(myResp.GetResponseStream)
        Dim myText As String
        myText = myreader.ReadToEnd
        Dim json As JArray = JArray.Parse(myText)

        Dim dt As New DataTable
        dt.Columns.Add("full_name")
        dt.Columns.Add("description")
        dt.Columns.Add("stargazers_count")
        dt.Columns.Add("forks_count")
        Dim data As List(Of JToken) = json.Children().ToList
        For Each h As JToken In data
            h.CreateReader()
            Dim full_name As String = h("full_name")
            Dim description As String = CType(h("description"), String)
            Dim stargazers_count As String = h("stargazers_count")
            Dim forks_count As String = h("forks_count")

            dt.Rows.Add(New String() {full_name, description, stargazers_count, forks_count})
        Next
        GridView1.DataSource = dt
        GridView1.DataBind()


    End Sub

End Class
