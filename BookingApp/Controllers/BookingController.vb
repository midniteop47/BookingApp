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
        Function CheckAvailability(ByRef P As String, S As String)
            Dim conn As New SqlConnection(My.Settings.ConStr)
            Dim adaptor, adaptor1, adaptor2 As SqlDataAdapter
            Dim DS, DS1, DS2 As New DataSet
            Dim StartTime As DateTime = DateTime.ParseExact("09:00 AM", "hh:mm tt", CultureInfo.InvariantCulture)
            Dim StopTime As DateTime = DateTime.ParseExact("05:00 PM", "hh:mm tt", CultureInfo.InvariantCulture)
            Dim maxTime As DateTime = DateTime.MinValue
            Dim currentTime As DateTime = DateTime.Now
            Dim currentDate As DateTime = DateTime.Now.ToString("dd-MMM-yyyy")
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            adaptor = New SqlDataAdapter("Select * from Dbo.ServiceData where service ='" & S & "'", conn)
            adaptor.Fill(DS)
            conn.Close()

            Dim Techname As String
            For Each r As DataRow In DS.Tables(0).Rows
                Techname = r(2)
                If (conn.State = ConnectionState.Open) Then
                    conn.Close()
                End If
                conn.Open()
                adaptor1 = New SqlDataAdapter("Select PostcodeRange from dbo.Techs where Name='" & Techname & "' ", conn)
                adaptor1.Fill(DS1)
                conn.Close()
                Dim postcodeRange As String = DS1.Tables(0).Rows(0)("PostcodeRange").ToString()
                Dim postcodes As String() = postcodeRange.Split(","c)
                'parse postcode 
                For i As Integer = 0 To postcodes.Length - 1
                    postcodes(i) = postcodes(i).Trim()
                Next
                Dim PostCodeToService As String
                'check if post code exists
                For Each postcode As String In postcodes
                    If postcode = P Then
                        PostCodeToService = P
                        Exit For
                    End If
                Next

                If IsNothing(PostCodeToService) Then
                    Dim resp As String = "No service tech available , contact Christy"
                    Return Json(resp, behavior:=JsonRequestBehavior.AllowGet)
                End If
                'find if tech is booked 

                If (conn.State = ConnectionState.Open) Then
                    conn.Close()
                End If
                conn.Open()
                adaptor2 = New SqlDataAdapter("Select ServiceDate,ServiceTime from dbo.BookingData where TechName='" & Techname & "' and Status Not like 'Completed' ", conn)
                adaptor2.Fill(DS2)
                conn.Close()
                If Not IsDBNull(DS2.Tables(0)) Then
                    If DS2.Tables(0).Rows.Count > 0 Then
                        Dim bookingsPerDayAndTime As New Dictionary(Of String, Dictionary(Of String, Integer))()
                        For Each row As DataRow In DS2.Tables(0).Rows
                            Dim timeStr As String = row(1).ToString()
                            Dim dateStr As String = row(0).ToString()

                            ' Parse the time and date from strings
                            Dim bookedTime As DateTime = DateTime.ParseExact(timeStr, "hh:mm tt", CultureInfo.InvariantCulture)
                            Dim bookedDate As DateTime = DateTime.ParseExact(dateStr, "dd-MMM-yyyy", CultureInfo.InvariantCulture)
                            Dim formattedDate As String = bookedDate.ToString("dd-MMM-yyyy")

                            ' Initialize a new dictionary for the day if it doesn't exist
                            If Not bookingsPerDayAndTime.ContainsKey(formattedDate) Then
                                bookingsPerDayAndTime(formattedDate) = New Dictionary(Of String, Integer)()
                            End If

                            ' Initialize count for the specific time on this day if it doesn't exist
                            If Not bookingsPerDayAndTime(formattedDate).ContainsKey(timeStr) Then
                                bookingsPerDayAndTime(formattedDate)(timeStr) = 0
                            End If

                            ' Increment the count for the specific time on this day
                            bookingsPerDayAndTime(formattedDate)(timeStr) += 1
                        Next

                        ' Output the results
                        For Each dayTimePair In bookingsPerDayAndTime
                            Dim dateStr As String = dayTimePair.Key
                            Dim bookingsForDay As Dictionary(Of String, Integer) = dayTimePair.Value

                            Console.WriteLine("Bookings for " & dateStr & ":")
                            For Each timeCountPair In bookingsForDay
                                Dim timeStr As String = timeCountPair.Key
                                Dim count As Integer = timeCountPair.Value

                                Console.WriteLine("- Time: " & timeStr & ", Bookings: " & count)
                            Next

                            Console.WriteLine()
                        Next
                    End If
                Else
                    'Available

                    If currentTime >= StartTime AndAlso currentTime <= StopTime Then
                        'Book for Today
                        Console.WriteLine("Current time is within the working hours.")
                    Else
                        'Book for tomorrow
                        Console.WriteLine("Current time is outside the working hours.")
                    End If

                End If

            Next

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