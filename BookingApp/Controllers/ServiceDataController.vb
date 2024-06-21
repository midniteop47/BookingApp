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
    Public Class ServiceDataController
        Inherits System.Web.Mvc.Controller
        Private db As New BookingsEntities

        ' GET: ServiceData
        Function Index() As ActionResult
            Return View(db.ServiceDatas.ToList())
        End Function

        ' GET: ServiceData/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim serviceData As ServiceData = db.ServiceDatas.Find(id)
            If IsNothing(serviceData) Then
                Return HttpNotFound()
            End If
            Return View(serviceData)
        End Function

        ' GET: ServiceData/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: ServiceData/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,Service,TechName,Duration")> ByVal serviceData As ServiceData, Tid As String, R As String) As ActionResult
            If ModelState.IsValid Then
                db.ServiceDatas.Add(serviceData)
                db.SaveChanges()
                If R = "Y" Then
                    Return RedirectToAction("Edit", "Teches", New With {.id = Tid})
                Else
                    Return RedirectToAction("Index")
                End If
            End If
            Return View(serviceData)
        End Function
        <HttpGet>
        Function ServiceListForTech(N As String) As JsonResult
            Dim serviceData = db.ServiceDatas.Where(Function(a) a.TechName = N).ToList()
            Return Json(serviceData, JsonRequestBehavior.AllowGet)
        End Function
        ' GET: ServiceData/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim serviceData As ServiceData = db.ServiceDatas.Find(id)
            If IsNothing(serviceData) Then
                Return HttpNotFound()
            End If
            Return View(serviceData)
        End Function

        ' POST: ServiceData/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,Service,TechName,Duration")> ByVal serviceData As ServiceData) As ActionResult
            If ModelState.IsValid Then
                db.Entry(serviceData).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(serviceData)
        End Function

        ' GET: ServiceData/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim serviceData As ServiceData = db.ServiceDatas.Find(id)
            If IsNothing(serviceData) Then
                Return HttpNotFound()
            End If
            Return View(serviceData)
        End Function

        ' POST: ServiceData/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer, R As String, Tid As Integer) As ActionResult
            Dim serviceData As ServiceData = db.ServiceDatas.Find(id)
            db.ServiceDatas.Remove(serviceData)
            db.SaveChanges()
            If R = "Y" Then
                Return RedirectToAction("Edit", "Teches", New With {.id = Tid})
            End If
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
