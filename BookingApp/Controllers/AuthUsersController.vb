Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports BookingApp
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Namespace Controllers
    Public Class AuthUsersController
        Inherits System.Web.Mvc.Controller
        Private db As New BookingsEntities

        ' GET: AuthUsers
        Function Index() As ActionResult
            Return View(db.AuthUsers.ToList())
        End Function

        Private Ekey As String = "F#9@pL6R*m!Qy2$sL6R*m!Z&TvG#9@p"
        Private EIv As String = "7W#4@pX!Z3-bQy$"

        Public Function Encrypt(password As String) As String
            Dim key As Byte() = Encoding.UTF8.GetBytes(Ekey)
            Dim iv As Byte() = Encoding.UTF8.GetBytes(EIv)
            Array.Resize(iv, 16)
            Array.Resize(key, 32)
            Using aesAlg As Aes = Aes.Create()
                aesAlg.Key = key
                aesAlg.IV = iv

                Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)

                Using msEncrypt As New MemoryStream()
                    Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                        Using swEncrypt As New StreamWriter(csEncrypt)
                            swEncrypt.Write(password)
                        End Using
                    End Using
                    Return Convert.ToBase64String(msEncrypt.ToArray())
                End Using
            End Using
        End Function

        Public Function Decrypt(encryptedPassword As String) As String
            Dim key As Byte() = Encoding.UTF8.GetBytes(Ekey)
            Dim iv As Byte() = Encoding.UTF8.GetBytes(EIv)
            Dim cipherText As Byte() = Convert.FromBase64String(encryptedPassword)
            Array.Resize(iv, 16)
            Array.Resize(key, 32)
            Using aesAlg As Aes = Aes.Create()
                aesAlg.Key = key
                aesAlg.IV = iv
                Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)
                Using msDecrypt As New MemoryStream(cipherText)
                    Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                        Using srDecrypt As New StreamReader(csDecrypt)
                            Return srDecrypt.ReadToEnd()
                        End Using
                    End Using
                End Using
            End Using
        End Function

        ' GET: AuthUsers/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: AuthUsers/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,Name,Pass,Permission")> ByVal authUser As AuthUser) As ActionResult
            If ModelState.IsValid Then
                authUser.Pass = Encrypt(authUser.Pass)
                db.AuthUsers.Add(authUser)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(authUser)
        End Function
        ' GET: AuthUsers/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim authUser As AuthUser = db.AuthUsers.Find(id)
            If IsNothing(authUser) Then
                Return HttpNotFound()
            End If
            Return View(authUser)
        End Function
        Function ValidateUserCredentials(ByVal u As String, ByVal p As String) As ActionResult
            Dim user = db.AuthUsers.FirstOrDefault(Function(x) x.Name = u)
            If user IsNot Nothing Then
                Dim decryptedPassword = Decrypt(user.Pass)
                If String.Equals(decryptedPassword, p) Then
                    Session("auth") = "1"
                    Return Json("1")
                Else
                    Session("auth") = Nothing
                    ViewBag.res = "Incorrect User name or password"
                    Response.StatusCode = 200
                    Return Json(ViewBag.res)
                End If
                Session("auth") = Nothing
                ViewBag.res = "No Record found"
                Response.StatusCode = 200
                Return Json(ViewBag.res)
            End If
        End Function
        ' GET: AuthUsers/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim authUser As AuthUser = db.AuthUsers.Find(id)
            If IsNothing(authUser) Then
                Return HttpNotFound()
            End If
            Return View(authUser)
        End Function

        ' POST: AuthUsers/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,Name,Pass,Permission")> ByVal authUser As AuthUser) As ActionResult
            If ModelState.IsValid Then
                authUser.Name = authUser.Name
                authUser.Pass = Encrypt(authUser.Pass)
                db.Entry(authUser).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(authUser)
        End Function

        ' GET: AuthUsers/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim authUser As AuthUser = db.AuthUsers.Find(id)
            If IsNothing(authUser) Then
                Return HttpNotFound()
            End If
            Return View(authUser)
        End Function

        ' POST: AuthUsers/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim authUser As AuthUser = db.AuthUsers.Find(id)
            db.AuthUsers.Remove(authUser)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function
        Function Login()
            Return View()
        End Function
        Function logout()
            Session("auth") = Nothing
            Return RedirectToAction("Login")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
