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
    Public Class BookingDataController
        Inherits System.Web.Mvc.Controller

        Private db As New BookingsEntities

        ' GET: BookingData
        Function Index() As ActionResult
            Return View(db.BookingDatas.ToList())
        End Function
        Function GetBookings(dt As String) As ActionResult
            Dim BookedData = db.BookingDatas.Where(Function(d) d.ServiceDate = dt).ToList()
            Return Json(BookedData, behavior:=JsonRequestBehavior.AllowGet)

        End Function
        ' GET: BookingData/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim bookingData As BookingData = db.BookingDatas.Find(id)
            If IsNothing(bookingData) Then
                Return HttpNotFound()
            End If
            Return View(bookingData)
        End Function

        ' GET: BookingData/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: BookingData/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,Service,Description,TechName,ServiceDate,ServiceTime,Customer,Address,emial,Phone,Status,ServiceTime2,PostCode,BrandName,ApplianceType,AdditionalReq")> ByVal bookingData As BookingData) As ActionResult
            If ModelState.IsValid Then
                db.BookingDatas.Add(bookingData)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(bookingData)
        End Function

        ' GET: BookingData/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim bookingData As BookingData = db.BookingDatas.Find(id)
            If IsNothing(bookingData) Then
                Return HttpNotFound()
            End If
            Return View(bookingData)
        End Function

        ' POST: BookingData/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,Service,Description,TechName,ServiceDate,ServiceTime,Customer,Address,emial,Phone,Status,ServiceTime2,PostCode,BrandName,ApplianceType,AdditionalReq")> ByVal bookingData As BookingData) As ActionResult
            If ModelState.IsValid Then
                db.Entry(bookingData).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(bookingData)
        End Function

        ' GET: BookingData/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim bookingData As BookingData = db.BookingDatas.Find(id)
            If IsNothing(bookingData) Then
                Return HttpNotFound()
            End If
            Return View(bookingData)
        End Function

        ' POST: BookingData/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim bookingData As BookingData = db.BookingDatas.Find(id)
            db.BookingDatas.Remove(bookingData)
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
