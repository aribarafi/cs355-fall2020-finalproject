CREATE TABLE Transport_Provider (
  idTransport_Provider INTEGER  NOT NULL   IDENTITY ,
  Name VARCHAR    ,
  One_Way_Payment VARCHAR(255)    ,
  Return_Payment VARCHAR(255)    ,
  Mileage_Fees VARCHAR(255)      ,
PRIMARY KEY(idTransport_Provider));
GO




CREATE TABLE Client (
  idClient INTEGER  NOT NULL   IDENTITY ,
  Name VARCHAR(255)      ,
PRIMARY KEY(idClient));
GO




CREATE TABLE Passenger (
  idPassenger INTEGER  NOT NULL   IDENTITY ,
  Client_idClient INTEGER  NOT NULL  ,
  Name VARCHAR(255)    ,
  Phone_Number VARCHAR(255)      ,
PRIMARY KEY(idPassenger)  ,
  FOREIGN KEY(Client_idClient)
    REFERENCES Client(idClient));
GO


CREATE INDEX Passenger_FKIndex1 ON Passenger (Client_idClient);
GO


CREATE INDEX IFK_Rel_06 ON Passenger (Client_idClient);
GO


CREATE TABLE Client_has_Transport_Provider (
  Client_has_Transport_Providerid INTEGER  NOT NULL   IDENTITY ,
  Client_idClient INTEGER  NOT NULL  ,
  Transport_Provider_idTransport_Provider INTEGER  NOT NULL    ,
PRIMARY KEY(Client_has_Transport_Providerid, Client_idClient, Transport_Provider_idTransport_Provider)    ,
  FOREIGN KEY(Client_idClient)
    REFERENCES Client(idClient),
  FOREIGN KEY(Transport_Provider_idTransport_Provider)
    REFERENCES Transport_Provider(idTransport_Provider));
GO


CREATE INDEX Client_has_Transport_Provider_FKIndex1 ON Client_has_Transport_Provider (Client_idClient);
GO
CREATE INDEX Client_has_Transport_Provider_FKIndex2 ON Client_has_Transport_Provider (Transport_Provider_idTransport_Provider);
GO


CREATE INDEX IFK_Rel_10 ON Client_has_Transport_Provider (Client_idClient);
GO
CREATE INDEX IFK_Rel_11 ON Client_has_Transport_Provider (Transport_Provider_idTransport_Provider);
GO


CREATE TABLE OrderDetails (
  idOrderDetails INTEGER  NOT NULL   IDENTITY ,
  Transport_Provider_idTransport_Provider INTEGER  NOT NULL  ,
  Passenger_idPassenger INTEGER  NOT NULL  ,
  WC_Ambulatory VARCHAR(255)    ,
  OrderDate VARCHAR(255)    ,
  TotalPayment VARCHAR(255)    ,
  isOne_Way VARCHAR(255)    ,
  Date_for_Order VARCHAR(255)    ,
  Pickup_Time VARCHAR(255)    ,
  Pickup_Address VARCHAR(255)    ,
  Drop_off_Address VARCHAR(255)    ,
  ReturnTime VARCHAR(255)    ,
  Miles VARCHAR(255)      ,
PRIMARY KEY(idOrderDetails)    ,
  FOREIGN KEY(Passenger_idPassenger)
    REFERENCES Passenger(idPassenger),
  FOREIGN KEY(Transport_Provider_idTransport_Provider)
    REFERENCES Transport_Provider(idTransport_Provider));
GO


CREATE INDEX OrderDetails_FKIndex2 ON OrderDetails (Passenger_idPassenger);
GO
CREATE INDEX OrderDetails_FKIndex3 ON OrderDetails (Transport_Provider_idTransport_Provider);
GO


CREATE INDEX IFK_Rel_06 ON OrderDetails (Passenger_idPassenger);
GO
CREATE INDEX IFK_Rel_07 ON OrderDetails (Transport_Provider_idTransport_Provider);
GO