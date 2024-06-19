Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports BookingApp

Namespace Controllers
    Public Class TechesController
        Inherits System.Web.Mvc.Controller

        Private db As New BookingsEntities

        ' GET: Teches
        Function Index() As ActionResult
            Return View(db.Techs.ToList())
        End Function

        ' GET: Teches/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tech As Tech = db.Techs.Find(id)
            If IsNothing(tech) Then
                Return HttpNotFound()
            End If
            Return View(tech)
        End Function

        ' GET: Teches/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Teches/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,Name,PostcodeRange,Services")> ByVal tech As Tech) As ActionResult
            If ModelState.IsValid Then
                db.Techs.Add(tech)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(tech)
        End Function

        ' GET: Teches/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tech As Tech = db.Techs.Find(id)
            If IsNothing(tech) Then
                Return HttpNotFound()
            End If
            Return View(tech)
        End Function

        ' POST: Teches/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,Name,PostcodeRange,Services")> ByVal tech As Tech) As ActionResult
            If ModelState.IsValid Then
                db.Entry(tech).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(tech)
        End Function

        ' GET: Teches/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tech As Tech = db.Techs.Find(id)
            If IsNothing(tech) Then
                Return HttpNotFound()
            End If
            Return View(tech)
        End Function

        ' POST: Teches/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim tech As Tech = db.Techs.Find(id)
            db.Techs.Remove(tech)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
