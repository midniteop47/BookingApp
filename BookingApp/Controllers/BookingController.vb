Imports System.Web.Mvc
Imports System.Data.SqlClient
Imports Microsoft.SqlServer
Imports System.Globalization

Namespace Controllers
    Public Class BookingController
        Inherits Controller

        ' GET: Booking
        Function Index() As ActionResult
            Return View()
        End Function

        Function CheckAvailability(P As String, S As String, D As String)
            Dim conn As New SqlConnection(My.Settings.ConStr)
            Dim adaptor, adaptor1, adaptor2 As SqlDataAdapter
            Dim DS, DS1, DS2 As New DataSet
            Dim StartTime As DateTime = DateTime.ParseExact("09:00 AM", "hh:mm tt", CultureInfo.InvariantCulture)
            Dim StopTime As DateTime = DateTime.ParseExact("05:00 PM", "hh:mm tt", CultureInfo.InvariantCulture)
            Dim availableSlots As New List(Of String)()

            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            Try

                conn.Open()
                adaptor = New SqlDataAdapter("Select * from Dbo.ServiceData where service ='" & S & "'", conn)

                adaptor.Fill(DS)
                conn.Close()

                Dim Techname As String
                If DS.Tables(0).Rows.Count > 0 Then
                    For Each r As DataRow In DS.Tables(0).Rows
                        Techname = r(2).ToString()

                        If (conn.State = ConnectionState.Open) Then
                            conn.Close()
                        End If

                        conn.Open()
                        adaptor1 = New SqlDataAdapter("Select PostcodeRange from dbo.Techs where Name = @TechName", conn)
                        adaptor1.SelectCommand.Parameters.AddWithValue("@TechName", Techname)
                        adaptor1.Fill(DS1)
                        conn.Close()

                        Dim postcodeRange As String = DS1.Tables(0).Rows(0)("PostcodeRange").ToString()
                        Dim postcodes As String() = postcodeRange.Split(","c)
                        For i As Integer = 0 To postcodes.Length - 1
                            postcodes(i) = postcodes(i).Trim()
                        Next

                        Dim PostCodeToService As String
                        For Each postcode As String In postcodes
                            If postcode = P Then
                                PostCodeToService = P
                                Exit For
                            End If
                        Next

                        If IsNothing(PostCodeToService) Then
                            Dim resp As String = "No service tech available, contact Christy"
                            Return Json(resp, behavior:=JsonRequestBehavior.AllowGet)
                        End If

                        If (conn.State = ConnectionState.Open) Then
                            conn.Close()
                        End If

                        conn.Open()
                        adaptor2 = New SqlDataAdapter("Select ServiceDate, ServiceTime from dbo.BookingData where TechName = @TechName and ServiceDate='" & D & "'", conn)
                        adaptor2.SelectCommand.Parameters.AddWithValue("@TechName", Techname)
                        adaptor2.Fill(DS2)
                        conn.Close()

                        Dim bookedTimes As New List(Of DateTime)()
                        Dim greatestTime As DateTime = DateTime.MinValue

                        If DS2.Tables(0).Rows.Count = 0 Then
                            Dim parsedDate0 As DateTime
                            If DateTime.TryParse(D, parsedDate0) Then
                                Dim currentTimeN As DateTime = DateTime.Now
                                If parsedDate0.Date > DateTime.Now.Date Then
                                    If currentTimeN > StopTime Then
                                        Dim currentTime2 As DateTime = StartTime
                                        While currentTime2 <= StopTime
                                            availableSlots.Add(currentTime2.ToString("hh:mm tt"))
                                            currentTime2 = currentTime2.AddHours(1) ' Increment by one hour
                                        End While

                                        Dim resp = New With {
                                             Key .AvailableSlots = availableSlots,
                                             Key .Tech = Techname
                                         }
                                        Return Json(resp, behavior:=JsonRequestBehavior.AllowGet)
                                    Else
                                        Dim resp As String = "No available slots"
                                        Return Json(resp, behavior:=JsonRequestBehavior.AllowGet)
                                    End If
                                Else
                                    If currentTimeN > StopTime Then
                                        Dim resp As String = "No available slots"
                                        Return Json(resp, behavior:=JsonRequestBehavior.AllowGet)
                                    Else
                                        Dim currentTime2 As DateTime = StartTime
                                        If currentTime2.Minute > 0 Or currentTime2.Second > 0 Then
                                            currentTime2 = currentTime2.AddHours(1).AddMinutes(-currentTime2.Minute).AddSeconds(-currentTime2.Second)
                                        End If
                                        While currentTime2 <= StopTime
                                            availableSlots.Add(currentTime2.ToString("hh:mm tt"))
                                            currentTime2 = currentTime2.AddHours(1) ' Increment by one hour
                                        End While

                                        Dim resp = New With {
                                             Key .AvailableSlots = availableSlots,
                                             Key .Tech = Techname
                                         }
                                        Return Json(resp, behavior:=JsonRequestBehavior.AllowGet)
                                    End If
                                End If
                            Else

                            End If
                            Dim currentTime1 As DateTime = StartTime
                            While currentTime1 <= StopTime
                                availableSlots.Add(currentTime1.ToString("hh:mm tt"))
                                currentTime1 = currentTime1.AddHours(1) ' Increment by one hour
                            End While

                            Dim response = New With {
                         Key .AvailableSlots = availableSlots,
                         Key .Tech = Techname
                     }
                            Return Json(response, behavior:=JsonRequestBehavior.AllowGet)
                        End If

                        'find the greatest time slop booked
                        Dim currentTime3 As DateTime = StartTime
                        If currentTime3 > StopTime Then
                            Dim resp As String = "No available slots"
                            Return Json(resp, behavior:=JsonRequestBehavior.AllowGet)
                        End If
                        For Each row As DataRow In DS2.Tables(0).Rows
                            Dim timeStr As String = row(1).ToString()
                            Dim currentTimeC As DateTime

                            ' Try to parse the time string
                            If DateTime.TryParse(timeStr, currentTimeC) Then
                                ' Compare and find the greatest time
                                If currentTimeC > greatestTime Then
                                    greatestTime = currentTimeC
                                End If
                            End If
                        Next

                        Dim parsedDate As DateTime

                        Dim currentTime As DateTime
                        If DateTime.TryParse(D, parsedDate) Then
                            If parsedDate.Date >= DateTime.Now.Date Then
                                ' If greatestTime is greater than current time, set currentTime accordingly
                                currentTime = greatestTime.AddHours(1) ' Start from greatestTime + 1 hour

                            Else
                                If greatestTime > DateTime.Now Then
                                    currentTime = greatestTime.AddHours(1) ' Start from greatestTime + 1 hour
                                Else
                                    currentTime = DateTime.Now.AddHours(1) ' Start from current time + 1 hour
                                End If

                            End If
                        Else
                            ' Handle the case where D is not a valid date string
                            Console.WriteLine("Invalid date format.")
                            currentTime = DateTime.Now.AddHours(1) ' Default behavior
                        End If

                        ' Use a While loop to determine available slots
                        While currentTime <= StopTime
                            If Not bookedTimes.Contains(currentTime) Then
                                availableSlots.Add(currentTime.ToString("hh:mm tt"))
                            End If
                            currentTime = currentTime.AddHours(1)
                        End While
                        If availableSlots.Count = 0 Then
                            Dim resp As String = "No available slots"

                            Return Json(resp, behavior:=JsonRequestBehavior.AllowGet)
                        Else
                            Dim response = New With {
                         Key .AvailableSlots = availableSlots,
                         Key .Tech = Techname
                     }
                            Return Json(response, behavior:=JsonRequestBehavior.AllowGet)
                        End If
                    Next
                Else
                    'No Service data found, return default available slots
                    Dim currentTime2 As DateTime = StartTime
                    While currentTime2 <= StopTime
                        availableSlots.Add(currentTime2.ToString("hh:mm tt"))
                        currentTime2 = currentTime2.AddHours(1)
                    End While

                    Return Json(availableSlots, behavior:=JsonRequestBehavior.AllowGet)

                End If
            Catch ex As Exception
                Return ex.Message
            End Try

        End Function

        Function TechNameByPostcode()





        End Function

        Function NewBooking()

            Dim insertQ As String = "INSERT INTO dbo.BookingData
                                                (Service,
                                                Description,
                                                TechName,
                                                ServiceDate,
                                                ServiceTime,
                                                Customer,
                                                Address,
                                                email,
                                                Phone,
                                                Status,
                                                ServiceTime2)
                                        VALUES 
                                                ()"
        End Function
        Public Sub ExecuteQuery(query As String)
            Dim conn As New SqlConnection(My.Settings.ConStr)
            Dim command As New SqlCommand(query, conn)
Check:
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            command.ExecuteNonQuery()
            conn.Close()
        End Sub

    End Class
End Namespace