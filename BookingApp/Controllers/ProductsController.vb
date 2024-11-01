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
    Public Class ProductsController
        Inherits System.Web.Mvc.Controller

        Private db As New BookingsEntities

        ' GET: Products
        Function Index() As ActionResult
            Return View(db.Products.ToList())
        End Function
        Function GetBrands()
            Dim products = db.Products.Select(Function(p) p.ProductName).Distinct().ToList()
            Return Json(products, behavior:=JsonRequestBehavior.AllowGet)
        End Function
        Function GetProdsType(ByVal brand As String)
            Dim products = db.Products.Select(Function(p) p.ProductType).Distinct().ToList()
            Return Json(products, behavior:=JsonRequestBehavior.AllowGet)
        End Function
        <HttpGet>
        Function GetProdsSub(ByVal brand As String, ByVal product As String)
            Dim products = db.Products _
        .Where(Function(p) p.ProductName = brand AndAlso p.ProductType = product) _
        .Select(Function(p) p.SubCatagoty) _
        .Distinct() _
        .ToList()

            Return Json(products, behavior:=JsonRequestBehavior.AllowGet)
        End Function
        Function GetProd(ByVal brand As String) As ActionResult
            Dim products = db.Products _
        .Where(Function(b) b.ProductName = brand) _
        .Select(Function(p) p.ProductType) _
        .Distinct() _
        .ToList()

            Return Json(products, behavior:=JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Function GetCost(ByVal a As String, b As String, c As String)
            Dim productList = db.Products _
            .Where(Function(p) p.ProductName = a AndAlso
                               p.ProductType = b AndAlso
                               p.SubCatagoty = c) _
            .Select(Function(p) New With {
                .Cost = p.Cost,
                .Note = p.Note
            }) _
            .ToList()

            Return Json(productList, behavior:=JsonRequestBehavior.AllowGet)
        End Function
        ' GET: Products/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As Product = db.Products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Return View(product)
        End Function

        ' GET: Products/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Products/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,ProductName,ProductType,SubCatagoty,ServiceType,Cost,Note")> ByVal product As Product) As ActionResult
            If ModelState.IsValid Then
                db.Products.Add(product)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(product)
        End Function

        ' GET: Products/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As Product = db.Products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Return View(product)
        End Function

        ' POST: Products/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,ProductName,ProductType,SubCatagoty,ServiceType,Cost,Note")> ByVal product As Product) As ActionResult
            If ModelState.IsValid Then
                db.Entry(product).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(product)
        End Function

        ' GET: Products/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As Product = db.Products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Return View(product)
        End Function

        ' POST: Products/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim product As Product = db.Products.Find(id)
            db.Products.Remove(product)
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
