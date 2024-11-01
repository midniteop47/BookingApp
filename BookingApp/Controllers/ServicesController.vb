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
    Public Class ServicesController
        Inherits System.Web.Mvc.Controller

        Private db As New BookingsEntities

        ' GET: Services
        Function Index() As ActionResult
            Return View(db.Services.ToList())
        End Function

        Function ServiceList(ByVal P As String) As ActionResult
            'Return Json(db.Services.ToList(), behavior:=JsonRequestBehavior.AllowGet)

            Dim distinctServiceTypes = db.Products _
        .Where(Function(pr) pr.ProductType = P) _
        .Select(Function(pr) pr.ServiceType) _
        .Distinct() _
        .ToList()

            Return Json(distinctServiceTypes, behavior:=JsonRequestBehavior.AllowGet)
        End Function


        ' GET: Services/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim service As Service = db.Services.Find(id)
            If IsNothing(service) Then
                Return HttpNotFound()
            End If
            Return View(service)
        End Function

        ' GET: Services/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Services/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,Service1")> ByVal service As Service) As ActionResult
            If ModelState.IsValid Then
                db.Services.Add(service)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(service)
        End Function

        ' GET: Services/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim service As Service = db.Services.Find(id)
            If IsNothing(service) Then
                Return HttpNotFound()
            End If
            Return View(service)
        End Function

        ' POST: Services/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,Service1")> ByVal service As Service) As ActionResult
            If ModelState.IsValid Then
                db.Entry(service).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(service)
        End Function

        ' GET: Services/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim service As Service = db.Services.Find(id)
            If IsNothing(service) Then
                Return HttpNotFound()
            End If
            Return View(service)
        End Function

        ' POST: Services/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim service As Service = db.Services.Find(id)
            db.Services.Remove(service)
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
