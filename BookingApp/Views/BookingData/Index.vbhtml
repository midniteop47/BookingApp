@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code

@ModelType IEnumerable(Of BookingApp.BookingData)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<style>
    .loading{
        display:none;
    }
    table {
        width: 100%;
        border-collapse: collapse;
    }

    th, td {
        border: 1px solid black;
        padding: 8px;
        text-align: center;
        vertical-align: baseline; 
    }

    th {
        background-color: #f2f2f2;
    }
    .card {
        box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
        transition: 0.3s;
        border-radius: 7px;
        display:flex;
        padding:inherit;
        
    }

        .card:hover {
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
        }
    .containerb{
        padding: 2px 16px;
    }
    .containera {
        padding: 2px 16px;
    }
    .vertical-text {
        display:none;
    }
     @@media (max-width: 600px) {
            table, thead, tbody, th, td, tr {
                display: block;
            }
            thead tr {
                position: absolute;
                top: -9999px;
                left: -9999px;
            }
        tr {
            border: 1px solid black;
        }
        td {
            border: none;
            border-bottom: 1px solid black;
            position: relative;
            
        }
               
            
            td:before {
                position: absolute;
                top: 6px;
                left: 6px;
                width: 45%;
                padding-right: 10px;
                white-space: nowrap;
                content: attr(data-label);
                font-weight: bold;
            }

        .vertical-text {
            display:block;
            writing-mode: vertical-rl;
            transform: rotate(180deg); /* Optional: to make the text readable from top to bottom */
            white-space: nowrap;
        }

     }
    
</style>
<h2 id="Bk" >Bookings</h2>
<p id="loading"></p>
<p>
    @Html.ActionLink("Create New", "Create")
</p>

<div>
    <div id="NavButtons">
        <button id="prev">Previous</button>
        <button id="today">Today</button>
        <button id="next">Next</button>
    </div>
    <br />
    <div>
        <table id="calendarTable">    
            <thead >
                <tr id="wkrow">

                </tr>
            </thead>
            <tbody>
                <tr id="weekRow">
                   
                </tr>
            </tbody>
        </table>
    </div>
</div>



<script>const calendarTable = document.getElementById('calendarTable');
    const weekRow = document.getElementById('weekRow');
    const weekRowH = document.getElementById('wkrow');
        const prevButton = document.getElementById('prev');
        const todayButton = document.getElementById('today');
        const nextButton = document.getElementById('next');

        let currentDate = new Date();

        function getWeekDates(date) {
            const startOfWeek = new Date(date.setDate(date.getDate() - date.getDay()));
            const weekDates = [];
            for (let i = 0; i < 7; i++) {
                weekDates.push(new Date(startOfWeek));
                startOfWeek.setDate(startOfWeek.getDate() + 1);
            }
           
            return weekDates;

        }

    function renderCalendar(date) {
       
        weekRow.innerHTML = ''; // Clear the existing week row
        const weekDates = getWeekDates(new Date(date));
        weekDates.forEach(day => {
            const td = document.createElement('td');
          
            // Format the date to yyyy-MM-dd
            const formattedDate = day.toLocaleDateString('en-CA'); // 'en-CA' locale produces yyyy-MM-dd format
          
            $.ajax({
                url: '/BookingData/GetBookings',
                type: 'GET',
                data: { dt: formattedDate },
                success: function (data) {
                   
                    data.forEach(booking => {
                        document.getElementById('loading').innerText = 'Loading..'
                        const card = document.createElement('div');
                        card.className = 'card';
                        const container = document.createElement('div');
                        container.className = 'containera';
                        const containerb = document.createElement('div');
                        container.className = 'containerb';
                        const service = document.createElement('h4');
                        service.innerHTML = `<b>${booking.Service}</b>`;
                        const customer = document.createElement('p');
                        customer.textContent = booking.Customer;
                        const vtext = document.createElement('p');
                        vtext.className = 'vertical-text';
                        vtext.textContent = day.toDateString();
                        container.appendChild(service);
                        container.appendChild(customer);
                        containerb.appendChild(container);
                        card.appendChild(vtext);
                        card.appendChild(containerb);                        
                        td.appendChild(card);                      
                       
                        hide()
                    });
                   
                },
                error: function (error) {
                    console.error('Error fetching booking data:', error);
                }
            });
           
            document.getElementById('loading').innerText = 'Loading....'
            weekRow.appendChild(td);
            hide()
            
        });        
    }
    function hide() {
       
        document.getElementById('loading').innerText = ''
    }
    function renderCalendarH(date) {
        weekRowH.innerHTML = ''; // Clear the existing week row
        const weekDates = getWeekDates(new Date(date));
        weekDates.forEach(day => {
            const td = document.createElement('td');
            td.textContent = day.toDateString();
            weekRowH.appendChild(td);
        });
    }
        prevButton.addEventListener('click', () => {
            currentDate.setDate(currentDate.getDate() - 7);
            renderCalendar(currentDate);
        });
        todayButton.addEventListener('click', () => {
            currentDate = new Date();
            renderCalendar(currentDate);
        });
        nextButton.addEventListener('click', () => {
            currentDate.setDate(currentDate.getDate() + 7);
            renderCalendar(currentDate);
        });
        // Initial render for the current week
    renderCalendarH(currentDate);
    renderCalendar(currentDate);
    </script>

