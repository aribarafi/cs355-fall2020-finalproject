--DO THESE
ALTER TABLE OrderDetails
DROP COLUMN PassengerName

ALTER TABLE OrderDetails
DROP COLUMN PassengerNumber

ALTER TABLE OrderDetails
DROP COLUMN TransportProviderName

ALTER TABLE OrderDetails
DROP COLUMN Miles

ALTER TABLE Transport_Provider
DROP COLUMN Mileage_Fees

/*

where Passenger_idPassenger = (SELECT idPassenger FROM Passenger WHERE Name = 'John E Davis(Frank D Lanterman)')

SELECT OD.idOrderDetails, OD.Transport_Provider_idTransport_Provider, OD.Passenger_idPassenger, OD.WC_Ambulatory,OD.OrderDate,OD.TotalPayment,OD.isOne_Way,OD.Date_for_Order,OD.Pickup_Time, OD.Pickup_Address, OD.Drop_off_Address, OD.ReturnTime, P.idPassenger, P.Client_idClient, P.[Name] as PassengerName, P.Phone_Number, TP.idTransport_Provider, TP.[Name] as TransportProviderName, TP.One_Way_Payment, TP.Return_Payment
FROM OrderDetails OD Inner Join Passenger P
ON OD.Passenger_idPassenger = P.idPassenger
INNER JOIN Transport_Provider TP
ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider


WHERE P.[Name] = 'John E Davis(Frank D Lanterman)'

SELECT * FROM OrderDetails OD INNER JOIN Transport_Provider TP 
ON OD.Transport_Provider_idTransport_Provider = TP.idTransport_Provider

select * from Client*/