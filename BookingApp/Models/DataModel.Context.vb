﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class BookingsEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=BookingsEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property AuthUsers() As DbSet(Of AuthUser)
    Public Overridable Property Products() As DbSet(Of Product)
    Public Overridable Property Techs() As DbSet(Of Tech)

End Class
