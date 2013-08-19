'    Copyright 2010, 2013 Brendan Ferracciolo
'
'    This file is part of Custom Tweet URL Creator.
'
'    Custom Tweet URL Creator is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    Custom Tweet URL Creator is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with Custom Tweet URL Creator.  If not, see <http://www.gnu.org/licenses/>.

Imports System.Text

Public Class Form1

    Dim TweetLength As Short
    Dim URL As String
    Dim Tweet4URL As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TweetLength = 140 - TextBox1.Text.Length
        Button5.Text = TweetLength.ToString

        If TweetLength <= 10 Then
            Button5.ForeColor = Color.Red
        ElseIf TweetLength <= 20 Then
            Button5.ForeColor = Color.Maroon
        ElseIf TweetLength > 20 Then
            Button5.ForeColor = Color.Silver
        End If

        If TweetLength < 0 Then
            TextBox2.Text = "Your tweet is too long!"
            Button1.Enabled = False
            Exit Sub
        End If

        TextBox2.Text = "Generating..."

        Tweet4URL = TextBox1.Text

        Dim s As System.Text.StringBuilder
        s = New System.Text.StringBuilder(Tweet4URL)
        s.Replace("%", "%25")
        s.Replace("+", "%2B")
        s.Replace(vbCrLf, "+")
        s.Replace(" ", "+")
        s.Replace("$", "%24")
        s.Replace("&", "%26")
        s.Replace(",", "%2C")
        s.Replace("/", "%2F")
        s.Replace(":", "%3A")
        s.Replace(";", "%3B")
        s.Replace("=", "%3D")
        s.Replace("?", "%3F")
        s.Replace("@", "%40")
        s.Replace("""", "%22")
        s.Replace("<", "%3C")
        s.Replace(">", "%3E")
        s.Replace("#", "%23")
        s.Replace("{", "%7B")
        s.Replace("}", "%7D")
        s.Replace("|", "%7C")
        s.Replace("\", "%5C")
        s.Replace("^", "%5E")
        s.Replace("~", "%7E")
        s.Replace("[", "%5B")
        s.Replace("]", "%5D")
        s.Replace("`", "%60")
        s.Replace("'", "%27")
        Tweet4URL = s.ToString

        TextBox2.Text = "http://twitter.com/home/?status=" & Tweet4URL

        Button1.Enabled = True

        If TextBox1.Text = "" Then
            TextBox2.Text = ""
            Button1.Enabled = False
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(TextBox2.Text)
        End If
    End Sub
End Class
